using System.Collections;
using UnityEngine;
using static Define;



public abstract class Companion_Base : MonoBehaviour
{

    protected Stat mStat;

    protected SpriteRenderer mSpriteRenderer;
    protected Sprite mSpriteIdle;
    protected Sprite mSpriteAttack;



    

    protected Vector3 mFixPos;
    protected eCompanionSide mSide;

    protected abstract Define.eCharacterType CharacterType { get; }

    protected virtual void Start()
    {
        Init();

        SetInfo();
        


        /*
         
         
        //Level Data
        public int ID;
        public int CompanionID;
        public int Level;
        public float Attack;
        public int UpgradeCost;

         */

        StartCoroutine(Attack());
    }

    protected virtual void Init()
    {

        

        string name = gameObject.name;

        string side = mSide.ToString();

        mSpriteRenderer = gameObject.GetOrAddComponent<SpriteRenderer>();

        mSpriteIdle = Managers.Resource.Load<Sprite>(
            $"Art/Companion/{side}/{name}00");

        mSpriteAttack = Managers.Resource.Load<Sprite>(
            $"Art/Companion/{side}/{name}01");

        mSpriteRenderer.sprite = mSpriteIdle;

        mSpriteRenderer.flipX = (mSide == eCompanionSide.Right);

        transform.position = mFixPos;
        transform.localScale = Vector3.one * 0.3f;
    }

    protected virtual void SetInfo()
    {
        DATA.COMPANION companion = null;
        mStat = new Stat();
        companion = Managers.Data.GetCompanion((int)CharacterType);

        if (companion == null)
        {
            Debug.LogError($"Companion Data Not Found : {CharacterType}");
            return;
        }

        mStat.ID = companion.ID;
        mStat.Level = 1;
        mStat.Attack = companion.Attack;
        mStat.AttackSpeed = companion.AttackSpeed;
        mStat.AttackSpeed = companion.AttackSpeed;
        mStat.Price = companion.Price;

    }

    protected virtual IEnumerator Attack()
    {
        while (true)
        {
            float lerpValue = Mathf.InverseLerp(
                0.5f, 3.0f, mStat.AttackSpeed);

            float time = Mathf.Lerp(2.0f, 0.2f, lerpValue);

            mSpriteRenderer.sprite = mSpriteAttack;

            yield return new WaitForSeconds(0.15f);

            mSpriteRenderer.sprite = mSpriteIdle;

            yield return new WaitForSeconds(time - 0.15f);
        }
    }
}