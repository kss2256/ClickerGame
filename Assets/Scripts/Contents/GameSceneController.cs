using DATA;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class GameSceneController : MonoBehaviour
{

    void Start()
    {
        
        Managers.UI.ShowSceneUI<UI_Game>("UI_Game");
        Managers.Resource.Instantiate("Prefabs/UI/HP_Bar");

        Managers.Resource.Instantiate("Prefabs/Contents/BackGround");
        Managers.Resource.Instantiate("Prefabs/Contents/Gold_Pool");

        Managers.Battle.CreatePlayer();

        Managers.Boss.SpawnRandomBoss();

    }


    void Update()
    {

        

       


    }

}