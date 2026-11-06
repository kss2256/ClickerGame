using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class Managers : MonoBehaviour
{
    private static Managers sInstance;


    private ResourceManager mResourceManager = new ResourceManager();
    private SceneManagerEx mSceneManager = new SceneManagerEx();
    private UIManager mUIManager = new UIManager();


    public static ResourceManager Resource => sInstance?.mResourceManager;
    public static SceneManagerEx Scene => sInstance?.mSceneManager;
    public static UIManager UI => sInstance?.mUIManager;




    public static void Init()
    {
        if (sInstance == null)
        {
            sInstance = Util.GetOrAddGameObject("@Managers", true).GetOrAddComponent<Managers>();
     
        }



    }


    public static void Clear()
    {
        sInstance.mUIManager.Clear();

    }


}
