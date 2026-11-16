using DG.Tweening;
using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;

public class Gold_Pool : MonoBehaviour
{

    GameObject mGoldOriginal;
    UI_Gold mGold_UI;

    private void Start()
    {

        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Contents/Gold");
        go.transform.position = transform.position;
        go.GetComponent<SpriteRenderer>().sortingOrder = 2;

        GameObject gold = Managers.Resource.Instantiate("Prefabs/UI/UI_Gold");
        
        mGold_UI = gold.GetOrAddComponent<UI_Gold>();
        Managers.UI.SetCanvas(gold, false);

        Managers.Pool.CreatePool(go, 100);
        mGoldOriginal = Managers.Pool.GetOrigin("Gold");

    }


    public void DropGolds(long _gold, int _stag)
    {
        
        

        int ran = Random.Range(1, 3);
        ran *= _stag;
        for (int i = 0; i < ran; ++i)
        {
            Poolable pool = Managers.Pool.Pop(mGoldOriginal);
            Transform tr = pool.transform;

            //동전 위치 초기화
            tr.localRotation = Quaternion.identity;
            tr.position = mGoldOriginal.transform.position;

            tr.DORotate(new Vector3(0, 360, 0), 0.5f, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(6, LoopType.Restart).OnComplete(() =>
            {
                Managers.Pool.Push(pool);
                tr.DOKill();
                mGold_UI.CollectGold(_gold);
            });


            float ranX = Random.Range(-2.5f, 2.5f);
            float ranTime = Random.Range(1.7f, 2.15f);

            tr.DOMoveY(4.7f, 0.1f).OnComplete(() =>
            {
                tr.DOMoveY(-0.5f, 0.6f).SetEase(Ease.InQuad);
                tr.DOMoveX(ranX, 0.6f).SetEase(Ease.InQuad).OnComplete(() => 
                {
                    tr.DOMove(new Vector3(2.5f, 4.7f, 0.0f), 1.0f).SetDelay(ranTime); ;
                });
            });
        }
        


    }






}
