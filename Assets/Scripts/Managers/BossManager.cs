using DATA;
using System;
using Unity.VisualScripting;
using UnityEngine;


public class BossManager 
{
    //mHitSequence.Pause();    // 일시정지
    //mHitSequence.Play();     // 재생
    //mHitSequence.Restart();  // 처음부터 재시작
    //mHitSequence.Kill();     // 종료

    //Append()  끝나고 시작
    //Join()    같이 시작
    //AppendInterval() //지정 시간 후 시작


    private int mStage = 0;
    private const int MAX_STAGE = 30;
    public Gold_Pool mGold;
        

    public Poolable CurBoss { get; set; }

    enum eBossList
    {
        Boss_1,
        Boss_2,
        Boss_3,
        Boss_4,
        Boss_5,
        Boss_6,
    }


    public void Init()
    {
        string[] bossList = Enum.GetNames(typeof(eBossList));

        for(int i = 0; i < bossList.Length; i++)
        {           
            GameObject go = Managers.Resource.Load<GameObject>($"Prefabs/Contents/Boss/{bossList[i]}");
            go.GetOrAddComponent<Boss_Base>();
            Managers.Pool.CreatePool(go, 3);

        }
    }


    public void Gold_PoolCreate()
    {
        mGold = Managers.Resource.Instantiate("Prefabs/Contents/Gold_Pool").GetOrAddComponent<Gold_Pool>();
    }


    public void SpawnRandomBoss()
    {

        if (mStage >= MAX_STAGE)
        {
            Debug.Log("Stage Clear!");
            return;
        }

        DespawnBoss();       

        string[] bossList = Enum.GetNames(typeof(eBossList));

        int idx = UnityEngine.Random.Range(0, bossList.Length);

        GameObject go = Managers.Pool.GetOrigin(bossList[idx]);

        CurBoss = Managers.Pool.Pop(go);

        //Compoment Add 
        Boss_Base Bossgo = CurBoss.GetOrAddComponent<Boss_Base>();

        if (CurBoss != null)
        {
            ++mStage;
            Bossgo.Init();
        }

    }


    public void DespawnBoss()
    {
        if (CurBoss == null)
            return;

        Managers.Pool.Push(CurBoss);

        CurBoss = null;
    }

    public DATA.STAGE GetStage()
    {
        DATA.STAGE stage = Managers.Data.GetStage(mStage);

        return stage;
    }



}