using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UI_Title : UI_Scene
{

    private TextMeshProUGUI mText = null;

    public enum TextMeshPros
    {
        UI_Title_Start,
    }

    public enum Buttons
    {
        UI_Title_StartButton,
    }



    public override bool Init()
    {
        if (base.Init() == false)
            return false;


        Bind<TextMeshProUGUI>(typeof(TextMeshPros));
        Bind<Button>(typeof(Buttons));

       

        mText = GetText((int)TextMeshPros.UI_Title_Start);
        GetButton((int)Buttons.UI_Title_StartButton).gameObject.BindEvent(SceneChangeButtonClick, Define.eMouseEvent.Click);





        return true;
    }

   
    private void Update()
    {
        StartTextFade();
    }

    public void StartTextFade()
    {
        Color color = mText.color;
        color.a = Mathf.PingPong(Time.time, 1.0f);
        mText.color = color;
    }


    public void SceneChangeButtonClick()
    {
        Managers.Scene.ChangeScene(Define.eSceneType.GameScene);
    }

}
