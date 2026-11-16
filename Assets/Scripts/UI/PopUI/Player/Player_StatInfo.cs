using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class Player_StatInfo : UI_Base
{


    private Vector3 mButtonFixSize = Vector3.zero;
    private Color mOriginalColor;

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

        mOriginalColor = GetImage((int)Images.LevelUp_Button_Image).color;

        GetButton((int)Buttons.LevelUp_Button).gameObject.BindEvent(LevelUp_Button, Define.eMouseEvent.Click);

        StatTextInit();

        return true;
    }


    public void LevelUp_Button()
    {
        long myCoin;
        if (CanLevelUp(out myCoin) == false)
        {
            Image image = GetImage((int)Images.LevelUp_Button_Image);
            image.DOKill();
            image.color = mOriginalColor;

            Sequence seq = DOTween.Sequence();

            seq.Append(image.DOColor(Color.red, 0.2f));
            seq.Append(image.DOColor(mOriginalColor, 0.2f));
            Managers.Sound.Play("Button_1", Define.eSoundType.EFFECT);

            return;
        }

        Transform tr = GetImage((int)Images.LevelUp_Button_Image).rectTransform;
        if(myCoin >= 0)
        {
            PlayerController player = Managers.Battle.PlayerController;
            player.Stat.mGold = myCoin;
        }


        tr.DOKill();
        tr.transform.localScale = mButtonFixSize;
        tr.DOPunchScale(Vector3.one * -0.15f, 0.15f, 5, 0.5f).OnComplete(Player_LevelUp);

    }


    public bool CanLevelUp(out long _result)
    {
        PlayerController player = Managers.Battle.PlayerController;
        int idx = player.Stat.Level;
        if (idx > 50)
        {
            _result = -1;
            return false;
        }
            

        DATA.LEVEL nextLevel = Managers.Data.GetPlayerLevelInfo(idx);

        _result = player.Stat.mGold - nextLevel.Price;

       

        return nextLevel.Price <= player.Stat.mGold;
    }

    public void Player_LevelUp()
    {
        PlayerController player = Managers.Battle.PlayerController;

        

        Managers.Sound.Play("Player_Up", Define.eSoundType.EFFECT);

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