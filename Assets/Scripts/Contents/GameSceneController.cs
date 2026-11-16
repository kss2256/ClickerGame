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
        GameObject hp_bar = Managers.Resource.Instantiate("Prefabs/UI/HP_Bar");
        Managers.UI.SetCanvas(hp_bar, false);

        Managers.Resource.Instantiate("Prefabs/Contents/BackGround");
        Managers.Boss.Gold_PoolCreate();

        Managers.Battle.CreatePlayer();

        Managers.Boss.SpawnRandomBoss();

    }


    void Update()
    {

        

       


    }

}