using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {

	[SerializeField] private GameObject dialogueBox;
	[SerializeField] private Text nameText, dialogueText;
	private bool inDialogue;
	private Queue<string> sentences;

	private void Start () {
		sentences = new Queue<string>();
	}

	private void Update () {
		if((inDialogue))
		{
			dialogueBox.SetActive(true);

			if(Input.GetButtonDown("Interact"))
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
		dialogueText.text = sentence;
	}

	private void EndDialogue () {
		inDialogue = false;
	}
}
