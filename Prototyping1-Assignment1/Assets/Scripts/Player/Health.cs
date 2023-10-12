using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*==================== HEALTH =====================================
 * Attaches to: HealthBar (parent)
 * Attribute(s):
 * Purpose: Sets slider values for the healthbar.  
 =================================================================*/
public class Health : MonoBehaviour
{
    public Slider healthSlider;

    /*------------------SET SLIDER---------------------------------------------------
     * Parameters: Current health value
     * Purpose: Assigns new value to the filler of the
     *          healthbar slider.
     -------------------------------------------------------------------------------*/
    public void SetSlider(float amount)
    {
        healthSlider.value = amount; 
    }

    /*------------------SET SLIDER MAX-----------------------------------------------
     * Parameters: Max health value
     * Purpose: Assigns new value to the 
     *          healthbar slider.
     -------------------------------------------------------------------------------*/
    public void SetSliderMax(float amount)
    {
        healthSlider.maxValue = amount;
        SetSlider(amount); 
    }
}
