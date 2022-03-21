using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModelStatus : MonoBehaviour
{
    //状態の定義
    protected enum StateEnum
    {
        Normal,
        Attack,
        Attack1,
        GetHit,
        talk,
        Die
    }

    //移動可能かどうか
    public bool IsMovable => StateEnum.Normal == _state;

    //攻撃可能かどうか
    public bool IsAttackable => (
        StateEnum.Normal == _state||
        StateEnum.Attack1 == _state
        
        );

    //ライフ最大値
    public float LifeMax => lifeMax;

    //ライフの値
    public float Life => _life;

    [SerializeField] float lifeMax = 10;
    protected Animator _animator;
    protected StateEnum _state = StateEnum.Normal;
    private float _life;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        _life = lifeMax;
        _animator = GetComponent<Animator>();
    }

    protected virtual void OnDie() 
    {
        
    }
    protected virtual void OnGetHit()
    {
        
        
    }
    /// <param name="damage"></param>
    public void Damage(int damage)
    {
        if (_state == StateEnum.Die) return;
        _life -= damage;
        _state = StateEnum.GetHit;
        _animator.SetTrigger("GetHit");
        if (_life > 0) return;
        _state = StateEnum.Die;
        //this.gameObject.GetComponent<Collider>().enabled = false;
        _animator.SetTrigger("Death");
        OnDie();
    }
    

    public void EnemyGoToAttackStateifPossible()
    {
        if (!IsAttackable)return;
        
        _state = StateEnum.Attack;
       
        _animator.SetTrigger("Attack");
        
        
        
    }
    public void PlayerGoToAttackStateifPossible()
    {
        if (!IsAttackable) return;
        
        _state = StateEnum.Attack1;

        _animator.SetTrigger("Attack");

    }
    public void BossGoToAttackStateifPossible(int Num)
    {
        if (!IsAttackable) return;

        _state = StateEnum.Attack;

        _animator.SetTrigger("Attack"+Num);

    }

    public void GoToNormalStateifPossible()
    {
        if (_state == StateEnum.Die)return;

        _state = StateEnum.Normal;
    }
}
