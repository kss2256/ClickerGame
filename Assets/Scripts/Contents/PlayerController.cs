using System;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public enum eWeapons
    {
        NONE,
        HAMMER = 2,
        SCISSORS = 3,
    }
    public enum eStatus
    {
        ATTACK,
        IDLE,
        DIE
    }

    private eStatus mStatus = eStatus.IDLE;
    private eWeapons mWeapons = eWeapons.NONE;
    private Animator mAni = null;
    private SpriteRenderer mSprite = null;
    private PlayerStat mStat = null;
    

    private bool bLeftAttack = false;

    
    public PlayerStat Stat { get { return mStat; } set { mStat = value; } }
    public eWeapons Weapon { get { return mWeapons; } set { mWeapons = value; } }
    public eStatus Status { get {return mStatus; } set
        { 
            mStatus = value;
            {
                
                
                switch (mStatus)
                {
                    case eStatus.ATTACK:
                        {
                            if(bLeftAttack)
                            {
                                mAni.CrossFade("RIGHT", 0.1f);
                                bLeftAttack = false;
                            }
                            else
                            {
                                mAni.CrossFade("LEFT", 0.1f);
                                bLeftAttack = true;
                            }
                                
                        }
                        break;
                    case eStatus.IDLE:
                        {
                            mAni.CrossFade("IDLE", 0.1f);
                        }
                        break;
                    case eStatus.DIE:
                        break;
                    default:
                        break;
                }



            }
        }}






    void Start()
    {

        PlayerStatInit();

        PlayerSpriteInit();
        ChangeAniController();

        Managers.Input.mMouseEvent -= Attack;
        Managers.Input.mMouseEvent += Attack;

    }

    public void Attack(Define.eMouseEvent _eve)
    {
        if (Weapon == eWeapons.NONE)
            return;


        if(_eve == Define.eMouseEvent.Down && Status == eStatus.IDLE)
        {
            Status = eStatus.ATTACK;
        }

    }





    public void OnAttackEnd()
    {
        Status = eStatus.IDLE;
    }

    public void PlayerStatInit()
    {
        
        
    }


    public void PlayerSpriteInit()
    {
        mSprite = gameObject.GetOrAddComponent<SpriteRenderer>();        
        string name = mWeapons.ToString();


        mSprite.sprite = Managers.Resource.Load<Sprite>($"Art/Player/Main/{name}");
      

        transform.localScale = Vector3.one * 0.3f;
        transform.position += Vector3.up * 0.1f;
    }

    public void ChangeWeapon(eWeapons _weapon)
    {
        Weapon = _weapon;
        ChangeAniController();
        SetAniSpeed(mStat.AttackSpeed);
    }

    public void ChangeAniController()
    {
        string name = mWeapons.ToString();
        mAni = gameObject.GetOrAddComponent<Animator>();
        mAni.runtimeAnimatorController = Managers.Resource.Load<RuntimeAnimatorController>($"Animations/Player/Controller/{name}");

    }

    public void SetAniSpeed(float _speed)
    {
        if(mAni == null)
        {
            Debug.Log("Player Animator Null");
            return;
        }

        mAni.SetFloat("AttackSpeed", _speed);
    }


}
