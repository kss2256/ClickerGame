using UnityEngine;
using UnityEngine.UI;


public class HP_Bar : UI_Base
{

    Image mRed_Fill = null;
    Image mWhit_Fill = null;


    enum Images
    {
        Slider_Bar_Red,
        Slider_Bar_Whit,
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        Bind<Image>(typeof(Images));

        mRed_Fill = GetImage((int)Images.Slider_Bar_Red);
        mWhit_Fill = GetImage((int)Images.Slider_Bar_Whit);
            



        return  true;
    }




    private void Update()
    {
        //HP_Bar Fill설정 보기
        if (Managers.Boss.CurBoss.GetComponent<Boss_Base>() == null)
            return;

        Boss_Base boss = Managers.Boss.CurBoss.GetComponent<Boss_Base>();

        float hp;

        hp = (float)boss.mCurHP / boss.mHP;

        mRed_Fill.fillAmount = hp;
        mWhit_Fill.fillAmount = 1 - hp;

    }



}