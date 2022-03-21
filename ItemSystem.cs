using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSystem : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            if (this.gameObject.tag == "Potion")
            {
                PlayerData.potion++;
            }
            else if (this.gameObject.tag == "Meat")
            {
                PlayerData.meat++;
            }
            Destroy(this.gameObject.transform.parent.gameObject);
        }
    }
}
