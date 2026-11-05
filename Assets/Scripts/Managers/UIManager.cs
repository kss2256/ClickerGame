using System;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UI;

public class UIManager
{

    int mOrder = -20;


    public GameObject Root
    {
        get
        {
            GameObject root = Util.GetOrAddGameObject("@UI_Root");
            return root;
        }
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

    public void Clear()
    {
      
    }
}