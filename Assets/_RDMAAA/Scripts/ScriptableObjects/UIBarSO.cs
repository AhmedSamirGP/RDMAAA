using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UIBarSO : ScriptableObject, InitializibleSO<float>
{
    [SerializeField]
    EventSO ValueChanged;
    [SerializeField]
    float initialValue;
    float _value = 100;
    private void OnEnable()
    {
        if(initialValue >= 0)
        _value = initialValue;
    }
    public float Value { 
        get
        {
            return _value;
        }
        set
        {
            if (value >= 0)
            {
                _value = value;
                if (ValueChanged)
                    ValueChanged.raise();
            }
        }
    }
    [SerializeField]
    float MaxValue = 100;
    public float getPercentage()
    {
        return Value / MaxValue;
    }

    public float GetInitialValue()
    {
        return initialValue;
    }

    public void SetValue(float initValue)
    {
        Value = initValue;
    }
}
