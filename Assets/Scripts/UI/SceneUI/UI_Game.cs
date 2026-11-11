using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UI_Title;

public class UI_Game : UI_Scene
{

    public enum Buttons
    {
        Player_Button,
        Companion_Button
    }



    public override bool Init()
    {
        if (base.Init() == false)
            return false;


        Bind<Button>(typeof(Buttons));
        GetButton((int)Buttons.Player_Button).gameObject.BindEvent(Test, Define.eMouseEvent.Click);

        GetButton((int)Buttons.Companion_Button).gameObject.BindEvent(Companion_ShopOpen, Define.eMouseEvent.Click);

        return true;
    }

    public void Companion_ShopOpen()
    {
        Managers.UI.ShowPopUpUI<Companion_Shop>("Prefabs/UI/Popup/Companion_Shop");




    }
    public void Test()
    {
        Debug.Log("플레이어 버튼");
    }


    private void Update()
    {

        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            Managers.UI.ClosePopupUI();
        }

    }


}
