using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UI_Title : UI_Scene
{

    private TextMeshProUGUI mText = null;

    public enum TextMeshPros
    {
        UI_Title_Start,
    }



    public override bool Init()
    {
        if (base.Init() == false)
            return false;


        Bind<TextMeshProUGUI>(typeof(TextMeshPros));

        mText = GetText((int)TextMeshPros.UI_Title_Start);


        return true;
    }

    private void Update()
    {

        Color color = mText.color;
        color.a = Mathf.PingPong(Time.time, 1.0f);
        mText.color = color;



    }





}
