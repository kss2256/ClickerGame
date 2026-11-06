using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagerEx
{

    private Define.eSceneType mSceneType = Define.eSceneType.TiTleScene;

    public Define.eSceneType CurentScene {get {return mSceneType; }}

    private bool bInit = false;

    public void SceneInit()
    {
        if (bInit)
            return;

        LoadScene(Define.eSceneType.TiTleScene);
        bInit = true;
    }

    public void ChangeScene(Define.eSceneType _type)
    {
        Managers.Clear();

        mSceneType = _type;

        SceneManager.sceneLoaded += OnSceneLoaded;

        SceneManager.LoadScene((int)mSceneType);
       
    }



    private void OnSceneLoaded(Scene _scene, LoadSceneMode _mode)
    {

        SceneManager.sceneLoaded -= OnSceneLoaded;

        LoadScene(mSceneType);
    }

    public void LoadScene(Define.eSceneType _type)
    {

        switch (_type)
        {
            case Define.eSceneType.TiTleScene:
                {
                    Managers.Resource.Instantiate("Prefabs/Contents/TitleScene");
                }
                break;
            case Define.eSceneType.GameScene:
                {                   
                    Managers.Resource.Instantiate("Prefabs/Contents/GameScene");
                }
                break;
            default:
                break;
        }


    }



}