using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : Interactable
{
    private Collider2D collider2D;
    public Book book;
    public GameObject mapOpen;

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
            mapOpen.SetActive(true);
        }
    }

  
}
