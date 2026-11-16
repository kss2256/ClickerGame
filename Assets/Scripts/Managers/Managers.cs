using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers sInstance;


    private BattleManager mBattleManager = new BattleManager();
    private BossManager mBossManager = new BossManager();
    private DataManager mDataManager = new DataManager();
    private InputManager mInpuManager = new InputManager();
    private PoolManager mPoolManager = new PoolManager();
    private ResourceManager mResourceManager = new ResourceManager();
    private SceneManagerEx mSceneManager = new SceneManagerEx();
    private SoundManager mSoundManager = new SoundManager();
    private UIManager mUIManager = new UIManager();


    public static BattleManager Battle => sInstance?.mBattleManager;
    public static BossManager Boss => sInstance?.mBossManager;
    public static DataManager Data => sInstance?.mDataManager;
    public static InputManager Input => sInstance?.mInpuManager;
    public static PoolManager Pool => sInstance?.mPoolManager;
    public static ResourceManager Resource => sInstance?.mResourceManager;
    public static SceneManagerEx Scene => sInstance?.mSceneManager;
    public static SoundManager Sound => sInstance?.mSoundManager;
    public static UIManager UI => sInstance?.mUIManager;




    public static void Init()
    {
        if (sInstance == null)
        {
            sInstance = Util.GetOrAddGameObject("@Managers", true).GetOrAddComponent<Managers>();



            Data.Init();
            Battle.Init();
            Pool.Init();
            Boss.Init();
            Sound.Init();
        }

    }

    private void Update()
    {
        Input.OnUpdate();
    }


    public static void Clear()
    {
        UI.Clear();
        Sound.Clear();

    }





}
