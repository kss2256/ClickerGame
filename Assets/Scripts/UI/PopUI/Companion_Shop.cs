using UnityEngine;
using UnityEngine.UI;

public class Companion_Shop : UI_Popup
{
    public enum GameObjects
    {
        Exit,
    }


    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        Bind<GameObject>(typeof(GameObjects));
        GetGameObject((int)GameObjects.Exit).gameObject.BindEvent(Shop_Exit, Define.eMouseEvent.Click);


       
        

        return true;
    }


    public void Shop_Exit()
    {
        Managers.UI.ClosePopupUI();
    }


}
