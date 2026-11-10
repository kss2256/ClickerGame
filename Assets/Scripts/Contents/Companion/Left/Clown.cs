using UnityEngine;
using static Define;

public class Clown : Companion_Base
{
    protected override eCharacterType CharacterType => eCharacterType.Clown;

    protected override void Init()
    {
       

        mFixPos = new Vector3(-1.58f, 1.77f, 0f);
        mSide = eCompanionSide.Left;



        base.Init();
        transform.localScale = Vector3.one * 0.25f;
    }




}
