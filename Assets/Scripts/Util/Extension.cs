using System;
using UnityEditor;
using UnityEngine;


public static class Extension
{
    public static T GetOrAddComponent<T>(this GameObject _go) where T : UnityEngine.Component
    {
        T component = _go.GetComponent<T>();
        if (component == null)
            component = _go.AddComponent<T>();

        return component;
    }

  
    public static void BindEvent(this GameObject _go, Action _action, Define.eMouseEvent _event)
    {
        UI_Base.BindEvent(_go, _action, _event);
    }


}