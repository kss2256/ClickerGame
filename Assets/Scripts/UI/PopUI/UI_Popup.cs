using UnityEngine;


public class UI_Popup : UI_Base
{

    protected GameObject mPrevPopup;


    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        Managers.UI.SetCanvas(gameObject, true);
        return true;
    }

    public virtual void ClosePopupUI()
    {
        mPrevPopup = null;
        Managers.UI.ClosePopupUI(this);
    }


    public virtual void SetPrevPopup(GameObject _go)
    {
        mPrevPopup = _go;
    }
    





}