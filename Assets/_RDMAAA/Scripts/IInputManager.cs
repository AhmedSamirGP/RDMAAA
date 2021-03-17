using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IInputManager : ScriptableObject
{
    public abstract bool GetForword();
    public abstract bool GetBackword();
    public abstract bool GetLeft();
    public abstract bool GetRight();
    public abstract bool Jump();
    public abstract bool UseJetPack();
    public abstract bool useTime();
}
