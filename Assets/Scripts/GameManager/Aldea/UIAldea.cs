using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAldea : MonoBehaviour
{
    public GameObject dialogueBox;    

    [Header("Follow Canvas")]
    public Transform npcTransform;
    public RectTransform uiElement;
    public Vector3 offset; //-0.5f, 1.75, 0
    public Canvas canvas;

    private void Update()
    {
    }

    private void Start()
    {
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false);
        }

        UpdatePosButtonUI();

        StartCoroutine(ShowDialogueAfterDelay(1f));
    }

    IEnumerator ShowDialogueAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartDialogue();
    }

    public void StartDialogue()
    {
        if (dialogueBox != null)
        {
            //UpdatePosButtonUI();
            dialogueBox.SetActive(true);
        }
    }

    void UpdatePosButtonUI() //actualiza la pos de la ui
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
}
