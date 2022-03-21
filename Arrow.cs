using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arrow : MonoBehaviour
{
    public GameObject player;
    private Transform targetTransform;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = player.transform.position - new Vector3(0, 0.9f, 0);
        if(SceneManager.GetActiveScene().name == "Main")
        {
            targetTransform = GameObject.Find("scout1").transform;
        }
        else if (SceneManager.GetActiveScene().name == "Map2")
        {
            targetTransform = GameObject.Find("BridgeEvent").transform;
        }
        else if (SceneManager.GetActiveScene().name == "Map3")
        {
            targetTransform = GameObject.Find("women").transform;
        }
        else if (SceneManager.GetActiveScene().name == "Map4")
        {
            targetTransform = GameObject.Find("Bear").transform;
        }


    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = player.transform.position - new Vector3(0, 0.9f, 0);
        var dis = targetTransform.position - transform.position;
        dis.y = 0;
        var dir = Vector3.SignedAngle(Vector3.right, dis, Vector3.up);
        this.transform.rotation = Quaternion.Euler(-90f, 0.0f, dir);
    }

    public void ChangeTarget()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            if (targetTransform == GameObject.Find("scout1").transform)
            {
                targetTransform = GameObject.Find("Map1ToMap2").transform;
            }
        }
        else if (SceneManager.GetActiveScene().name == "Map2")
        {
            if (targetTransform == GameObject.Find("BridgeEvent").transform)
            {
                targetTransform = GameObject.Find("man").transform;
            }
            else if (targetTransform == GameObject.Find("man").transform)
            {
                targetTransform = GameObject.Find("Map2ToMap3").transform;
            }
        }
        else if (SceneManager.GetActiveScene().name == "Map3")
        {
            if (targetTransform == GameObject.Find("women").transform)
            {
                targetTransform = GameObject.Find("man1").transform;
            }
            else if (targetTransform == GameObject.Find("man1").transform)
            {
                targetTransform = GameObject.Find("Map3ToMap4").transform;
            }
        }
    }
}
