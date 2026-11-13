using System.Collections;
using UnityEngine;
using UnityEngine.U2D;
using static Define;

public class Judge : Companion_Base
{
    protected override eCharacterType CharacterType => eCharacterType.Judge;

    protected override void Init()
    {
       

        mFixPos = new Vector3(2.3f, 1.4f, 0f);
        mSide = eCompanionSide.Right;

        base.Init();
        transform.localScale = Vector3.one * 0.4f;
    }









}
