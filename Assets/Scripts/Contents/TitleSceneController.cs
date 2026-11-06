using UnityEngine;
using UnityEngine.InputSystem;

public class TitleSceneController : MonoBehaviour
{


   

    void Start()
    {
        Managers.UI.ShowSceneUI<UI_Title>("UI_Title");
    }


    void Update()
    {

        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            Define.eSceneType curScene = Managers.Scene.CurentScene;

            if (curScene == Define.eSceneType.TiTleScene)
                Managers.Scene.ChangeScene(Define.eSceneType.GameScene);
            
        }



    }
}
