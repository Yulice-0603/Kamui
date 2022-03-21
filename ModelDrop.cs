using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ModelStatus))]
public class ModelDrop : MonoBehaviour
{
    private ModelStatus _status;
    [SerializeField] public GameObject dropItem;
    // Start is called before the first frame update
    void Start()
    {
        _status = GetComponent<ModelStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Drop()
    {
        Instantiate(dropItem, this.gameObject.transform.position+new Vector3(0,1,0), Quaternion.identity);
    }
}
