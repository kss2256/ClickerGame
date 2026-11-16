using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UI_Gold : UI_Base
{


    private long m_Gold = 0;


    public void CollectGold(int _gold)
    {
        Managers.Battle.PlayerController.Stat.mGold += _gold;
        m_Gold = Managers.Battle.PlayerController.Stat.mGold;
    }


    enum Images
    {
        Gold_Image,
    }

    enum Texts
    {
        Gold_Text,
    }


    public override bool Init()
    {
        if (base.Init() == false)
            return false;


        Bind<Image>(typeof(Images));
        Bind<TextMeshProUGUI>(typeof(Texts));





        return true;
    }



    private void Update()
    {
        GetText((int)Texts.Gold_Text).text = GoldText(m_Gold);
    }


    public string GoldText(long _gold)
    {
        //°ñµå

        if (_gold < 1000)
            return _gold.ToString();

        string[] units = { "", "K", "M", "B", "T", "Qa", "Qi" };

        double gold = _gold;
        int index = 0;

        while (gold >= 1000 && index < units.Length - 1)
        {
            gold /= 1000;
            index++;
        }

        return $"{gold:0.##}{units[index]}";
    }


}