using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : Interactable
{
    //El Book se encarga solo de detectar interacciones..

    [Header("change book")]
    public GameObject closedBook;
    public GameObject openBook;

    private bool isOpen = false;
    public bool IsOpen => isOpen;

    [Header("Maps")]
    public Map map;

    //public Texture2D cursorEyes;
    //private ICursorChanger cursorChanger;

    [Space]
    public UIBliblioteca biblioteca;

    protected override void Start()
    {
        //cursorOverTexture = cursorEyes;
        if (openBook != null)
        {
            openBook.SetActive(false);
        }
    }

    public override void Interact()
    {
        OpenBook();
        map.EnableMap();
    }

    private void OpenBook()
    {
        if(closedBook != null)
        {
            closedBook.SetActive(false);
        }

        if (openBook != null)
        {
            openBook.SetActive(true);
        }

        isOpen = true;

        if (biblioteca != null)
        {
            biblioteca.StartDialogue();
        }
    }
}
