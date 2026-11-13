using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using static Companion_Shop;

public class Companion_Panel : UI_Base
{

    enum Images
    {
        CloverSoldier,
        SpadeSoldier,
        Judge,
        Turnip,
        Chef,
        King,
        Sandglass,
        Clown,
    }

    enum GameObjects
    {
        CloverSoldier_Button,
        SpadeSoldier_Button,
        Judge_Button,
        Turnip_Button,
        Chef_Button,
        King_Button,
        Sandglass_Button,
        Clown_Button,
    }




    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        Bind<GameObject>(typeof(GameObjects));


        Bind<Image>(typeof(Images));
       


        GetGameObject((int)GameObjects.CloverSoldier_Button).gameObject.BindEvent(CloverSoldier_Shop, Define.eMouseEvent.Click);
        GetGameObject((int)GameObjects.SpadeSoldier_Button).gameObject.BindEvent(SpadeSoldier_Shop, Define.eMouseEvent.Click);
        GetGameObject((int)GameObjects.Judge_Button).gameObject.BindEvent(Judge_Shop, Define.eMouseEvent.Click);
        GetGameObject((int)GameObjects.Turnip_Button).gameObject.BindEvent(Turnip_Shop, Define.eMouseEvent.Click);
        GetGameObject((int)GameObjects.Chef_Button).gameObject.BindEvent(Chef_Shop, Define.eMouseEvent.Click);
        GetGameObject((int)GameObjects.King_Button).gameObject.BindEvent(King_Shop, Define.eMouseEvent.Click);
        GetGameObject((int)GameObjects.Sandglass_Button).gameObject.BindEvent(Sandglass_Shop, Define.eMouseEvent.Click);
        GetGameObject((int)GameObjects.Clown_Button).gameObject.BindEvent(Clown_Shop, Define.eMouseEvent.Click);





        return true;
    }



    public void CloverSoldier_Shop()
    {
        Image img = GetImage((int)Images.CloverSoldier);

        img.DOColor(Color.green, 0.1f).SetLoops(2, LoopType.Yoyo).OnComplete(() => 
        {
            GameObject go = GetComponentInParent<Companion_Shop>().gameObject;
            Managers.UI.ShowPopUpUI<CloverSoldier_Shop>("Prefabs/UI/Popup/CloverSoldier_Shop").SetPrevPopup(go);

            go.SetActive(false);
        });

        
    }
    public void SpadeSoldier_Shop()
    {

        Image img = GetImage((int)Images.SpadeSoldier);

        img.DOColor(Color.green, 0.1f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
        {
            GameObject go = GetComponentInParent<Companion_Shop>().gameObject;

            Managers.UI.ShowPopUpUI<SpadeSoldier_Shop>("Prefabs/UI/Popup/SpadeSoldier_Shop").SetPrevPopup(go);

            go.SetActive(false);
        });

            
    }

    public void Judge_Shop()
    {
        Image img = GetImage((int)Images.Judge);

        img.DOColor(Color.green, 0.1f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
        {
            GameObject go = GetComponentInParent<Companion_Shop>().gameObject;

            Managers.UI.ShowPopUpUI<Judge_Shop>("Prefabs/UI/Popup/Judge_Shop").SetPrevPopup(go);

            go.SetActive(false);
        });

       
    }
    public void Turnip_Shop()
    {
        Image img = GetImage((int)Images.Turnip);

        img.DOColor(Color.green, 0.1f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
        {
            GameObject go = GetComponentInParent<Companion_Shop>().gameObject;

            Managers.UI.ShowPopUpUI<Turnip_Shop>("Prefabs/UI/Popup/Turnip_Shop").SetPrevPopup(go);

            go.SetActive(false);
        });
       
    }
    public void Chef_Shop()
    {
        Image img = GetImage((int)Images.Chef);

        img.DOColor(Color.green, 0.1f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
        {
            GameObject go = GetComponentInParent<Companion_Shop>().gameObject;

            Managers.UI.ShowPopUpUI<Chef_Shop>("Prefabs/UI/Popup/Chef_Shop").SetPrevPopup(go);

            go.SetActive(false);


        });
     
    }
    public void King_Shop()
    {
        Image img = GetImage((int)Images.King);

        img.DOColor(Color.green, 0.1f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
        {
            GameObject go = GetComponentInParent<Companion_Shop>().gameObject;

            Managers.UI.ShowPopUpUI<King_Shop>("Prefabs/UI/Popup/King_Shop").SetPrevPopup(go);

            go.SetActive(false);
        });

       
    }
    public void Sandglass_Shop()
    {
        Image img = GetImage((int)Images.Sandglass);

        img.DOColor(Color.green, 0.1f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
        {
            GameObject go = GetComponentInParent<Companion_Shop>().gameObject;

            Managers.UI.ShowPopUpUI<Sandglass_Shop>("Prefabs/UI/Popup/Sandglass_Shop").SetPrevPopup(go);

            go.SetActive(false);

        });
       
    }
    public void Clown_Shop()
    {
        Image img = GetImage((int)Images.Clown);

        img.DOColor(Color.green, 0.1f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
        {
            GameObject go = GetComponentInParent<Companion_Shop>().gameObject;

            Managers.UI.ShowPopUpUI<Clown_Shop>("Prefabs/UI/Popup/Clown_Shop").SetPrevPopup(go);

            go.SetActive(false);
        });
        
    }


}
