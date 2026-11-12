using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Companion_Shop;

public class Companion_Panel : UI_Base
{

    


    enum GameObjects
    {
        CloverSoldier_Button,
    }


    public override bool Init()
    {
        if (base.Init() == false)
            return false;

       Bind<GameObject>(typeof(GameObjects));
       GetGameObject((int)GameObjects.CloverSoldier_Button).gameObject.BindEvent(CloverSoldier_Shop, Define.eMouseEvent.Click);





        return true;
    }



    public void CloverSoldier_Shop()
    {
        GameObject go = GetComponentInParent<Companion_Shop>().gameObject;

        Managers.UI.ShowPopUpUI<CloverSoldier_Shop>("Prefabs/UI/Popup/CloverSoldier_Shop").SetPrevPopup(go);

        go.SetActive(false);
        

    }


    

}
