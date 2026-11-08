using UnityEngine;


public class Stat
{

    public int ID;
    public int MP;
    public int MaxMp;
    public int Attack;
    public float AttackSpeed;



    public virtual void Init(Define.eCharacterType _type)
    {
        ID = (int)_type;

        


    }


}