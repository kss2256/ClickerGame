using System.Collections.Generic;
using UnityEngine;


public class PoolManager
{

    #region Pool Class

    public class Pool
    {

        public GameObject mOriginal { get; private set; }
        public Transform mRoot { get; set; }

        Stack<Poolable> mPoolableStack = new Stack<Poolable>();


        public void Init(GameObject _Original, int _Count = 5)
        {

            mOriginal = _Original;

            mRoot = new GameObject().transform; 
            mRoot.name = $"{mOriginal.name}_Root";

            for (int i = 0; i < _Count; i++) 
            {
                Push(Create());
            }
        }



        public Poolable Create()
        {
            GameObject go = Managers.Resource.Instantiate(mOriginal);          

            return go.GetOrAddComponent<Poolable>();
        }

        public void Push(Poolable _Pool)
        {
            if (_Pool == null)
                return;

            _Pool.transform.parent = mRoot;
            _Pool.gameObject.SetActive(false);
            _Pool.bIsActive = false;

            mPoolableStack.Push(_Pool);
        }

        public Poolable Pop(Transform _Parent)
        {

            Poolable pool;

            if(mPoolableStack.Count > 0 )
            {
                pool = mPoolableStack.Pop();
            }
            else
            {
                pool = Create();
            }

            pool.gameObject.SetActive(true);


            if (_Parent == null)
            {
                GameObject go = Util.GetOrAddGameObject("@PoolObject");
                pool.transform.parent = go.transform;
            }
            else
            {
                pool.transform.parent = _Parent;
            }

            pool.bIsActive = true;

            return pool;
        }




    }

    #endregion


    Dictionary<string, Pool> mPoolMap = new Dictionary<string, Pool>();
    GameObject mPoolRoot = null;

    public void Init()
    {
        if (mPoolRoot == null)
        {
            mPoolRoot = new GameObject { name = "@Pool_Root" };
            Object.DontDestroyOnLoad(mPoolRoot);
        }
    }

    public void CreatePool(GameObject _Original, int _Count = 5)
    {
        Pool pool = new Pool();
        pool.Init(_Original, _Count);
        pool.mRoot.parent = mPoolRoot.transform;

        mPoolMap.Add(_Original.name, pool);
    }

    public void Push(Poolable _Poolable)
    {
        string Name = _Poolable.gameObject.name;

        if (mPoolMap.ContainsKey(Name) == false)
        {
            GameObject.Destroy(_Poolable.gameObject);
            return;
        }

        mPoolMap[Name].Push(_Poolable);

    }

    public Poolable Pop(GameObject _Origin, Transform _Parent = null)
    {

        if (mPoolMap.ContainsKey(_Origin.name) == false)
        {
            CreatePool(_Origin);
        }

        return mPoolMap[_Origin.name].Pop(_Parent);
    }

    public GameObject GetOrigin(string _Name)
    {

        if (mPoolMap.ContainsKey(_Name) == false)
            return null;

        return mPoolMap[_Name].mOriginal;
    }

    public void Clear()
    {

        foreach (Transform child in mPoolRoot.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        mPoolMap.Clear();

    }

}