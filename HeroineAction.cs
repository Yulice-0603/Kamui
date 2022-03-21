using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerStatus))]
[RequireComponent(typeof(ModelAttack))]
public class HeroineAction : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private Animator animator;
    private CharacterController characterController;
    private Transform _transform;
    private Vector3 moveVelocity;
    private bool WeaponSwitch;
    [SerializeField] GameObject Sword;
    private PlayerStatus _status;
    private ModelAttack _attack;
    private bool IsGrounded
    {
        get
        {
            var ray = new Ray(_transform.position + new Vector3(0,0,0.1f),Vector3.down);
            var raycastHits = new RaycastHit[1];
            var hitCount = Physics.RaycastNonAlloc(ray,raycastHits,0.2f);
            return hitCount >=1;
        }
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        _transform = transform;
        WeaponSwitch = false;
        Sword.SetActive(false);
        _status = GetComponent<PlayerStatus>();
        _attack = GetComponent<ModelAttack>();
    }

    
    void Update()
    {
        if (_status.IsMovable && animator.GetBool("CanMove"))
        {
            //入力軸による移動処理
            var horizontal = CrossPlatformInputManager.GetAxis("Horizontal")*moveSpeed;
            var vertical = CrossPlatformInputManager.GetAxis("Vertical")*moveSpeed;
            //カメラ向きの調整
            var horizontalRotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y,Vector3.up);
            moveVelocity = horizontalRotation * new Vector3(horizontal,moveVelocity.y, vertical);
            //Debug.Log(IsGrounded?"地上にいます":"空中です");
            //移動方向に向く
            _transform.LookAt(_transform.position + new Vector3(moveVelocity.x,0,moveVelocity.z));
        }
        else
        {
            moveVelocity.x = 0;
            moveVelocity.z = 0;
        }
        if (IsGrounded)
        {
            /*
            if (Input.GetButtonDown("Jump"))
            {
                //ジャンプ処理
                moveVelocity.y = jumpPower;
                animator.SetBool("Jump",true);
                Debug.Log("ジャンプ");           
            }*/
        }
        else
        {
            //重力による加速
            moveVelocity.y += Physics.gravity.y * Time.deltaTime;
            animator.SetBool("Jump",false);
        }
        if (_status.IsMovable && animator.GetBool("CanMove"))
        {
            //オブジェクトを動かす
        characterController.Move(moveVelocity * Time.deltaTime);
        }
        animator.SetFloat("MoveSpeed",new Vector3(moveVelocity.x,0,moveVelocity.z).magnitude);
        animator.SetBool("WeaponSwitch",WeaponSwitch);
        //武器のスイッチ
        if (!WeaponSwitch)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetBool("CanMove",false);
                Sword.SetActive(true);
                WeaponSwitch = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                animator.SetBool("CanMove",false);
                Sword.SetActive(false);
                WeaponSwitch = false;
            }
            if (Input.GetMouseButtonDown(0))
            {
                _attack.AttackifPossible();
                //animator.SetTrigger("Attack");
                animator.SetBool("CanMove",false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (PlayerData.meat > 0)
            {
                PlayerData.meat--;
                PlayerStatus.playerstaminaMax += 20;
                PlayerStatus._playerstamina += 20;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (PlayerData.potion > 0)
            {
                PlayerData.potion--;
                PlayerStatus._playerlife += 25;
                
            }
        }
        die();
    }
    public void die()
    {
        if (gameObject.transform.position.y < -30.0f )
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
