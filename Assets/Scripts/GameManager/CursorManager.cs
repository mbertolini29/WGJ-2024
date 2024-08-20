using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour, ICursorChanger
{
    [SerializeField] Texture2D normalCursor;
    [SerializeField] Vector2 hotspot = Vector2.zero; //hotspot = punto activo.
    [SerializeField] CursorMode cursorMode = CursorMode.Auto;
    //[Space]
    //[SerializeField] float cursorScale = 0.75f; // 1f , es la original.

    void Start()
    {
        //Texture2D resizedCursor = ResizeTexture(cursorSprite, cursorScale);
        Cursor.SetCursor(normalCursor, hotspot, cursorMode);
        Cursor.visible = true;
    }

    public void ChangeCursor(Texture2D cursorTexture, Vector2 hotspot)
    {
        Cursor.SetCursor(cursorTexture, hotspot, cursorMode);
    }

    public void ResetCursor()
    {
        Cursor.SetCursor(normalCursor, hotspot, cursorMode);
    }

    private Texture2D ResizeTexture(Texture2D originalTexture, float scale)
    {
        int newWidth = Mathf.RoundToInt(originalTexture.width * scale);
        int newHeight = Mathf.RoundToInt(originalTexture.height * scale);

        Texture2D resizedTexture = new Texture2D(newWidth, newHeight);
        Color[] pixels = originalTexture.GetPixels(0, 0, originalTexture.width, originalTexture.height);
        Color[] resizedPixels = resizedTexture.GetPixels(0, 0, newWidth, newHeight);

        for (int y = 0; y < newHeight; y++)
        {
            for (int x = 0; x < newWidth; x++)
            {
                int newX = Mathf.RoundToInt(x / scale);
                int newY = Mathf.RoundToInt(y / scale);
                resizedPixels[y * newWidth + x] = pixels[newY * originalTexture.width + newX];
            }
        }

        resizedTexture.SetPixels(resizedPixels);
        resizedTexture.Apply();

        return resizedTexture;
    }

}
