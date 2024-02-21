using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/ScriptableEvent")]
public class ScriptableEvent : ScriptableObject
{
    private List<ScriptableEventListener> listenerList = new List<ScriptableEventListener>();

    public void Register(ScriptableEventListener _listener)
    {
        listenerList.Add(_listener);
    }

    public void UnRegister(ScriptableEventListener _listener)
    {
        if(listenerList.Count <= 0)
            return;
        listenerList.Remove(_listener);
    }

    public void RaiseEvent()
    {
        // alle Listener bekommen bescheid
        for (int i = 0; i < listenerList.Count; i++)
        {
            listenerList[i].OnEventRaised();
        }
    }
}
