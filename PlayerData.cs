using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public static float hp;
    public static float maxhp;
    public static float stamina;
    public static float maxstamina;
    public static Vector3 position;
    public static int potion;
    public static int meat;
    public static int attack;
    public static int level;
    public static bool isStart;
    public Animator animator;
    // Start is called before the first frame update
    
    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            potion = 0;
            meat = 0;
            gameObject.transform.position = new Vector3(-210, 1, -126);
        }
    }
    private void Start()
    {
        maxhp = PlayerStatus.playerlifeMax;
        hp = PlayerStatus._playerlife;
        maxstamina = PlayerStatus.playerstaminaMax;
        stamina = PlayerStatus._playerstamina;
        attack = PlayerStatus._playerAttack;
        level = PlayerStatus.Level;
        if (isStart)
        {
            Load();
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        maxhp = PlayerStatus.playerlifeMax;
        hp = PlayerStatus._playerlife;
        maxstamina = PlayerStatus.playerstaminaMax;
        stamina = PlayerStatus._playerstamina;
        attack = PlayerStatus._playerAttack;
        level = PlayerStatus.Level;
        Debug.Log("Hp= " + hp);
        Debug.Log("Potion= " + potion);
        Debug.Log("Meat= " + meat);
        //Debug.Log("Stamina= " + stamina);
        Debug.Log("Level= " + level);
        Debug.Log("Attack= " + attack);
        animator.SetInteger("Level", level);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    public void PlayerPositionChange()
    {
        gameObject.transform.position = position;
    }
    public void Load()
    {
        PlayerStatus._playerlife = Transition.hp;
        PlayerStatus.playerlifeMax = Transition.maxhp;
        PlayerStatus._playerstamina = Transition.stamina;
        PlayerStatus.playerstaminaMax = Transition.maxstamina;
        PlayerStatus._playerAttack = Transition.attack;
        potion = Transition.potion;
        meat = Transition.meat;
        gameObject.transform.position = Transition.position;
        PlayerStatus.Level = Transition.level;
    }

    public static void Initialize()
    {
        PlayerStatus._playerlife = 50;
        PlayerStatus.playerlifeMax = 50;
        PlayerStatus._playerstamina = 50;
        PlayerStatus.playerstaminaMax = 50;
        PlayerStatus._playerAttack = 4;
        potion = 0;
        meat = 0;
        PlayerStatus.Level = 1;
    }
}
