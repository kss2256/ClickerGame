using System;
using System.Collections.Generic;
using UnityEngine;

namespace DATA

{
    #region Level

    [Serializable]
    public class LEVEL
    {
        public int ID;      //Key°ª + ·¹º§
        public int MaxMp;   
        public int Attack;
        public float AttackSpeed;
        public int MaxExp;
    }

    [Serializable]
    public class StatData : ILoader<int, LEVEL>//Key, Value
    {
        public List<DATA.LEVEL> Level = new List<DATA.LEVEL>();

        public Dictionary<int, DATA.LEVEL> MakeDict()
        {

            Dictionary<int, DATA.LEVEL> StatMap = new Dictionary<int, DATA.LEVEL>();
            foreach (DATA.LEVEL stat in Level)
            {
                StatMap.Add(stat.ID, stat);
            }

            return StatMap;
        }
    }

    #endregion




}