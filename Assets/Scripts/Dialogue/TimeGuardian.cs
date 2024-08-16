using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGuardian : MonoBehaviour
{

    public string[] dialogueMessages;
    //private int currentDialogueIndex = 0;

    private DialogueManager dialogueManager;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void OnMouseDown()
    {
        StartDialogue();
    }

    void StartDialogue()
    {
        if(dialogueManager != null)
        {
            //dialogueManager.ShowDialogue(dialogueMessages[currentDialogueIndex]);
            //currentDialogueIndex = (currentDialogueIndex + 1) % dialogueMessages.Length;
        }
    }
}
