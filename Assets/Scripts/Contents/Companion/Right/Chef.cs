using System.Collections;
using UnityEngine;
using UnityEngine.U2D;
using static Define;

public class Chef : Companion_Base
{
    protected override eCharacterType CharacterType => eCharacterType.Chef;

    protected override void Init()
    {
      

        mFixPos = new Vector3(2.3f, 2.68f, 0f);
        mSide = eCompanionSide.Right;

        base.Init();
    }









}
