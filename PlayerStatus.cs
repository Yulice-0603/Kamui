using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : ModelStatus
{
    public static float playerLifeMax => playerlifeMax;
    public static float playerLife => _playerlife;

    public static float playerStaminaMax => playerstaminaMax;
    public static float playerStamina => _playerstamina;

    public static int playerAttack => _playerAttack;

    [SerializeField] public static float playerlifeMax;
    [SerializeField] public static float playerstaminaMax;
    public static float _playerlife;
    public static float _playerstamina;
    [SerializeField] public static int _playerAttack;
    [SerializeField] public static int Level;
    private void Awake()
    {
        playerlifeMax = 50;
        playerstaminaMax = 50;
        _playerAttack = 4;
        _playerlife = playerlifeMax;
        _playerstamina = playerstaminaMax;
        Level = 1;
    }

    private void Update()
    {
        if(_playerstamina < playerstaminaMax)
        {
            _playerstamina += 10 * Time.deltaTime;
        }
        else
        {
            _playerstamina = playerStaminaMax;
        }
        if (_playerlife > playerlifeMax)
        {
            _playerlife = playerlifeMax;
        }
        if (_playerstamina > playerstaminaMax)
        {
            _playerstamina = playerstaminaMax;
        }
        
    }
    public void PlayerDamage(int damage)
    {
        if (_state == StateEnum.Die) return;
        _playerlife -= damage;
        _state = StateEnum.GetHit;
        _animator.SetTrigger("GetHit");
        if (_playerlife > 0) return;
        _playerlife = 0;
        _state = StateEnum.Die;
        _animator.SetTrigger("Death");
        OnDie();
    }
    protected override void OnDie()
    {
        base.OnDie();
        StartCoroutine(DestroyCoroutine());
    }

    //µ¹¤µ¤ì¤¿•r¤ÎÏûœç¥³¥ë©`¥Á¥ó¤Ç¤¹
    ///<returns></returns>
    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    public void OnTalkStart()
    {
        if (_state == StateEnum.Die) return;
        _state = StateEnum.talk;
    }
    public void OnTalkFinished()
    {
        if (_state == StateEnum.Die) return;
        _state = StateEnum.Normal;
    }

}
