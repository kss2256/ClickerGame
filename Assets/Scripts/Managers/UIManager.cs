using System;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UI;

public class UIManager
{

    int mOrder = 20;
    public UI_Scene mUI_Scene { get; private set; }

    Stack<UI_Popup> mPopupStack = new Stack<UI_Popup>();


    public GameObject Root
    {
        get
        {
            GameObject root = Util.GetOrAddGameObject("@UI_Root");
            return root;
        }
    }

    public T ShowSceneUI<T>(string _name = null) where T : UI_Scene
    {

        if (string.IsNullOrEmpty(_name))
            _name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"Prefabs/UI/Scene/{_name}");
        T sceneUI = go.GetOrAddComponent<T>();
           

        go.transform.SetParent(Root.transform, false);
        mUI_Scene = sceneUI;

        return sceneUI;
    }

    public T ShowPopUpUI<T>(string _path, string _name = null) where T : UI_Popup
    {

        if (string.IsNullOrEmpty(_name))
            _name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate(_path);


        T PopUp = Util.GetOrAddComponent<T>(go);
        mPopupStack.Push(PopUp);

        go.transform.SetParent(Root.transform);


        return PopUp;
    }

    public void SetCanvas(GameObject _go, bool _sort = true)
    {
        Canvas canvas = CanvasSetting(_go);

        if (_sort)
        {
            canvas.sortingOrder = mOrder;
            mOrder++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }


    public void ClosePopupUI(UI_Popup popup)
    {
        if (mPopupStack.Count <= 0)
            return;

        if (mPopupStack.Peek() != popup)
        {
            Debug.Log("Close PopUp Failed");
            return;
        }

        ClosePopupUI();
    }

    public void ClosePopupUI()
    {
        if (mPopupStack.Count <= 0)
            return;

        UI_Popup popup = mPopupStack.Pop();
        Managers.Resource.Destory(popup.gameObject);


        --mOrder;

    }

    public void CloseAllPopupUI()
    {
        while (mPopupStack.Count > 0)
            ClosePopupUI();
    }

    private Canvas CanvasSetting(GameObject _go)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(_go);

        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        CanvasScaler canvasScaler = Util.GetOrAddComponent<CanvasScaler>(_go);
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvasScaler.referenceResolution = new Vector2(1080, 1920);
        canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        canvasScaler.matchWidthOrHeight = 0.5f;
        canvasScaler.referencePixelsPerUnit = 100f;

        Util.GetOrAddComponent<GraphicRaycaster>(_go);

        return canvas;
    }

    public void Clear()
    {
        CloseAllPopupUI();

        mOrder = 0;
        mUI_Scene = null;
    }
}