using TMPro;
using UnityEngine;

public class CloverSoldier_Shop : UI_Popup
{


    public enum GameObjects
    {
        Exit,
    }


    public enum Texts
    {
        Level_Text,
        Attack_Text,
        AttackSpeed_Text,
        Price_Text,
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        Bind<GameObject>(typeof(GameObjects));
        GetGameObject((int)GameObjects.Exit).gameObject.BindEvent(Shop_Exit, Define.eMouseEvent.Click);

        Bind<TextMeshProUGUI>(typeof(Texts));
        ShopInfo();

        return true;
    }

    public void ShopInfo()
    {
        //TODO 다녀와서 용병 정보 끌어와서 Text 셋팅하기!
    




    }


    public void Shop_Exit()
    {
        Managers.UI.ClosePopupUI();

        if (mPrevPopup != null)
            mPrevPopup.SetActive(true);

    }


}
