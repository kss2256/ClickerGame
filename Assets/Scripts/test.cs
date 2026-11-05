using UnityEngine;

public class test : MonoBehaviour
{
    void Start()
    {


        GameObject go = Managers.Resource.Instantiate("Prefabs/UI/Scene/UI_Title");
        Managers.UI.SetCanvas(go);

    }

    void Update()
    {
        
    }
}
