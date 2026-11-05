using UnityEngine;


public static class Extension
{
    public static T GetOrAddComponent<T>(this GameObject _go) where T : Component
    {
        T component = _go.GetComponent<T>();
        if (component == null)
            _go.AddComponent<T>();

        return component;
    }





}