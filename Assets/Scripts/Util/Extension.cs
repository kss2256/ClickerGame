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

  



}