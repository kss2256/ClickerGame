using TMPro;
using UnityEngine;


public abstract class Shop_Base : UI_Popup
{
        
    protected abstract Define.eCharacterType CharacterType { get; }
    protected enum GameObjects
    {
        Exit,
        Sell_Button,
    }


    protected enum Texts
    {
        Level_Text,
        Attack_Text,
        AttackSpeed_Text,
        Price_Text,
        Sell_Text,
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        Bind<GameObject>(typeof(GameObjects));
        GetGameObject((int)GameObjects.Exit).gameObject.BindEvent(Shop_Exit, Define.eMouseEvent.Click);

        GetGameObject((int)GameObjects.Sell_Button).gameObject.BindEvent(Shop_Sell, Define.eMouseEvent.Click);

        Bind<TextMeshProUGUI>(typeof(Texts));


        
        ShopInfo();

        return true;
    }




    public virtual void ShopInfo()
    {
        Stat stat = Managers.Battle.GetCharacter(CharacterType);

        if (stat != null)
        {
            if (50 < stat.Level + 1)
            {
                GetText((int)Texts.Level_Text).text = stat.Level.ToString();
                GetText((int)Texts.Attack_Text).text = stat.Attack.ToString();
                GetText((int)Texts.AttackSpeed_Text).text = stat.AttackSpeed.ToString();
                GetText((int)Texts.Price_Text).text = "";
                GetText((int)Texts.Sell_Text).text = "최대 레벨";
                return;
            }



            DATA.COMPANION_LEVEL nextStat = Managers.Data.GetCompanionLevel((int)CharacterType, stat.Level + 1);

            GetText((int)Texts.Level_Text).text = nextStat.Level.ToString();
            GetText((int)Texts.Attack_Text).text = nextStat.Attack.ToString();
            GetText((int)Texts.AttackSpeed_Text).text = nextStat.AttackSpeed.ToString();
            GetText((int)Texts.Price_Text).text = stat.Price.ToString();

            GetText((int)Texts.Sell_Text).text = "레벨 업 가격";
        }
        else
        {
            DATA.COMPANION_LEVEL com = Managers.Data.GetCompanionLevel((int)CharacterType, 1);

            GetText((int)Texts.Level_Text).text = com.Level.ToString();
            GetText((int)Texts.Attack_Text).text = com.Attack.ToString();
            GetText((int)Texts.AttackSpeed_Text).text = com.AttackSpeed.ToString();
            GetText((int)Texts.Price_Text).text = com.Price.ToString();

            GetText((int)Texts.Sell_Text).text = "구매 가격";
        }



    }

    public virtual void Shop_Sell()
    {
        Stat stat = Managers.Battle.GetCharacter(CharacterType);

        if (stat == null)
        {
            Managers.Battle.CreateCompanion(CharacterType);
            ShopInfo();
        }
        else
        {
            Managers.Battle.CompanionUpdateLevelStat(CharacterType);
            ShopInfo();
        }

    }

    public virtual void Shop_Exit()
    {
        Managers.UI.ClosePopupUI();



        if (mPrevPopup != null)
            mPrevPopup.SetActive(true);

    }




}