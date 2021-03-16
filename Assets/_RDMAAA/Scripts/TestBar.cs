using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBar : MonoBehaviour
{
    [SerializeField]
    UIBarSO bar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bar.Value -= Time.deltaTime * 20;
    }
}
