using DATA;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class GameSceneController : MonoBehaviour
{

    void Start()
    {
        //TODO UI_Game 만들어야 함
        Managers.UI.ShowSceneUI<UI_Game>("UI_Game");


        Managers.Resource.Instantiate("Prefabs/Contents/BackGround");


        Managers.Battle.CreatePlayer();


        //TODO Companion 구매시 생성으로 변경 해야함 Test용 Right
        //Util.GetOrAddGameObject("Chef").GetOrAddComponent<Chef>();
        //Util.GetOrAddGameObject("CloverSoldier").GetOrAddComponent<CloverSoldier>();
        //Util.GetOrAddGameObject("Judge").GetOrAddComponent<Judge>();
        //Util.GetOrAddGameObject("Sandglass").GetOrAddComponent<Sandglass>();

        // Left
        //Util.GetOrAddGameObject("SpadeSoldier").GetOrAddComponent<SpadeSoldier>();
        //Util.GetOrAddGameObject("Turnip").GetOrAddComponent<Turnip>();
        //Util.GetOrAddGameObject("King").GetOrAddComponent<King>();
        //Util.GetOrAddGameObject("Clown").GetOrAddComponent<Clown>();


        Managers.Battle.CreateCompanion(Define.eCharacterType.CloverSoldier);
        Managers.Battle.CreateCompanion(Define.eCharacterType.Chef);

       



    }


    void Update()
    {



       


    }

}