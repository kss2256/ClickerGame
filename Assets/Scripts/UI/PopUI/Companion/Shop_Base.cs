using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UI_Title;


public abstract class Shop_Base : UI_Popup
{
        
    protected abstract Define.eCharacterType CharacterType { get; }


    private Vector3 mButtonFixSize = Vector3.zero;
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

    protected enum Images
    {
        Sell_Image,
        Exit_Image,
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        Bind<GameObject>(typeof(GameObjects));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Image>(typeof(Images));

        mButtonFixSize = GetImage((int)Images.Sell_Image).transform.localScale;

        GetGameObject((int)GameObjects.Exit).gameObject.BindEvent(Shop_Exit, Define.eMouseEvent.Click);

        GetGameObject((int)GameObjects.Sell_Button).gameObject.BindEvent(Shop_Sell, Define.eMouseEvent.Click);

    


        
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


        Transform imageGo = GetImage((int)Images.Sell_Image).rectTransform;

        imageGo.DOKill();
        imageGo.localScale = mButtonFixSize;

        imageGo.transform.DOPunchScale(Vector3.one * -0.15f, 0.25f, 5, 0.5f);


    }

    public virtual void Shop_Exit()
    {

        Transform imageGo = GetImage((int)Images.Exit_Image).rectTransform;
        imageGo.transform.DOPunchScale(Vector3.one * -0.15f, 0.15f, 5, 0.5f).OnComplete(() => 
        {
            Managers.UI.ClosePopupUI();
            if (mPrevPopup != null)
                mPrevPopup.SetActive(true);
        });

        

    }




}