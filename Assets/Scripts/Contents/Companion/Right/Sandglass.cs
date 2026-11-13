using System.Collections;
using UnityEngine;
using UnityEngine.U2D;
using static Define;

public class Sandglass : Companion_Base
{
    protected override eCharacterType CharacterType => eCharacterType.Sandglass;

    protected override void Init()
    {
       

        mFixPos = new Vector3(1.55f, 2.59f, 0f);
        mSide = eCompanionSide.Right;

        base.Init();

        transform.localScale = Vector3.one * 0.5f;
    }









}
