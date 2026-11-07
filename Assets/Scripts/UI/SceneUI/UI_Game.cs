using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static UI_Title;

public class UI_Game : UI_Scene
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;




        return true;
    }

    private void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            Managers.Scene.ChangeScene(Define.eSceneType.TiTleScene);
        }

    }


}
