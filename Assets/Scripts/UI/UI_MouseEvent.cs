using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class UI_MouseEvent : MonoBehaviour, IPointerClickHandler , IPointerDownHandler , IPointerUpHandler
{

    public Action mOnClickEvent = null;
    public Action mOnDownEvent = null;
    public Action mOnUpEnent = null;


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

    public void OnPointerUp(PointerEventData eventData)
    {
        if (mOnUpEnent != null)
            mOnUpEnent.Invoke();

    }
}