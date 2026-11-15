using DATA;
using UnityEngine;
using UnityEngine.InputSystem;

public class Boss_Base : MonoBehaviour
{
    //Boss_manager => AddCompoment

    public int mLevel;
    public int mHP;
    public int mCurHP;
    public int mGold;

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
            Animator ani = GetComponent<Animator>();
            ani.Play("HIT");
        }

    }

    public void OnHitEnd()
    {
        mStatus = eStatus.IDLE;
    }


    void Update()
    {

        if(mStatus == eStatus.DIE)
        {
            Managers.Boss.SpawnRandomBoss();

        }

   
     
    }
}
