using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
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
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter (Collider other)
    {
        PlayerData.isStart = true;
        if (other.gameObject.tag == "Player")
        {
            Save();
            if (this.gameObject.tag == "Map1ToMap2")
            {
                position = new Vector3(1035, 0, -344);
                if (PlayerData.level == 1)
                {
                    level = 2;
                    LevelUp();
                }         
                SceneManager.LoadScene("Map2");
            }
            else if (this.gameObject.tag == "Map2ToMap1")
            {
                position = new Vector3(-120, 0, 143);
                
                SceneManager.LoadScene("Main");
            }
            else if (this.gameObject.tag == "Map2ToMap3")
            {
                position = new Vector3(377, -0.08f, -285);
                if (PlayerData.level == 2)
                {
                    level = 3;
                    LevelUp();
                }
                SceneManager.LoadScene("Map3");
            }
            else if (this.gameObject.tag == "Map3ToMap2")
            {
                position = new Vector3(979, 0, 339);
                
                SceneManager.LoadScene("Map2");
            }
            else if (this.gameObject.tag == "Map3ToMap4")
            {
                position = new Vector3(453.4f, 0, 286);
                if (PlayerData.level == 3)
                {
                    level = 4;
                    LevelUp();
                }
                SceneManager.LoadScene("Map4");
            }
            else if (this.gameObject.tag == "Map4ToMap3")
            {
                position = new Vector3(-490, 0, 2);
                
                SceneManager.LoadScene("Map3");
            }
            
        }
    }
    public void Save()
    {
        hp = PlayerData.hp;
        maxhp = PlayerData.maxhp;
        stamina = PlayerData.stamina;
        maxstamina = PlayerData.maxstamina;
        potion = PlayerData.potion;
        meat = PlayerData.meat;
        attack = PlayerData.attack;
        level = PlayerData.level;
    }
    public void LevelUp()
    {
        
        if (level == 2)
        {
            maxhp = 100;
            hp = maxhp - 50 + PlayerData.hp;
            attack = 8;
        }
        else if (level == 3)
        {
            maxhp = 150;
            hp = maxhp - 100 + PlayerData.hp;
            attack = 12;
        }
        else if (level == 4)
        {
            maxhp = 200;
            hp = maxhp - 150 + PlayerData.hp;
            attack = 16;
        }
    }
}
