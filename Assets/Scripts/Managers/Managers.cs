using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers sInstance;


    private BattleManager mBattleManager = new BattleManager();
    private DataManager mDataManager = new DataManager();
    private InputManager mInpuManager = new InputManager();
    private ResourceManager mResourceManager = new ResourceManager();
    private SceneManagerEx mSceneManager = new SceneManagerEx();
    private UIManager mUIManager = new UIManager();


    public static BattleManager Battle => sInstance?.mBattleManager;
    public static DataManager Data => sInstance?.mDataManager;
    public static InputManager Input => sInstance?.mInpuManager;
    public static ResourceManager Resource => sInstance?.mResourceManager;
    public static SceneManagerEx Scene => sInstance?.mSceneManager;
    public static UIManager UI => sInstance?.mUIManager;




    public static void Init()
    {
        if (sInstance == null)
        {
            sInstance = Util.GetOrAddGameObject("@Managers", true).GetOrAddComponent<Managers>();



            Data.Init();
            Battle.Init();
        }

    }

    private void Update()
    {
        Input.OnUpdate();
    }


    public static void Clear()
    {
        sInstance.mUIManager.Clear();

    }


}
