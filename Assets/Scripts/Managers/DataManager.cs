using DATA;
using System.Collections.Generic;
using UnityEngine;



//Data Àü¿ë
public interface ILoader<key, value>
{
    Dictionary<key, value> MakeDict();
}

public class DataManager
{
    
    public Dictionary<int, DATA.LEVEL> mLevelMap { get; private set; } 
        = new Dictionary<int, DATA.LEVEL>();

    public Dictionary<int, DATA.COMPANION> mCompanionMap { get; private set; }
        = new Dictionary<int, DATA.COMPANION>();

    public Dictionary<int, DATA.COMPANION_LEVEL> mCompanionLevelMap { get; private set; }
    = new Dictionary<int, DATA.COMPANION_LEVEL>();


    public void Init()
    {
        mLevelMap = LoadJson<DATA.LevelData, int, DATA.LEVEL>("LevelData").MakeDict();
        mCompanionMap = LoadJson<DATA.CompanionData, int, DATA.COMPANION>("Companion").MakeDict();
        mCompanionLevelMap = LoadJson<DATA.CompanionLevelData, int, DATA.COMPANION_LEVEL>("Companion_Level").MakeDict();


      

    }


    Loader LoadJson<Loader, Key, Value>(string _name) where Loader : ILoader<Key, Value>
    {

        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{_name}");

        return JsonUtility.FromJson<Loader>(textAsset.text);

    }

    public DATA.COMPANION_LEVEL GetCompanionLevel(int _CompanionID, int _level)
    {
        int idx = (_CompanionID - 1);

        COMPANION_LEVEL resule; 



        return null;
    }


}