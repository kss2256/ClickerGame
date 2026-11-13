using UnityEngine;
using static Define;

public class SpadeSoldier : Companion_Base
{
    protected override eCharacterType CharacterType => eCharacterType.SpadeSoldier;

    protected override void Init()
    {
       

        mFixPos = new Vector3(-1.5f, 1.25f, 0f);
        mSide = eCompanionSide.Left;



        base.Init();
    }




}
