using System.Collections;
using UnityEngine;
using UnityEngine.U2D;
using static Define;

public class CloverSoldier : Companion_Base
{
    protected override eCharacterType CharacterType => eCharacterType.CloverSoldier;

    protected override void Init()
    {
        mStat = new Stat(CharacterType);

        mFixPos = new Vector3(1.5f, 0.5f, 0f);
        mSide = eCompanionSide.Right;

        base.Init();
    }









}
