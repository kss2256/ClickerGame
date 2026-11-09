using UnityEngine;


public class Stat
{

    public int ID;
    public int MP;
    public int MaxMp;
    public int Attack;
    public float AttackSpeed;

    public Stat(Define.eCharacterType _type)
    {
        ID = (int)_type;



    }


   


}