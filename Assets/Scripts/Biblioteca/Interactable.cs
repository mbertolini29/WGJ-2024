using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract void Interact();

    [Header("change cursor")]
    public Texture2D cursorEyes;
    private ICursorChanger cursorChanger;

    protected virtual void Start()
    {
        cursorChanger = FindObjectOfType<CursorManager>();
        if (cursorChanger == null)
        {
            Debug.LogError("cursormanager no encontrado en la escena.");
        }
    }

    private void OnMouseEnter()
    {
        cursorChanger = FindObjectOfType<CursorManager>();
        if (cursorChanger != null && cursorEyes != null)
        {
            cursorChanger.ChangeCursor(cursorEyes, Vector2.zero);
        }
    }

    private void OnMouseExit()
    {
        cursorChanger = FindObjectOfType<CursorManager>();
        if (cursorChanger != null)
        {
            cursorChanger.ResetCursor();
        }
    }
}
