using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ModelStatus))]
public class ModelAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private Collider attackCollider;

    private ModelStatus _status;
    
    void Start()
    {
        _status = GetComponent<ModelStatus>();
    }

    public void AttackifPossible()
    {
        if (!_status.IsAttackable) return;
        if (gameObject.tag == "Player")
        {
            _status.PlayerGoToAttackStateifPossible();
        }
        else
        {
            _status.EnemyGoToAttackStateifPossible();
        }
    }
    


    /// <summary>
    /// π•ìƒåùœÛ§¨π•ìƒπ†áÏ§À»Î§√§øïr§À∫Ù§–§Ï§Î
    /// </summary>
    /// <param name="collider"></param>
    public void OnattackRangeEnter(Collider collider)
    {
        AttackifPossible();
    }
    

    public void OnAttackStart()
    {
        if (this.gameObject.tag == "Player")
        {
            if (PlayerStatus._playerstamina > 0)
            {
                if (PlayerStatus._playerstamina > 30)
                {
                    PlayerStatus._playerstamina -= 30;
                }
                else
                {
                    PlayerStatus._playerstamina = 0;
                }
            }
        }
        
        attackCollider.enabled = true;
    }

    public void OnHitAttack(Collider collider)
    {
        
        if (collider.gameObject.tag == "Player")
        {
            var targetModel = collider.GetComponent<PlayerStatus>();
            if (null == targetModel) return;
            if (this.gameObject.tag == "Deer")
            {
                targetModel.PlayerDamage(4);
            }
            else if (this.gameObject.tag == "Fox")
            {
                targetModel.PlayerDamage(6);
            }
            else if (this.gameObject.tag == "Wolf")
            {
                targetModel.PlayerDamage(10);
            }

        }
        else
        {
            var targetModel = collider.GetComponent<ModelStatus>();
            if (null == targetModel) return;
            if (PlayerStatus._playerstamina > 0)
            {
                targetModel.Damage(PlayerStatus._playerAttack);
            }
            else
            {
                targetModel.Damage(PlayerStatus._playerAttack / 2);
            }
            
        }
        
    }

    public void OnAttackFinished()
    {
        attackCollider.enabled = false;
        StartCoroutine(CooldownCoroutine());
    }

    private IEnumerator CooldownCoroutine()
    {
        yield return new WaitForSeconds(attackCooldown);
        _status.GoToNormalStateifPossible();
    }
}
