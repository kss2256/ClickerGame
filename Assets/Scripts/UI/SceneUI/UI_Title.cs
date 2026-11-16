using DG.Tweening;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UI_Title : UI_Scene
{

    private TextMeshProUGUI mText = null;
    private bool bCanStartGame = false;

    public enum TextMeshPros
    {
        UI_Title_Start,
    }

    public enum Buttons
    {
        UI_Title_StartButton,
    }

    public enum Images
    {
        UI_Title_LogoImage,
    }


    public override bool Init()
    {
        if (base.Init() == false)
            return false;


        Bind<TextMeshProUGUI>(typeof(TextMeshPros));
        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));

        Managers.Sound.Play("Title", Define.eSoundType.BGM);

        mText = GetText((int)TextMeshPros.UI_Title_Start);
        mText.gameObject.SetActive(false);

        GetButton((int)Buttons.UI_Title_StartButton).gameObject.BindEvent(SceneChangeButtonClick, Define.eMouseEvent.Click);

        StartCoroutine(StartLogoSound());



        return true;
    }

   
    private void Update()
    {
        if(bCanStartGame)
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
        if (bCanStartGame)
        {

            Managers.Scene.ChangeScene(Define.eSceneType.GameScene);

        }
    }


    private IEnumerator StartLogoSound()
    {
        //렌더링
        // 첫 화면 렌더링까지 대기
        yield return new WaitForEndOfFrame();

        // 모바일 초기 화면 표시를 위한 여유 시간
        yield return new WaitForSecondsRealtime(0.2f);

        // 효과음 시작
        Managers.Sound.Play("Logo", Define.eSoundType.EFFECT);
               
        // 로고 애니메이션 시작
        GetImage((int)Images.UI_Title_LogoImage)
            .rectTransform
            .DOAnchorPosY(0f, 2.0f)
            .SetEase(Ease.OutBounce)
            .OnComplete(() =>
            {
                bCanStartGame = true;
                mText.gameObject.SetActive(true);
            });
    }

}
