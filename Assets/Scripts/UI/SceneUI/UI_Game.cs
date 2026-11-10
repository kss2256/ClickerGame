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

        GetButton((int)Buttons.Companion_Button).gameObject.BindEvent(TESET, Define.eMouseEvent.Click);

        return true;
    }

    public void TESET()
    {
        Debug.Log("용병 버튼");
    }
    public void Test()
    {
        Debug.Log("플레이어 버튼");
    }


    private void Update()
    {

        //if (Keyboard.current.qKey.wasPressedThisFrame)
        //{
        //    Managers.Scene.ChangeScene(Define.eSceneType.TiTleScene);
        //}

    }


}
