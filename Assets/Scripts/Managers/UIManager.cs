using System;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UI;

public class UIManager
{

    int mOrder = -20;
    public UI_Scene mUI_Scene { get; private set; }


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

        if (go.GetComponent<Canvas>())
        {
            SetCanvas(go, false);
        }

        go.transform.SetParent(Root.transform, false);
        mUI_Scene = sceneUI;

        return sceneUI;
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


        ClosePopupUI();
    }

    public void ClosePopupUI()
    {

    }

    public void CloseAllPopupUI()
    {

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

        return canvas;
    }

    public void Clear()
    {

        
        mUI_Scene = null;
    }
}