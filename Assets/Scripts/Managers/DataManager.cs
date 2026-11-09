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


    public void Init()
    {
        mLevelMap = LoadJson<DATA.LevelData, int, DATA.LEVEL>("LevelData").MakeDict();
        //mCompanionMap = LoadJson<DATA.CompanionData, int, DATA.COMPANION>("CompanionData").MakeDict();




    }


    Loader LoadJson<Loader, Key, Value>(string _name) where Loader : ILoader<Key, Value>
    {

        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{_name}");

        return JsonUtility.FromJson<Loader>(textAsset.text);

    }



}