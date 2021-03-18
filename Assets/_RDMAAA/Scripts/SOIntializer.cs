using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOIntializer : MonoBehaviour
{
    [SerializeField]
    ScriptableObject[] InitializiblesArray;
    private void Start()
    {
        for (int i = 0; i < InitializiblesArray.Length; i++)
        {
            InitializibleSO<float> SO = InitializiblesArray[i] as InitializibleSO<float>;
            if(SO != null)
            {
                SO.SetValue(SO.GetInitialValue());
            }
        }
    }
}
