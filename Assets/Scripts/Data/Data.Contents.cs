using System;
using System.Collections.Generic;
using UnityEngine;

namespace DATA

{

    public interface IGameData
    {
        int ID { get; }
    }

    public static class DataConverter
    {
        public static Dictionary<int, T> MakeDict<T>(List<T> list)
            where T : IGameData
        {
            Dictionary<int, T> map = new Dictionary<int, T>();

            foreach (T item in list)
            {
                map.Add(item.ID, item);
            }
            return map;
        }
    }




    #region Level

    [Serializable]
    public class LEVEL : IGameData
    {
        public int ID;      //Key값 + 레벨
        public int MaxMp;   
        public int Attack;
        public float AttackSpeed;
        public int UpgradeCost;

        int IGameData.ID => this.ID;
    }

    [Serializable]
    public class LevelData : ILoader<int, LEVEL>//Key, Value
    {
        public List<DATA.LEVEL> Level = new List<DATA.LEVEL>();

        public Dictionary<int, DATA.LEVEL> MakeDict()
        {
            Dictionary<int, DATA.LEVEL> StatMap = DataConverter.MakeDict(Level);
            return StatMap;
        }
    }

    #endregion


    #region Companion 
    [Serializable]
    public class COMPANION : IGameData
    {
        public int ID;      //Key값 (eCharacterType 값 동일하게 맞추기)
        public string Name;
        public int Attack;
        public float AttackSpeed;
        public int Price;

        int IGameData.ID => this.ID;
    }

    [Serializable]
    public class CompanionData : ILoader<int, COMPANION>//Key, Value
    {
        public List<DATA.COMPANION> Companion = new List<DATA.COMPANION>();

        public Dictionary<int, DATA.COMPANION> MakeDict()
        {
            Dictionary<int, DATA.COMPANION> CompanionMap =  DataConverter.MakeDict(Companion);

            return CompanionMap;
        }



    }


    #endregion

    #region Companion Level


    [Serializable]
    public class COMPANION_LEVEL : IGameData
    {
        public int ID;
        public int CompanionID;
        public int Level;
        public float Attack;
        public int UpgradeCost;

        int IGameData.ID => this.ID;
    }


    [Serializable]
    public class CompanionLevelData : ILoader<int, COMPANION_LEVEL> 
    {
        public List<DATA.COMPANION_LEVEL> Companion_Level = new List<DATA.COMPANION_LEVEL>();

        public Dictionary<int, COMPANION_LEVEL> MakeDict()
        {
            Dictionary<int, COMPANION_LEVEL>  value = DataConverter.MakeDict(Companion_Level);

            return value;
        }
    }



    #endregion

}