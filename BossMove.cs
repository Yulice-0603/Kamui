using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(EnemyStatus))]
public class BossMove : MonoBehaviour
{
    private RaycastHit[] _raycastHits = new RaycastHit[10];
    private NavMeshAgent _agent;
    [SerializeField] private Animator animator;
    [SerializeField] private LayerMask raycastLayerMask;
    private EnemyStatus _status;
    [SerializeField] private Collider collisionDetectorWalk;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _status = GetComponent<EnemyStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDetectObjectWalk(Collider collider)
    {
        if (!_status.IsMovable)
        {
            _agent.isStopped = true;
            animator.SetBool("CanWalk", false);
            animator.SetBool("CanRun", false);
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
                animator.SetBool("CanWalk", true);
                animator.SetBool("CanRun", false);
                _agent.destination = collider.transform.position;
            }
            else
            {
                _agent.isStopped = true;
                animator.SetBool("CanWalk", false);
                animator.SetBool("CanRun", false);
            }

        }
    }
    public void OnDetectObjectRun(Collider collider)
    {
        if (!_status.IsMovable)
        {
            _agent.isStopped = true;
            animator.SetBool("CanWalk", false);
            animator.SetBool("CanRun", false);
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
                collisionDetectorWalk.enabled = false;
                _agent.isStopped = false;
                animator.SetBool("CanRun", true);
                animator.SetBool("CanWalk", false);
                _agent.destination = collider.transform.position;
            }
            else
            {
                _agent.isStopped = true;
                animator.SetBool("CanRun", false);
                animator.SetBool("CanWalk", false);
            }

        }
    }

    public void ToRoar(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            _agent.isStopped = true;
            animator.SetTrigger("Roar");
        }
    }

    public void CollisionDetectorWalkActivate(Collider collider)
    {
        collisionDetectorWalk.enabled = true;
    }
}
