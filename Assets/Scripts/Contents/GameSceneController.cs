using UnityEngine;
using UnityEngine.InputSystem;


public class GameSceneController : MonoBehaviour
{

    void Start()
    {
        //TODO UI_Game 만들어야 함
        Managers.UI.ShowSceneUI<UI_Game>("UI_Game");


        Managers.Resource.Instantiate("Prefabs/Contents/BackGround");        
        Util.GetOrAddGameObject("Player").GetOrAddComponent<PlayerController>();


        //TODO Companion 구매시 생성으로 변경 해야함 Test용
        Util.GetOrAddGameObject("CloverSoldier").GetOrAddComponent<CloverSoldier>();
        Util.GetOrAddGameObject("SpadeSoldier").GetOrAddComponent<SpadeSoldier>();

    }


    void Update()
    {



       


    }

}