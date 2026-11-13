using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Companion_Shop : UI_Popup
{
    public enum GameObjects
    {
        Exit,
    }
    public enum Images
    {
        Exit_Image,
    }


    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        GetGameObject((int)GameObjects.Exit).gameObject.BindEvent(Shop_Exit, Define.eMouseEvent.Click);


       
        

        return true;
    }


    public void Shop_Exit()
    {
        Transform imageGo = GetImage((int)Images.Exit_Image).rectTransform;
        imageGo.transform.DOPunchScale(Vector3.one * -0.15f, 0.15f, 5, 0.5f).OnComplete(() => { Managers.UI.ClosePopupUI(); });

    }


}
