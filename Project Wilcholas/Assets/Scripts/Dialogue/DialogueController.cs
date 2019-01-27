using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour {

	private bool inDialogue;
	private Queue<string> sentences;

	private void Start () {
		sentences = new Queue<string>();
	}

	private void Update () {
		if((inDialogue) && (Input.GetButtonDown("Interact")))
		{
			DisplayNextSentence();
		}
	}

	public void StartDialogue (Dialogue dialogue) {
		inDialogue = true;
		Debug.Log("Starting conversation with " + dialogue.name);
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
		Debug.Log(sentence);
	}

	private void EndDialogue () {
		inDialogue = false;
		Debug.Log("Conversation over");
	}
}
