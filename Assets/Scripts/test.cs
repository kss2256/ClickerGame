using NUnit.Framework.Internal;
using UnityEngine;
using DG.Tweening;


public class test : MonoBehaviour
{
    void Start()
    {

        UI_MouseEvent eve = gameObject.GetOrAddComponent<UI_MouseEvent>();

        eve.mOnUpEnent -= Test;
        eve.mOnUpEnent += Test;

        //Managers.UI.ShowSceneUI<UI_Scene>("UI_Title");

        

       // // 1초 동안 X 좌표 100으로 이동
       // transform.DOMoveX(100f, 1f);

       // // 1초 동안 Z축으로 90도 회전
       // transform.DORotate(new Vector3(0, 0, 90), 1f);

       // // 0.2초 동안 1.2배 확대
       // transform.DOScale(1.2f, 0.2f);


       // Image image = GetComponent<Image>();

       // // 0.5초 동안 완전히 투명하게
       // image.DOFade(0f, 0.5f);

       // // 0.5초 동안 다시 나타나기
       // image.DOFade(1f, 0.5f);


       // transform.DOScale(1.2f, 0.3f)
       //.SetEase(Ease.OutBack);



    }

    public void Test()
    {
        Debug.Log("UP!!");
    }
    void Update()
    {
        
    }
}
