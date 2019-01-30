using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {

	[SerializeField] private GameObject dialogueBox;
	public Text nameText, dialogueText;
	private bool inDialogue;
	private Queue<string> sentences;

	private void Start () {
		sentences = new Queue<string>();
	}

	private void Update () {
		if((inDialogue))
		{
			FindObjectOfType<GameController>().isPaused = true;
			dialogueBox.SetActive(true);

			if(Input.GetMouseButtonDown(0))
			{
				DisplayNextSentence();
			}

		} else {
			dialogueBox.SetActive(false);
		}
	}

	public void StartDialogue (Dialogue dialogue) {
		inDialogue = true;
		nameText.text = dialogue.name;
		sentences.Clear();
		
		foreach(string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence(); 
	}

	private void DisplayNextSentence () {
		if(sentences.Count == 0)
		{
			EndDialogue();
			return;
		}
		
		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	private void EndDialogue () {
		inDialogue = false;
		FindObjectOfType<GameController>().isPaused = false;
	}

	private IEnumerator TypeSentence (string sentence) {
		dialogueText.text = "";

		foreach(char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}
}
