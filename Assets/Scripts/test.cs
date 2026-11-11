using NUnit.Framework.Internal;
using UnityEngine;
using DG.Tweening;


public class test : MonoBehaviour
{
    void Start()
    {

        UI_MouseEvent eve = gameObject.GetOrAddComponent<UI_MouseEvent>();

        eve.mOnUpEnent -= Test;
        eve.mOnUpEnent += Test;

        





    }

    public void Test()
    {
        Debug.Log("UP!!");
    }
    void Update()
    {
        
    }
}
