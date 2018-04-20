using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public static GameObject draggedItem;
    public static Vector3 startDragPosition;
    public static Transform startParent;
    public static Transform canvas;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        draggedItem = gameObject;
        startDragPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        canvas = GameObject.FindGameObjectWithTag("UI Canvas").transform;
        transform.parent = canvas;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        draggedItem = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent == canvas)
        {
            transform.position = startDragPosition;
            transform.parent = startParent;
        }
    }
}
