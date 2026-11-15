using UnityEngine;
using DG.Tweening;

public class Gold_Pool : MonoBehaviour
{

    GameObject mGold;

    private void Start()
    {

        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Contents/Gold");
        go.transform.position = transform.position;
        go.GetComponent<SpriteRenderer>().sortingOrder = 2;


        Managers.Pool.CreatePool(go, 100);
        mGold = Managers.Pool.GetOrigin("Gold");

    }


    public void DropGolds(int _gold, int _stag)
    {
        
        Managers.Battle.PlayerController.Stat.mGold = _gold;

        int ran = Random.Range(1, 3);
        ran *= _stag;
        for (int i = 0; i < ran; ++i)
        {
            Poolable pool = Managers.Pool.Pop(mGold);
            Transform tr = pool.transform;

            //동전 위치 초기화
            tr.localRotation = Quaternion.identity;
            tr.position = mGold.transform.position;

            tr.DORotate(new Vector3(0, 360, 0), 0.5f, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(6, LoopType.Restart).OnComplete(() =>
            {
                Managers.Pool.Push(pool);
                tr.DOKill();             
            });


            float ranX = Random.Range(-2.5f, 2.5f);

            tr.DOMoveY(4.7f, 0.1f).OnComplete(() =>
            {
                tr.DOMoveY(-0.5f, 0.6f).SetEase(Ease.InQuad);
                tr.DOMoveX(ranX, 0.6f).SetEase(Ease.InQuad);
            });
        }
        


    }






}
