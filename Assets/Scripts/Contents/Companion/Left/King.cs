using UnityEngine;
using static Define;

public class King : Companion_Base
{
    protected override eCharacterType CharacterType => eCharacterType.King;

    protected override void Init()
    {
        mStat = new Stat(CharacterType);

        mFixPos = new Vector3(-2.3f, 1.75f, 0f);
        mSide = eCompanionSide.Left;



        base.Init();
        transform.localScale = Vector3.one * 0.25f;
    }




}
