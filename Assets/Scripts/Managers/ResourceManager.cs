using Unity.VisualScripting;
using UnityEngine;


public class ResourceManager
{

    public T Load<T>(string _path) where T : Object
    {

        T resource = Resources.Load<T>(_path);


        if (resource == null)
        {
            Debug.Log($"Resource Load Fail {_path}");
        }


        return resource;
    }

    public GameObject Instantiate(string _path, Transform _parent = null)
    {
        GameObject original = Load<GameObject>(_path);

        if (original == null)
        {
            Debug.Log($"Resource Instantiate Fail {_path}");
        }

        
        //clone 이름 덮어쓰기!
        GameObject go = GameObject.Instantiate(original, _parent);
        go.name = original.name; 


        return go;
    }


    public void Destory(GameObject go, float _time = 0.0f)
    {

        if (go == null)
            return;

        Object.Destroy(go, _time);
    }



}