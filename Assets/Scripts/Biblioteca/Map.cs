using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : Interactable
{
    private Collider2D collider2D;
    public Book book;
    public GameObject mapOpen;
    public GameObject enterButton;
    public GameObject clearOpen;
    public GameObject ocultarDialogo;

    public PuzzleManager puzzlemanager;
    public CursorManager cursorManager;

    protected override void Start()
    {
        collider2D = GetComponent<Collider2D>();
        if(collider2D != null)
        {
            collider2D.enabled = false;
        }
        
        if(mapOpen != null)
        {
            mapOpen.SetActive(false);
            enterButton.SetActive(false);
            clearOpen.SetActive(false);
        }
    }

    public void EnableMap()
    {
        if (collider2D != null)
        {
            collider2D.enabled = true;
        }
    }

    public override void Interact()
    {
        if(collider2D != null && book.IsOpen)
        {
            //EnableMap();
            //mostrar el mapa en grande una vez que lo clickeo...
            ocultarDialogo.SetActive(false);
            mapOpen.SetActive(true);
            enterButton.SetActive(true);
            clearOpen.SetActive(true);
            puzzlemanager.ClearSlots();

            //
            book.IsOpen = false;
            
            //
            isOpenBook = true;
            cursorManager.ResetCursor();

        }
    }

  
}
