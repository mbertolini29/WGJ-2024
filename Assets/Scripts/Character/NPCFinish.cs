using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCFinish : MonoBehaviour
{
    public DialogueSO dialogue;

    [Header("NPC Events")]
    //public UnityEvent OnPlayerEnterRange;
    //public UnityEvent OnPlayerExitRange;
    public UnityEvent OnDialogueStart;
    //public UnityEvent OnDialogueEnd;

    //private bool isPlayerInRange = false;

    private void Start()
    {
        TriggerDialogue();        
    }

    public void TriggerDialogue() //trigger = activar
    {
        OnDialogueStart?.Invoke();
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}