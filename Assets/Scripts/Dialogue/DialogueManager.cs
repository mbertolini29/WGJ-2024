using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{    
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Button continueDialogueButton;
    public Button changeSceneButton;
    public GameObject dialogueUI;

    private Queue<string> sentences;
    private List<string> characterNames;
    private bool isTyping = false;
    private int nameIndex = 0;

    private void Start()
    {
        sentences = new Queue<string>();
        characterNames = new List<string>();
        changeSceneButton.gameObject.SetActive(false);
        dialogueUI.SetActive(false);
    }

    private void Update()
    {
        //enter para el dialogo.
        if (Input.GetKeyDown(KeyCode.Return) && !isTyping) 
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(DialogueSO dialogue)
    {
        dialogueUI.SetActive(true);
        sentences.Clear();
        characterNames.Clear();
        nameIndex = 0;


        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (string characterName in dialogue.characterNames)
        {
            characterNames.Add(characterName);
        }

        DisplayNextSentence();   
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        if(nameIndex >= characterNames.Count)
        {
            nameIndex = 0;
        }

        string sentence = sentences.Dequeue();
        string characterName = characterNames[nameIndex];

        nameText.text = characterName;
        nameIndex++;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    //escribe el dialogo letra por letra.
    IEnumerator TypeSentence (string sentence) 
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        isTyping = false;
    }

    void EndDialogue()
    {
        dialogueUI.SetActive(false);
        changeSceneButton.gameObject.SetActive(true);
        NPC npc = FindObjectOfType<NPC>();
        if(npc != null)
        {
            npc.OnDialogueEnd?.Invoke();
        }
    }
}
