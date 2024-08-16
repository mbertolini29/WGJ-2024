using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class NPC : MonoBehaviour
{
    public DialogueSO dialogue;

    [Header("NPC Events")]
    public UnityEvent OnPlayerEnterRange;
    public UnityEvent OnPlayerExitRange;
    public UnityEvent OnDialogueStart;
    public UnityEvent OnDialogueEnd;

    private bool isPlayerInRange = false;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();            
        }
    }

    public void TriggerDialogue() //trigger = activar
    {
        OnDialogueStart?.Invoke();
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            OnPlayerEnterRange?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false; 
            OnPlayerExitRange?.Invoke();
        }
    }
}