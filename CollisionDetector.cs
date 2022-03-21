using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private TriggerEvent onTriggerEnter = new TriggerEvent();
    [SerializeField] private TriggerEvent onTriggerStay = new TriggerEvent();
    [SerializeField] private TriggerEvent onTriggerExit = new TriggerEvent();



    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke(other);
    }
    /// <summary>
    /// Is Trigger��ON������Collider���ؤʤäƤ���r�ϡ����Υ᥽�åɤ����˥��`�뤵���
    /// </summary>
    /// <param name="other">�nͻ����</param>
    private void OnTriggerStay(Collider other)
    {
        onTriggerStay.Invoke(other);
    }
    
    private void OnTriggerExit(Collider other)
    {
        onTriggerExit.Invoke(other);
    }
    [Serializable] public class TriggerEvent:UnityEvent<Collider>
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
