using UnityEngine;
using UnityEngine.InputSystem;


public class GameSceneController : MonoBehaviour
{

    void Start()
    {
        //TODO UI_Game 만들어야 함
        Managers.UI.ShowSceneUI<UI_Game>("UI_Game");
    }


    void Update()
    {

        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            Define.eSceneType curScene = Managers.Scene.CurentScene;

            if (curScene == Define.eSceneType.GameScene)
                Managers.Scene.ChangeScene(Define.eSceneType.TiTleScene);

        }





    }

}