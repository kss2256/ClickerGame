using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;


public class Boss : MonoBehaviour
{
    //mHitSequence.Pause();    // 일시정지
    //mHitSequence.Play();     // 재생
    //mHitSequence.Restart();  // 처음부터 재시작
    //mHitSequence.Kill();     // 종료

    //Append()  끝나고 시작
    //Join()    같이 시작
    //AppendInterval() //지정 시간 후 시작

    Animator ani = null;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }


    private void Update()
    {

        if (Keyboard.current.qKey.wasPressedThisFrame)
        {

            transform.DOPunchScale(Vector3.one * 0.05f, 0.2f, 5, 0.5f);
            transform.DOShakePosition(0.2f, 0.3f, 5, 45);


            ani.Play("HIT", 0, 0f);


        }






    }




}