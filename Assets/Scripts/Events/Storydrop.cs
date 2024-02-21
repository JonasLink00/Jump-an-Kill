using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storydrop : MonoBehaviour
{
    [SerializeField]
    private ScriptableEvent InfoEvent2;
    [SerializeField]
    private ScriptableEvent EndInfoEvent2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Rigidbody2D>() != null)
        {
            InfoEvent2.RaiseEvent();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Rigidbody2D>() != null)
        {
            EndInfoEvent2.RaiseEvent();
        }
    }
}
