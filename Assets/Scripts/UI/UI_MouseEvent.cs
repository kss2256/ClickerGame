using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class UI_MouseEvent : MonoBehaviour, IPointerClickHandler
{

    public Action mOnClickEvent = null;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (mOnClickEvent != null)
            mOnClickEvent.Invoke();
    }
}