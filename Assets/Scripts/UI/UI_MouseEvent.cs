using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class UI_MouseEvent : MonoBehaviour, IPointerClickHandler , IPointerDownHandler
{

    public Action mOnClickEvent = null;
    public Action mOnDownEvent = null;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (mOnClickEvent != null)
            mOnClickEvent.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (mOnDownEvent != null)
            mOnDownEvent.Invoke();
    }
}