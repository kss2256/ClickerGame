using UnityEngine;

public class PlayerStat : Stat
{

    public int Level;
    public int Exp;
    public int MaxExp;


    public override void Init(Define.eCharacterType _type)
    {
        ID = (int)_type;
       
        MP = 10;
        MaxMp = 10;
        Attack = 1;
        AttackSpeed = 0.5f;
    }





}