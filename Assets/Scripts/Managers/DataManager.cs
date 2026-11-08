using System.Collections.Generic;
using UnityEngine;



public interface ILoader<key, value>
{
    Dictionary<key, value> MakeDict();

}
public class DataManager
{

    public Dictionary<int, Data.Stat> mStatMap { get; private set; } 
        = new Dictionary<int, Data.Stat>();


    public void Init()
    {
        mStatMap = LoadJson<Data.StatData, int, Data.Stat>("StatData").MakeDict();




    }


    Loader LoadJson<Loader, Key, Value>(string _name) where Loader : ILoader<Key, Value>
    {

        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{_name}");

        return JsonUtility.FromJson<Loader>(textAsset.text);

    }



}