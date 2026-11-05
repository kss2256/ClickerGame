using System;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UI;


public class UI_Base : MonoBehaviour
{

    protected Dictionary<Type, UnityEngine.Object[]> mObjects = new Dictionary<Type, UnityEngine.Object[]>();
     
    protected bool bInit = false;


   protected GameObject GetGameObject(int _idx) { return Get<GameObject>(_idx); }
   protected Image GetImage(int _idx) { return Get<Image>(_idx); }
   protected TextMeshProUGUI GetText(int _idx) { return Get<TextMeshProUGUI>(_idx); }
   protected Button GetButton(int _idx) { return Get<Button>(_idx); }


    public virtual bool Init() 
    {
        if (bInit)
            return false;

        return true;    
    }

    private void Start()
    {
        Init();


    }


    // Type == Enums
    protected void Bind<T>(Type _type) where T : UnityEngine.Object
    {
        string[] Name = Enum.GetNames(_type);

        UnityEngine.Object[] Objects = new UnityEngine.Object[Name.Length];
        mObjects.Add(typeof(T), Objects);


        for (int i = 0; i < Name.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
                Objects[i] = Util.FindChild(gameObject, Name[i], true);
            else
                Objects[i] = Util.FindChild<T>(gameObject, Name[i], true);

            if (Objects[i] == null)
                Debug.Log($"Failed to bind({Name[i]})");
        }


    }


    protected T Get<T>(int _idx) where T : UnityEngine.Object
    {

        UnityEngine.Object[] Object = null;

        if (mObjects.TryGetValue(typeof(T), out Object) == false)
            return null;

        return Object[_idx] as T;

    }





}