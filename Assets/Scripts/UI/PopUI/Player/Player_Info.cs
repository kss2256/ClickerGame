using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static PlayerController;

public class Player_Info : UI_Popup
{

    GameObject mHammer_Cheak = null;
    GameObject mScissors_Cheak = null;
    GameObject mNone_Idle = null;
    GameObject mScissors_Idle = null;
    GameObject mHammer_Idle = null;

    Vector3 mButtonFixSize = Vector3.zero;

    public enum GameObjects
    {
        Hammer_Cheak,
        Scissors_Cheak,
        None_Idle,
        Scissors_Idle,
        Hammer_Idle,
    }

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
        Bind<GameObject>(typeof(GameObjects));


        Info_Init();




        GetButton((int)Buttons.Exit_Button).gameObject.BindEvent(Info_Exit, Define.eMouseEvent.Click);

       

        GetButton((int)Buttons.Hammer_Slot_Button).gameObject.BindEvent
            (() => { ChangeWeapon(eWeapons.HAMMER); }, Define.eMouseEvent.Click);

        GetButton((int)Buttons.Scissors_Slot_Button).gameObject.BindEvent
            (() => { ChangeWeapon(eWeapons.SCISSORS); }, Define.eMouseEvent.Click);

       


        return true;
    }


    public void Info_Init()
    {
        mButtonFixSize = GetImage((int)Images.Hammer_Slot_Image).rectTransform.localScale;


        mHammer_Cheak = GetGameObject((int)GameObjects.Hammer_Cheak);
        mScissors_Cheak = GetGameObject((int)GameObjects.Scissors_Cheak);
        mNone_Idle = GetGameObject((int)GameObjects.None_Idle);
        mHammer_Idle = GetGameObject((int)GameObjects.Hammer_Idle);
        mScissors_Idle = GetGameObject((int)GameObjects.Scissors_Idle);




        PlayerController.eWeapons _weapon = Managers.Battle.PlayerController.Weapon;

        mHammer_Cheak.SetActive(_weapon == eWeapons.HAMMER);
        mScissors_Cheak.SetActive(_weapon == eWeapons.SCISSORS);

        mNone_Idle.SetActive(_weapon == eWeapons.NONE);
        mHammer_Idle.SetActive(_weapon == eWeapons.HAMMER);
        mScissors_Idle.SetActive(_weapon == eWeapons.SCISSORS);

        


    }


    public void Info_Exit()
    {
        Transform imageGo = GetImage((int)Images.Exit_Image).rectTransform;
        imageGo.transform.DOPunchScale(Vector3.one * -0.15f, 0.15f, 5, 0.5f).OnComplete(() => { Managers.UI.ClosePopupUI(); });
    }



    public void ChangeWeapon(PlayerController.eWeapons _weapon)
    {
        Managers.Battle.PlayerController.ChangeWeapon(_weapon);



        Transform imageGo = GetImage((int)_weapon).rectTransform;

        imageGo.DOKill();
        imageGo.transform.localScale = mButtonFixSize;
        imageGo.transform.DOPunchScale(Vector3.one * -0.15f, 0.15f, 5, 0.5f);



        mHammer_Cheak.SetActive(_weapon == eWeapons.HAMMER);
        mScissors_Cheak.SetActive(_weapon == eWeapons.SCISSORS);
        mNone_Idle.SetActive(_weapon == eWeapons.NONE);
        mHammer_Idle.SetActive(_weapon == eWeapons.HAMMER);
        mScissors_Idle.SetActive(_weapon == eWeapons.SCISSORS);
    }



}