using UnityEngine;
using static Define;

public class SpadeSoldier : Companion_Base
{
    protected override eCharacterType CharacterType => eCharacterType.SpadeSoldier;

    protected override void Init()
    {
        mStat = new Stat(CharacterType);

        mFixPos = new Vector3(-1.5f, 0.5f, 0f);
        mSide = eCompanionSide.Left;



        base.Init();
    }




}
