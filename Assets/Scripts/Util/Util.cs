using Unity.VisualScripting;
using UnityEngine;


public class Util
{
    public static T GetOrAddComponent<T>(GameObject _go) where T : Component
    {
        T component = _go.GetComponent<T>();
        if(component == null)
            _go.AddComponent<T>();

        return component;
    }

    public static GameObject GetOrAddGameObject(string _name, bool _dontDestory = false)
    {
        GameObject go = GameObject.Find(_name);
        if(go == null)
        {
            go = new GameObject { name = _name };
        }

        if (_dontDestory)
            GameObject.DontDestroyOnLoad(go);
        return go;
    }


    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (go == null)
            return null;

        if (recursive == false)
        {
            Transform transform = go.transform.Find(name);
            if (transform != null)
                return transform.GetComponent<T>();
        }
        else
        {
            foreach (T component in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }
        }

        return null;
    }

    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(go, name, recursive);
        if (transform != null)
            return transform.gameObject;
        return null;
    }



}