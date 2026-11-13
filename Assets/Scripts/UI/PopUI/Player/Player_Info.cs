using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static PlayerController;

public class Player_Info : UI_Popup
{


    public enum Images
    {
        Player_Info_Image,
        Exit_Image,
        Hammer_Slot_Image,
        Scissors_Slot_Image,
    }

    public enum Buttons
    {
        Exit_Button,
        Hammer_Slot_Button,
        Scissors_Slot_Button,
    }




    public override bool Init()
    {
        if (base.Init() == false)
            return false;


        Bind<Image>(typeof(Images));
        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.Exit_Button).gameObject.BindEvent(Info_Exit, Define.eMouseEvent.Click);

        PlayerController po = Managers.Battle.PlayerController;

        GetButton((int)Buttons.Hammer_Slot_Button).gameObject.BindEvent
            (() => { Managers.Battle.PlayerController.ChangeWeapon(eWeapons.HAMMER); }, Define.eMouseEvent.Click);

        GetButton((int)Buttons.Scissors_Slot_Button).gameObject.BindEvent
            (() => { Managers.Battle.PlayerController.ChangeWeapon(eWeapons.SCISSORS); }, Define.eMouseEvent.Click);




        return true;
    }


    public void Info_Exit()
    {
        Transform imageGo = GetImage((int)Images.Exit_Image).rectTransform;
        imageGo.transform.DOPunchScale(Vector3.one * -0.15f, 0.15f, 5, 0.5f).OnComplete(() => { Managers.UI.ClosePopupUI(); });
    }





}