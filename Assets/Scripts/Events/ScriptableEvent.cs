using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/ScriptableEvent")]
public class ScriptableEvent : ScriptableObject
{
    private List<ScriptableEventListener> listenerList = new List<ScriptableEventListener>();

    //Alle Objekte die einen ScriptableEventListener haben tragen sich in eine Liste ein
    public void Register(ScriptableEventListener _listener)
    {
        listenerList.Add(_listener);
    }

    // Alle Objekte die einen ScriptableEventListener haben tragen sich aus einer Liste aus
    public void UnRegister(ScriptableEventListener _listener)
    {
        if(listenerList.Count <= 0)
            return;
        listenerList.Remove(_listener);
    }

    // Events werden ausgelöhst
    public void RaiseEvent()
    {
        // alle Listener bekommen bescheid
        for (int i = 0; i < listenerList.Count; i++)
        {
            listenerList[i].OnEventRaised();
        }
    }
}
