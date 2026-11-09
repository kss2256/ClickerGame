using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TitleSceneController : MonoBehaviour
{


   

    void Start()
    {
        
        Managers.UI.ShowSceneUI<UI_Title>("UI_Title");

        Dictionary<int, DATA.LEVEL> level = Managers.Data.mLevelMap;

    }


    void Update()
    {

       



    }
}
