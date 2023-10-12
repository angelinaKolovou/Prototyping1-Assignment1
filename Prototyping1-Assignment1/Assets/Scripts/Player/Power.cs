using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*==================== POWER =====================================
 * Attaches to: PowerBar (parent)
 * Attribute(s):
 * Purpose: Sets slider values for the Powerbar.  
 ===============================================================*/
public class Power : MonoBehaviour
{
    public Slider powerSlider;

    /*------------------SET SLIDER---------------------------------------------------
     * Parameters: Current power value
     * Purpose: Assigns new value to the filler of the
     *          powerbar slider.
     ------------------------------------------------------------------------------*/
    public void SetSlider(float amount)
    {
        powerSlider.value = amount;
    }

    /*------------------SET SLIDER MAX-----------------------------------------------
     * Parameters: Max power value
     * Purpose: Assigns new value to the 
     *          powerbar slider.
     -------------------------------------------------------------------------------*/
    public void SetSliderMax(float amount)
    {
        powerSlider.maxValue = amount;
        SetSlider(amount);
    }
}
