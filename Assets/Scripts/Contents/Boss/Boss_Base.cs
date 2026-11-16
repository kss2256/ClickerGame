using DATA;
using UnityEngine;
using UnityEngine.InputSystem;

public class Boss_Base : MonoBehaviour
{
    //Boss_manager => AddCompoment

    public int mLevel;
    public int mHP;
    public int mCurHP;
    public long mGold;

    public eStatus mStatus = eStatus.IDLE;

    public enum eStatus
    {
        IDLE,
        HIT,
        DIE,
    }


    public void Init()
    {
        mStatus = eStatus.IDLE;
        DATA.STAGE stage = Managers.Boss.GetStage();
        mLevel = stage.Level;
        mHP = stage.HP;
        mCurHP = stage.HP;
        mGold = stage.Gold;

        Camera cam = Camera.main;
        float top = cam.transform.position.y + cam.orthographicSize;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        float offset = top - sr.bounds.max.y;
        offset += 0.2f;
        transform.position += Vector3.up * offset;

    }


    public void Battle(int _attack)
    {
        if (mStatus == eStatus.DIE)
            return;

        if (_attack >= mCurHP)
        {
            mCurHP = 0;
            mStatus = eStatus.DIE;
            return;
        }
        else
            mCurHP -= _attack;


        if(mStatus != eStatus.HIT)
        {
            
            mStatus = eStatus.HIT;
            Animator ani = GetComponent<Animator>();
            ani.Play("HIT", 0, 0f);
            Managers.Sound.Play("Monster_Hit", Define.eSoundType.EFFECT);
        }

    }

    public void OnHitEnd()
    {
        if (mStatus == eStatus.DIE)
            return;
       
        mStatus = eStatus.IDLE;
    }


    void Update()
    {

        if(mStatus == eStatus.DIE)
        {
            Managers.Boss.mGold.DropGolds(mGold, mLevel);
            Managers.Boss.SpawnRandomBoss();
            
        }

   
     
    }
}
