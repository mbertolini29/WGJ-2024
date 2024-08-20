using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICursorChanger
{
    void ChangeCursor(Texture2D cursorTexture, Vector2 hotspot);
    void ResetCursor();
}
