using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public bool invertedMouseY = false;
    [SerializeField] private float mouseSens = 7.5f;
    private float xClamp = 0.0f;

    private void Awake() {
        CursorLock();
    }

    private void Update() {
        if(GameObject.FindWithTag("Player").GetComponent<PlayerStats>().isAlive)
        {
            LookController();
        }
    }

    private void CursorLock() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LookController()
    {
        //Record mouse x and y movement
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSens;

        //Limit camera rotation
        xClamp += mouseY;

        if (xClamp > 90.0f)
        {
            xClamp = 90.0f;
            mouseY = 0.0f;
            ClampXRotation(270.0f);

        } else if (xClamp < -90.0f) {
            xClamp = -90.0f;
            mouseY = 0.0f;
            ClampXRotation(90.0f);
        }

        //Rotate camera on Y axis
        if (!invertedMouseY)
        {
            transform.Rotate(Vector3.left * mouseY);

        } else {
            transform.Rotate(-Vector3.left * mouseY);
        }

        //Rotate player around Y axis (look left to right)
        transform.parent.Rotate(Vector3.up * mouseX);
    }

    private void ClampXRotation(float value) {
        Vector3 eulerRot = transform.eulerAngles;
        eulerRot.x = value;
        transform.eulerAngles = eulerRot;
    }
}
