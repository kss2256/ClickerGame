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


        Managers.Resource.Instantiate("Prefabs/Contents/BackGround");


        Managers.Battle.CreatePlayer();



    }


    void Update()
    {



       


    }

}