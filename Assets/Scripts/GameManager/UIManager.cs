using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

public class UIManager : MonoBehaviour
{
    public NPC npc;
    public GameObject dialogueBox;
    public GameObject talkUI;

    [Header("Follow Canvas")]
    public Transform npcTransform;
    public RectTransform uiElement;
    public Vector3 offset; //-0.5f, 1.75, 0
    public Canvas canvas;

    private void Start()
    {
        if(talkUI != null)
        {
            talkUI.SetActive(false);
        }

        //if (dialogueBox != null)
        //{
        //    dialogueBox.SetActive(false);
        //}
    }

    private void OnDestroy()
    {
        if (npc != null)
        {
            npc.OnPlayerEnterRange.RemoveListener(ShowInteractText);
            npc.OnPlayerExitRange.RemoveListener(HideInteractText);
        }
    }

    // Método para conectar el NPC con este UIManager
    public void SetNPC(NPC newNpc)
    {
        if (npc != null)
        {
            npc.OnPlayerEnterRange.RemoveListener(ShowInteractText);
            npc.OnPlayerExitRange.RemoveListener(HideInteractText);
        }

        npc = newNpc;

        if (npc != null)
        {
            npc.OnPlayerEnterRange.AddListener(ShowInteractText);
            npc.OnPlayerExitRange.AddListener(HideInteractText);
        }
    }

    public void ShowInteractText()
    {
        if (talkUI != null)
        {
            UpdatePosTalkUI();
            talkUI.SetActive(true);
        }
        else
        {
            Debug.LogWarning("text no está asignado.");
        }
    }

    void UpdatePosTalkUI() //actualiza la pos de la ui
    {
        if (npcTransform != null && uiElement != null && canvas != null)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(npcTransform.position + offset);

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                screenPos,
                canvas.worldCamera,
                out Vector2 canvasPosition
            );

            uiElement.anchoredPosition = canvasPosition;
        }
    }

    public void HideInteractText()
    {
        if (talkUI != null)
        {
            talkUI.SetActive(false);
        }
        else
        {
            Debug.LogWarning("text no está asignado.");
        }
    }
}