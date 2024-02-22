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
        //Aktiviert Event bei kontakt mit Player
        if(other.GetComponent<Rigidbody2D>() != null)
        {
            InfoEvent.RaiseEvent();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //Deaktiviert Event bei kontakt mit Player
        if (other.GetComponent<Rigidbody2D>() != null)
        {
            EndInfoEvent.RaiseEvent();
        }
    }
}
