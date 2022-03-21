using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyStatus : ModelStatus
{
    private NavMeshAgent _agent;

    protected override void Start()
    {
        base.Start();
        _agent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        //_animator.SetFloat("MoveSpeed", _agent.velocity.magnitude);
    }

    protected override void OnDie()
    {
        base.OnDie();
        StartCoroutine(DestroyCoroutine());
    }

    //�����줿�r�����祳��`����Ǥ�
    ///<returns></returns>
    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

}
