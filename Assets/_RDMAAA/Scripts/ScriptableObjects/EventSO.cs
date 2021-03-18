using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EventSO : ScriptableObject
{
    List<SOEventListener> listeners = new List<SOEventListener>();
    public void register(SOEventListener listener)
    {
        if (!listeners.Contains(listener))
            listeners.Add(listener);
    }
    public void unRegister(SOEventListener listener)
    {
        listeners.Remove(listener);
    }
    public void Raise()
    {
        var currListeners = new List<SOEventListener>(listeners);
        foreach (var listener in currListeners)
        {
            listener.onEventRaised();
        }
    }
}
