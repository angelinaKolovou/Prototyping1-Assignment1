using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Power : MonoBehaviour
{
    public Slider powerSlider;

    public void SetSlider(float amount)
    {
        powerSlider.value = amount;
    }
}
