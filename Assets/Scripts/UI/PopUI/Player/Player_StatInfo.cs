using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class Player_StatInfo : UI_Base
{


    private Vector3 mButtonFixSize = Vector3.zero;

    enum Texts
    {
        Level_Text,
        MaxMp_Text,
        Attack_Text_1,
        AttackSpeed_Text_1,
        Attack_Text_2,
        AttackSpeed_Text_2,
        Attack_Text_3,
        AttackSpeed_Text_3,
        LevelUp_Text,
    }

    enum Images
    {
        LevelUp_Button_Image,
    }

    enum Buttons
    {
        LevelUp_Button,
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;


        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Image>(typeof(Images));
        Bind<Button>(typeof(Buttons));

        mButtonFixSize = GetImage((int)Images.LevelUp_Button_Image).rectTransform.localScale;

        GetButton((int)Buttons.LevelUp_Button).gameObject.BindEvent(LevelUp_Button, Define.eMouseEvent.Click);

        StatTextInit();

        return true;
    }


    public void LevelUp_Button()
    {

        Transform tr = GetImage((int)Images.LevelUp_Button_Image).rectTransform;

        tr.DOKill();
        tr.transform.localScale = mButtonFixSize;
        tr.DOPunchScale(Vector3.one * -0.15f, 0.15f, 5, 0.5f).OnComplete(Player_LevelUp);

    }


    public void Player_LevelUp()
    {
        PlayerController player = Managers.Battle.PlayerController;



        if (player.Weapon == PlayerController.eWeapons.NONE)
            return;

        Managers.Battle.PlayerUpdateLevelStat();
        StatTextInit();
        player.SetAniSpeed(player.Stat.AttackSpeed);

    }


    public void StatTextInit()
    {
        


        PlayerStat stat = Managers.Battle.PlayerController.Stat;
        DATA.LEVEL nextLevel = Managers.Data.GetPlayerLevelInfo(stat.Level + 1);

        string text = stat.Price.ToString();

        if (stat.Level >= 50)
        {
            nextLevel = Managers.Data.GetPlayerLevelInfo(stat.Level);
            text = "최대 레벨";
        }

        GetText((int)Texts.Level_Text).text = stat.Level.ToString();
        GetText((int)Texts.MaxMp_Text).text = stat.MP.ToString();

        GetText((int)Texts.Attack_Text_1).text = stat.Attack.ToString();
        GetText((int)Texts.AttackSpeed_Text_1).text = stat.AttackSpeed.ToString();

        GetText((int)Texts.Attack_Text_2).text = stat.Attack.ToString();
        GetText((int)Texts.AttackSpeed_Text_2).text = stat.AttackSpeed.ToString();

        GetText((int)Texts.LevelUp_Text).text = text;

        GetText((int)Texts.Attack_Text_3).text = nextLevel.Attack.ToString();
        GetText((int)Texts.AttackSpeed_Text_3).text = nextLevel.AttackSpeed.ToString();



    }











}