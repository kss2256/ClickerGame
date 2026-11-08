using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputManager
{

    public Action<Define.eMouseEvent> mMouseEvent = null;
   

    bool bMouseDown = false;
    float mPressTime = 0.0f;

    public void OnUpdate()
    {


        if (EventSystem.current.IsPointerOverGameObject())
            return;



        if (mMouseEvent != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            bMouseDown = true;

            mMouseEvent.Invoke(Define.eMouseEvent.Down);
        }
        if (mMouseEvent != null && Mouse.current.leftButton.isPressed)
        {
            if (bMouseDown)
                mPressTime += Time.deltaTime;

            mMouseEvent.Invoke(Define.eMouseEvent.Press);
        }
        if (mMouseEvent != null && Mouse.current.leftButton.wasReleasedThisFrame)
        {

            mMouseEvent.Invoke(Define.eMouseEvent.Up);

            if (mPressTime < 0.2f && bMouseDown)
            {
                mMouseEvent.Invoke(Define.eMouseEvent.Click);
            }

            mPressTime = 0.0f;
            bMouseDown = false;
        }
      

    }


    public void Clear()
    {
        mMouseEvent = null;
     
    }

}