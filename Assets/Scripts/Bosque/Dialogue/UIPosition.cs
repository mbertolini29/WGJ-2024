using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPosition : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset;  
    public RectTransform uiElement;  

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        Vector3 screenPos = cam.WorldToScreenPoint(target.position + offset);
        uiElement.position = screenPos;
    }
}