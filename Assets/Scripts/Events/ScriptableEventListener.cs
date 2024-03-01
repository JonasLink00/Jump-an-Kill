using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScriptableEventListener : MonoBehaviour
{
    [SerializeField]
    private ScriptableEvent scriptableEvent;

    [SerializeField]
    private UnityEvent eventResponse;

    //Registriert sich in der Liste vom Script ScriptableEvent
    private void Awake()
    {
        scriptableEvent.Register(this);
    }

    //das passiert beim Zerstoren des Objekts
    private void OnDestroy()
    {
        Debug.Log("OnDestory: " + gameObject.name);
        scriptableEvent.UnRegister(this);
    }

    //Entfernt sich aus der Liste vom Script ScriptableEvent
    public void OnEventRaised()
    {
        Debug.Log("OnEventRaised: " + gameObject.name);
        eventResponse.Invoke();
    }
}
