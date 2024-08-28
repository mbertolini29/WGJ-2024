using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAldea : MonoBehaviour
{
    public GameObject dialogueBox;    

    [Header("Follow Canvas")]
    public Transform bibliotecaTransform;
    public Transform aldeaTransform;
    public RectTransform uiBibliotecaElement;
    public RectTransform uiElement;
    public Vector3 offset; //-0.5f, 1.75, 0
    public Vector3 offset2; //-0.5f, 1.75, 0
    public Canvas canvas;

    private void Start()
    {
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false);
        }

        GameManager.Instance.StartTimer();

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

    private void Update()
    {
        UpdatePosButtonUI();
        UpdatePosButtonAldeaUI();
    }

    void UpdatePosButtonUI() //actualiza la pos de la ui
    {
        if (bibliotecaTransform != null && uiBibliotecaElement != null && canvas != null)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(bibliotecaTransform.position + offset);

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                screenPos,
                canvas.worldCamera,
                out Vector2 canvasPosition
            );

            uiBibliotecaElement.anchoredPosition = canvasPosition;
        }
    }

    void UpdatePosButtonAldeaUI() //actualiza la pos de la ui
    {
        if (aldeaTransform != null && uiElement != null && canvas != null)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(aldeaTransform.position + offset2);

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
