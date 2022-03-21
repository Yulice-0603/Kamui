using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ModelStatus))]
public class ModelBossAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private Collider attackCollider1;
    [SerializeField] private Collider attackCollider2;
    [SerializeField] private Collider attackCollider3;
    [SerializeField] private Collider attackCollider4;
    [SerializeField] private Collider attackRangeDetector3;
    [SerializeField] private Collider attackRangeDetector4;

    private ModelStatus _status;

    void Start()
    {
        _status = GetComponent<ModelStatus>();
    }

    public void BossAttackifPossible12()
    {
        if (!_status.IsAttackable) return;
        else if (gameObject.tag == "Boss")
        {
            _status.BossGoToAttackStateifPossible(Random.Range(1, 3));
        }

    }
    public void BossAttackifPossible3()
    {
        if (!_status.IsAttackable) return;
        else if (gameObject.tag == "Boss")
        {
            _status.BossGoToAttackStateifPossible(3);
        }

    }
    public void BossAttackifPossible4()
    {
        if (!_status.IsAttackable) return;
        else if (gameObject.tag == "Boss")
        {
            _status.BossGoToAttackStateifPossible(4);
        }

    }


    /// <summary>
    /// π•ìƒåùœÛ§¨π•ìƒπ†áÏ§À»Î§√§øïr§À∫Ù§–§Ï§Î
    /// </summary>
    /// <param name="collider"></param>
    public void BossOnattackRangeEnter12(Collider collider)
    {
        attackRangeDetector4.enabled = false;
        BossAttackifPossible12();
    }
    public void BossOnattackRangeEnter3(Collider collider)
    {
        BossAttackifPossible3();
    }
    public void BossOnattackRangeEnter4(Collider collider)
    {
        attackRangeDetector3.enabled = false;
        BossAttackifPossible4();
    }

    public void OnAttackStart1()
    {
        attackCollider1.enabled = true;
        
    }
    public void OnAttackStart2()
    {
        attackCollider2.enabled = true;
        
    }
    public void OnAttackStart3()
    {
        attackCollider3.enabled = true;
    }
    public void OnAttackStart4()
    {
        attackCollider4.enabled = true;
    }

    public void OnHitAttack(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            var targetModel = collider.GetComponent<PlayerStatus>();
            if (null == targetModel) return;

            targetModel.PlayerDamage(20);
        }
            
    }

    public void OnAttackFinished()
    {
        attackCollider1.enabled = false;
        attackCollider2.enabled = false;
        attackCollider3.enabled = false;
        attackCollider4.enabled = false;
        StartCoroutine(CooldownCoroutine());
    }

    private IEnumerator CooldownCoroutine()
    {
        yield return new WaitForSeconds(attackCooldown);
        _status.GoToNormalStateifPossible();
    }


    public void AttackRangeDetector3Activate(Collider collider)
    {
        attackRangeDetector3.enabled = true;
    }

    public void AttackRangeDetector4Activate(Collider collider)
    {
        attackRangeDetector4.enabled = true;
    }
}
