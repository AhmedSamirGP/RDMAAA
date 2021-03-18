using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InitializibleSO<T>
{
    T GetInitialValue();
    void SetValue(T initValue);
}
