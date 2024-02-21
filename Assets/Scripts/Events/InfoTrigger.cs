using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTrigger : MonoBehaviour
{
    [SerializeField]
    private ScriptableEvent InfoEvent;
    [SerializeField]
    private ScriptableEvent EndInfoEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Rigidbody2D>() != null)
        {
            InfoEvent.RaiseEvent();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Rigidbody2D>() != null)
        {
            EndInfoEvent.RaiseEvent();
        }
    }
}
