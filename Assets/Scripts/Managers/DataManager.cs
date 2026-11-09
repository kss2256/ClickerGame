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


    public void Init()
    {
        mLevelMap = LoadJson<DATA.StatData, int, DATA.LEVEL>("LevelData").MakeDict();


    }


    Loader LoadJson<Loader, Key, Value>(string _name) where Loader : ILoader<Key, Value>
    {

        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{_name}");

        return JsonUtility.FromJson<Loader>(textAsset.text);

    }



}