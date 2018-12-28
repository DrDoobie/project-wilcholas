using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private bool isJumping;
    private CharacterController controller;
    [SerializeField] private float walkSpeed = 5.0f, sprintSpeed = 7.5f, jumpMultiplier = 10.0f, slopeForce = 2.0f;
    [SerializeField] private AnimationCurve jumpCurve;
    private float movementSpeed;

    private void Awake() {
        controller = GetComponent<CharacterController>();
    }

    private void Update() {
        if(GameObject.FindWithTag("Player").GetComponent<PlayerStats>().isAlive)
        {
            MovementController();
        }
    }

    private void MovementController() {
        if (IsSprinting())
        {
            movementSpeed = sprintSpeed;
                GetComponent<PlayerStats>().stamina -= .2f;

        } else {
            movementSpeed = walkSpeed;
        }

        //Record horizontal and vertical input
        float vertInput = Input.GetAxis("Vertical");
            float horizInput = Input.GetAxis("Horizontal");

        Vector3 forwardMovement = transform.forward * vertInput;
            Vector3 sideMovement = transform.right * horizInput;

        //Move player with horizontal and vertical input
        controller.SimpleMove(Vector3.ClampMagnitude(forwardMovement + sideMovement, 1.0f) * movementSpeed);

        if ((vertInput != 0) || (horizInput != 0) && OnSlope())
        {
            controller.Move((Vector3.down * (controller.height / 2) * slopeForce) * Time.deltaTime);
        }

        Jump();
    }

    private bool IsSprinting() {
        if (Input.GetButton("Sprint"))
        {
            if(GetComponent<PlayerStats>().stamina > 0)
            {
                return true;
            }
        }

        return false;
    }

    private bool OnSlope() {
        if (isJumping)
        {
            return false;
        }

        //Cast a ray to determine if player is on a slope or not
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, (controller.height / 2) * 1.5f))
        {
            if (hit.normal != Vector3.up)
            {
                return true;
            }
        }

        return false;
    }

    private void Jump() {
        if (Input.GetButtonDown("Jump") && !isJumping && (GetComponent<PlayerStats>().stamina > 0))
        {
            isJumping = true;
                StartCoroutine(JumpEvent());
        }
    }

    private IEnumerator JumpEvent() {
        controller.slopeLimit = 90.0f;
            float airTime = 0.0f;

        do
        {
            //Set jump force
            float jumpForce = jumpCurve.Evaluate(airTime);

            //Jump happens here
            controller.Move((Vector3.up * jumpForce * jumpMultiplier) * Time.deltaTime);
                airTime += Time.deltaTime;
                    GetComponent<PlayerStats>().stamina -= 0.2f;

            yield return null;

            //Player will stop jumping if collides into something above
        } while ((!controller.isGrounded) && (controller.collisionFlags != CollisionFlags.Above));

        controller.slopeLimit = 45.0f;
            isJumping = false;
    }
}
