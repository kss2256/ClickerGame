using NUnit.Framework.Internal;
using UnityEngine;

public class test : MonoBehaviour
{
    void Start()
    {

        UI_MouseEvent eve = gameObject.GetOrAddComponent<UI_MouseEvent>();

        eve.mOnUpEnent -= Test;
        eve.mOnUpEnent += Test;

        //Managers.UI.ShowSceneUI<UI_Scene>("UI_Title");


     



    }

    public void Test()
    {
        Debug.Log("UP!!");
    }
    void Update()
    {
        
    }
}
