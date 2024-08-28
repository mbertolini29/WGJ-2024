using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
    //con imagenes..
    public Image[] letterSlots;
    public List<Sprite> allLetterSprites;
    private Dictionary<char, Sprite> letterDictionary;
    private int currentSlotIndex = 0;

    //palabra objeto.
    public Button[] letterButtons;
    private string targetWord = "TIEMPO";
    private string formedWord = "";

    //
    [Header("change book")]
    public GameObject closedBook;
    public GameObject openBook;
    public GameObject mapOpen;
    public GameObject feebBackCorrect;
    public GameObject feebBackInCorrect; 
    public GameObject panelDictionary;
    public GameObject panelAreaCheck;
    public GameObject enterButton;
    public GameObject clearButton;

    private void Start()
    {
        letterDictionary = new Dictionary<char, Sprite>();

        // Asigna manualmente cada letra a su sprite correspondiente
        letterDictionary.Add('T', allLetterSprites[0]); 
        letterDictionary.Add('I', allLetterSprites[1]); 
        letterDictionary.Add('E', allLetterSprites[2]); 
        letterDictionary.Add('M', allLetterSprites[3]); 
        letterDictionary.Add('P', allLetterSprites[4]); 
        letterDictionary.Add('O', allLetterSprites[5]); 
    }

    public void OnLetterButtonClicked(Button buttonLetter)
    {
        char letter = buttonLetter.GetComponentInChildren<TMP_Text>().text[0];

        if (currentSlotIndex < letterSlots.Length && letterDictionary.ContainsKey(letter))
        {
            letterSlots[currentSlotIndex].sprite = letterDictionary[letter];
            letterSlots[currentSlotIndex].enabled = true;
            formedWord += letter;
            currentSlotIndex++;
        }

        buttonLetter.enabled = false;
    }

    public void CheckWord()
    {
        if(formedWord == targetWord)
        {
            //frena el tiempo.
            GameManager.Instance.StopTimer();

            feebBackCorrect.SetActive(true);
            
            //cerrar el libro.
            closedBook.SetActive(true);

            //activa el boton de bosque...

            //
            mapOpen.SetActive(false);
            openBook.SetActive(false);
            panelAreaCheck.SetActive(false);

            //
            Change("BosqueFinish");
        }
        else
        {
            feebBackInCorrect.SetActive(true);
        }
    }

    public void ClearSlots()
    {
        foreach (Image slot in letterSlots)
        {
            slot.sprite = null;
            slot.enabled = false;
        }

        formedWord = "";
        currentSlotIndex = 0;

        for (int i = 0; i < letterButtons.Length; i++)
        {
            letterButtons[i].enabled = true;
        }

    }

    public void Change(string sceneName)
    {
        StartCoroutine(PlaySoundAndChangeScene(sceneName));
    }

    private IEnumerator PlaySoundAndChangeScene(string sceneName)
    {
        //audioSource.Play();

        // Espera hasta que el sonido termine de reproducirse
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(sceneName);
    }
}
