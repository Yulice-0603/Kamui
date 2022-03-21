using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ModelStatus))]
public class ModelGetHit : MonoBehaviour
{
    private ModelStatus _status;
    [SerializeField] private Animator animator;
    [SerializeField] private Collider attackCollider;
    void Start()
    {
        _status = GetComponent<ModelStatus>();
    }
    public void OnGetHitStart()
    {

        // _status.GoToNormalStateifPossible();
        if (gameObject.tag == "Boss")
        {
            animator.SetBool("CanWalk", false);
            animator.SetBool("CanRun", false);
        }
        else
        {
            animator.SetBool("CanMove", false);
        }
    }
    public void OnGetHitFinished()
    {
        if (gameObject.tag == "Boss")
        {
            _status.GoToNormalStateifPossible();
            animator.SetBool("CanWalk", true);
            animator.SetBool("CanRun", true);
        }
        else
        {
            _status.GoToNormalStateifPossible();
            //animator.SetBool("CanMove", true);
        }
    }

    public void OnDeathStart()
    {
        attackCollider.enabled = false;
    }
    public void OnDeathFinished()
    {
        if (this.gameObject.tag == "Player")
        {
            StartCoroutine(DeathCoroutine());
            SceneManager.LoadScene("GameOver");
        }
        else if (this.gameObject.tag == "Boss")
        {
            StartCoroutine(DeathCoroutine());
            SceneManager.LoadScene("GameClear");
        }
        
    }
    private IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(2);
    }
}
