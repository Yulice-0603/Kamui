using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    float hp;
    float maxhp;
    float dishp;
    float stamina;
    float maxstamina;
    float disstamina;
    int potion;
    int meat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hp = PlayerData.hp;
        maxhp = PlayerData.maxhp;
        dishp = 67.5f + 452.0f * (1.0f - (hp / maxhp));
        stamina = PlayerData.stamina;
        maxstamina = PlayerData.maxstamina;
        disstamina = 67.5f + 452.0f * (1.0f - (stamina / maxstamina));
        potion = PlayerData.potion;
        meat = PlayerData.meat;
        if (this.gameObject.name == "HpBar")
        {
            gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(-dishp, -48.0f);
        }
        else if(this.gameObject.name == "StaminaBar")
        {
            gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(-disstamina, -113.0f);
        }
        else if (this.gameObject.name == "Hp")
        {
            gameObject.GetComponent<Text>().text = hp.ToString("###");
        }
        else if (this.gameObject.name == "Stamina")
        {
            gameObject.GetComponent<Text>().text = stamina.ToString("###");
        }
        else if (this.gameObject.name == "meat")
        {
            gameObject.GetComponent<Text>().text = meat.ToString();
        }
        else if (this.gameObject.name == "potion")
        {
            gameObject.GetComponent<Text>().text = potion.ToString();
        }
    }
}
