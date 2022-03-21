using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(EnemyStatus))]
public class EnemyMove : MonoBehaviour
{
    private RaycastHit[] _raycastHits = new RaycastHit[10];
    private NavMeshAgent _agent;
    [SerializeField] private Animator animator;
    [SerializeField] private LayerMask raycastLayerMask;
    private EnemyStatus _status;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _status = GetComponent<EnemyStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (_agent.remainingDistance < 1.5f)
        {
            animator.SetBool("CanMove", false);
        }*/
    }

    public void OnDetectObject(Collider collider)
    {
        if (!_status.IsMovable)
        {
            _agent.isStopped = true;
            animator.SetBool("CanMove", false);
            return;
        }
        if (collider.CompareTag("Player"))
        {
            var positionDiff = collider.transform.position - transform.position;
            var distance = positionDiff.magnitude;
            var direction = positionDiff.normalized;
            var hitCount = Physics.RaycastNonAlloc(transform.position, direction, _raycastHits, distance, raycastLayerMask);
            //Debug.Log("hitCount" + hitCount);
            if (hitCount == 0)
            {
                _agent.isStopped = false;
                animator.SetBool("CanMove", true);
                _agent.destination = collider.transform.position;
            }
            else
            {
                _agent.isStopped = true;
                animator.SetBool("CanMove", false);
            }

        }
    }

    public void ToHowl(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            _agent.isStopped = true;
            animator.SetTrigger("Howl");
        }
    }
    /*
    public void OffDetectObject(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            animator.SetBool("CanMove", false);
        }
    }*/
}
