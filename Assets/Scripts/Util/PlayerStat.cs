using UnityEngine;

public class PlayerStat : Stat
{

    public int Level;
    public int Exp;
    public int MaxExp;

     public PlayerStat() : base(Define.eCharacterType.PLAYER)
    {

        MP = 10;
        MaxMp = 10;
        Attack = 1;
        AttackSpeed = 0.5f;
    }

   




}