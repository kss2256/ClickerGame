using UnityEngine;
using static Define;

public class Turnip : Companion_Base
{
    protected override eCharacterType CharacterType => eCharacterType.Turnip;

    protected override void Init()
    {
      

        mFixPos = new Vector3(-2.3f, 1.35f, 0f);
        mSide = eCompanionSide.Left;



        base.Init();
        transform.localScale = Vector3.one * 0.15f;
    }




}
