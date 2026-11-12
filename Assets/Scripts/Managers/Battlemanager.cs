using DATA;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;


public class BattleManager
{

    private Dictionary<int, Stat> mCharacterMap = new Dictionary<int, Stat>();


    

    public Stat GetCharacter(Define.eCharacterType _type)
    {
        mCharacterMap.TryGetValue((int)_type, out Stat result);
              
        return result;       
    }


    public void Init()
    {
        Array value = Enum.GetValues(typeof(Define.eCharacterType));

        for (int i = 0; i < value.Length; i++) 
        {
            Stat stat = null;
            Define.eCharacterType type = (Define.eCharacterType)value.GetValue(i);

            mCharacterMap.Add((int)type, stat);
        }

    }




    public void CreatePlayer()
    {
        GameObject go = Util.GetOrAddGameObject("Player");
        PlayerController player = go.GetOrAddComponent<PlayerController>();


        PlayerUpdateLevelStat();

        player.Stat = mCharacterMap[(int)Define.eCharacterType.PLAYER] as PlayerStat;

    }

    public void PlayerUpdateLevelStat()
    {
        int key = (int)Define.eCharacterType.PLAYER;

        PlayerStat stat = GetCharacter(Define.eCharacterType.PLAYER) as PlayerStat;
                
        int level = 1;

        if (stat != null)
            level = stat.Level + 1;

        //최대 레벨
        if (level > 50)
            return;

        DATA.LEVEL data = Managers.Data.GetPlayerLevelInfo(level);

        if (data == null)
            return;

        if (stat == null)
        {
            stat = new PlayerStat();
            mCharacterMap[key] = stat;
        }
     

        stat.ID = (int)Define.eCharacterType.PLAYER;
        stat.MaxMp = data.MaxMp;        
        stat.MP = data.MaxMp; 
        stat.Level = data.ID;
        stat.Attack = data.Attack;
        stat.AttackSpeed = data.AttackSpeed;
        stat.Price = data.Price;

    }


    public void CreateCompanion(Define.eCharacterType _type)
    {
        Stat stat = GetCharacter(_type);
        if (stat != null)
            return;


        DATA.COMPANION com = Managers.Data.GetCompanion((int)_type);
        if (com == null)
        {
            Debug.Log($"Data Companion Load Faild {_type}");
            return;
        }


        //Assembly.GetType() / 어셈블리에서 이름으로 타입 검색
        //IsAssignableFrom() / Companion_Base로 취급할 수 있는 타입인지 확인        
        //type.IsAbstract / 추상클래스인지 확인

        Type type = typeof(Companion_Base).Assembly.GetType(com.Name);
        if (type == null || !typeof(Companion_Base).IsAssignableFrom(type)|| type.IsAbstract)
        {
            Debug.Log($"Companion Type Load Failed {com.Name}");
            return;
        }
        

        GameObject go = Util.GetOrAddGameObject(com.Name);        
        Companion_Base companion = go.GetComponent(type) as Companion_Base;

        if (companion == null)
            companion = go.AddComponent(type) as Companion_Base;

        if (companion == null)
            return;

        stat = new Stat();

        stat.ID = (int)_type;
        stat.Attack = com.Attack;
        stat.AttackSpeed = com.AttackSpeed;
        stat.Price = com.Price;

        mCharacterMap[(int)_type] = stat;

        companion.Stat = stat;

    }

    public void CompanionUpdateLevelStat(Define.eCharacterType _type)
    {
        Stat stat = GetCharacter(_type);

        if (stat == null)
            return;

        DATA.COMPANION_LEVEL com = Managers.Data.GetCompanionLevel((int)_type, stat.Level);

        if (com == null)
            return;


        stat.ID = (int)_type;
        stat.Attack = com.Attack;
        stat.AttackSpeed = com.AttackSpeed;
        stat.Price = com.Price;

    }

    public void CompanionUpdateLevelStat(Define.eCharacterType _type, int _level)
    {
        Stat stat = GetCharacter(_type);

        if (stat == null)
            return;

        DATA.COMPANION_LEVEL com = Managers.Data.GetCompanionLevel((int)_type, _level);

        if (com == null)
            return;


        stat.ID = (int)_type;
        stat.Attack = com.Attack;
        stat.AttackSpeed = com.AttackSpeed;
        stat.Price = com.Price;

    }


}