using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class BindBar : MonoBehaviour
{
    [SerializeField]
    UIBarSO barData;

    Slider Slider;
    private void Start()
    {
        Slider = GetComponent<Slider>();
        Slider.value = barData.getPercentage();
    }
    public void UpdateBar()
    {
        Slider.value = barData.getPercentage();
    }
}
