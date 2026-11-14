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

        if (mMouseEvent == null)
            return;

        //마우스 터치 이벤트 확인
        bool down = false;
        bool press = false;
        bool up = false;
        bool isUI = false;

        if (Touchscreen.current != null)
        {
            var touch = Touchscreen.current.primaryTouch;

            down = touch.press.wasPressedThisFrame;
            press = touch.press.isPressed;
            up = touch.press.wasReleasedThisFrame;

            if (down && EventSystem.current != null)
            {
                int touchId = touch.touchId.ReadValue();

                isUI = EventSystem.current
                    .IsPointerOverGameObject(touchId);
            }
        }

        else if (Mouse.current != null)
        {
            var mouse = Mouse.current.leftButton;

            down = mouse.wasPressedThisFrame;
            press = mouse.isPressed;
            up = mouse.wasReleasedThisFrame;

            if (down && EventSystem.current != null)
            {
                isUI = EventSystem.current
                    .IsPointerOverGameObject();
            }
        }

        // Down
        if (down)
        {
            bMouseDown = !isUI;
            mPressTime = 0.0f;

            if (bMouseDown)
                mMouseEvent.Invoke(Define.eMouseEvent.Down);
        }

        // Press
        if (press && bMouseDown)
        {
            mPressTime += Time.deltaTime;

            mMouseEvent.Invoke(Define.eMouseEvent.Press);
        }

        // Up
        if (up)
        {
            if (bMouseDown)
            {
                mMouseEvent.Invoke(Define.eMouseEvent.Up);

                if (mPressTime < 0.2f)
                {
                    mMouseEvent.Invoke(Define.eMouseEvent.Click);
                }
            }

            mPressTime = 0.0f;
            bMouseDown = false;
        }


        #region PC Mouse Event
        //if (EventSystem.current.IsPointerOverGameObject())
        //    return;



        //if (mMouseEvent != null && Mouse.current.leftButton.wasPressedThisFrame)
        //{
        //    bMouseDown = true;

        //    mMouseEvent.Invoke(Define.eMouseEvent.Down);
        //}
        //if (mMouseEvent != null && Mouse.current.leftButton.isPressed)
        //{
        //    if (bMouseDown)
        //        mPressTime += Time.deltaTime;

        //    mMouseEvent.Invoke(Define.eMouseEvent.Press);
        //}
        //if (mMouseEvent != null && Mouse.current.leftButton.wasReleasedThisFrame)
        //{

        //    mMouseEvent.Invoke(Define.eMouseEvent.Up);

        //    if (mPressTime < 0.2f && bMouseDown)
        //    {
        //        mMouseEvent.Invoke(Define.eMouseEvent.Click);
        //    }

        //    mPressTime = 0.0f;
        //    bMouseDown = false;
        //}

        #endregion


    }


    public void Clear()
    {
        mMouseEvent = null;
     
    }

}