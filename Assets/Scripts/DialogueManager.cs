using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText;

    public void ShowDialogue(string message)
    {
        dialogueText.text = message;
    }
}
