using System.Collections;
using UnityEngine;
using UnityEngine.U2D;
using static Define;

public class Judge : Companion_Base
{
    protected override eCharacterType CharacterType => eCharacterType.Judge;

    protected override void Init()
    {
        mStat = new Stat(CharacterType);

        mFixPos = new Vector3(2.3f, 0.6f, 0f);
        mSide = eCompanionSide.Right;

        base.Init();
        transform.localScale = Vector3.one * 0.4f;
    }









}
