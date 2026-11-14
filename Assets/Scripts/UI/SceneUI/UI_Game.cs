using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using static UI_Title;

public class UI_Game : UI_Scene
{


    private Companion_Shop mIsShop = null;
    private Player_Info mIsInfo = null;

    

    private Vector3 mButtonFixSize = Vector3.zero;

    public enum Buttons
    {
        Player_Button,
        Companion_Button
    }

    public enum Images
    {
        Player_ButtonImage,
        Companion_ButtonImage,
    }
 

    public override bool Init()
    {
        if (base.Init() == false)
            return false;


        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));

        mButtonFixSize = GetImage((int)Images.Player_ButtonImage).transform.localScale;

        GetButton((int)Buttons.Player_Button).gameObject.BindEvent(Player_InfoOpen, Define.eMouseEvent.Click);

        GetButton((int)Buttons.Companion_Button).gameObject.BindEvent(Companion_ShopOpen, Define.eMouseEvent.Click);

        


        return true;
    }


    public void Companion_ShopOpen()
    {
        if (null == mIsShop)
        {

            Transform tr = GetImage((int)Images.Companion_ButtonImage).rectTransform;
            
            tr.DOKill();
            tr.localScale = mButtonFixSize;

            if(mIsInfo)
                Managers.UI.ClosePopupUI();

            tr.DOPunchScale(Vector3.one * -0.15f, 0.30f, 5, 0.5f).OnComplete
                (() => { mIsShop = Managers.UI.ShowPopUpUI<Companion_Shop>("Prefabs/UI/Popup/Companion_Shop"); });

        }
        


    }
    public void Player_InfoOpen()
    {

        if (null == mIsInfo)
        {
            Transform tr = GetImage((int)Images.Player_ButtonImage).rectTransform;

            tr.DOKill();
            tr.localScale = mButtonFixSize;

            if (mIsShop)
                Managers.UI.ClosePopupUI();

            tr.DOPunchScale(Vector3.one * -0.15f, 0.30f, 5, 0.5f).OnComplete
                (() => { mIsInfo = Managers.UI.ShowPopUpUI<Player_Info>("Prefabs/UI/Popup/Player_Info"); });
        }



    }



}
