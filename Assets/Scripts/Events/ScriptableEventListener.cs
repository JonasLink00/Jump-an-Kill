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

    private void Awake()
    {
        scriptableEvent.Register(this);
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestory: " + gameObject.name);
        scriptableEvent.UnRegister(this);
    }

    public void OnEventRaised()
    {
        Debug.Log("OnEventRaised: " + gameObject.name);
        eventResponse.Invoke();
    }
}
