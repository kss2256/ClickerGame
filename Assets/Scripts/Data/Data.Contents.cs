using System;
using System.Collections.Generic;
using UnityEngine;

/*
  json 문법 기초
  [] -> 리스트와 비슷
  {} -> 구조체와 비슷
*/

namespace Data
{

    #region Stat

    [Serializable]
    public class Stat
    {
        public int ID;
        public int MP;
        public int MaxMp;
        public int Attack;
        public float AttackSpeed;
        public int MaxExp;
    }

    [Serializable]
    public class StatData : ILoader<int, Stat>
    {
        public List<Stat> stats = new List<Stat>();

        public Dictionary<int, Stat> MakeDict()
        {

            Dictionary<int, Stat> StatMap = new Dictionary<int, Stat>();

            foreach (Stat stat in stats)
            {
                StatMap[stat.ID] = stat;
            }

            return StatMap;
        }
    }

    #endregion

}