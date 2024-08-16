using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue/Basic Dialogue")]
public class DialogueSO : ScriptableObject
{
    [Header("Conversation Details")]
    public string[] characterNames;
    [Space]
    [TextArea(3, 10)]
    public string[] sentences;
}
