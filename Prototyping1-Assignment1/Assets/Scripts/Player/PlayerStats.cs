using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.MemoryProfiler;
using UnityEngine;

/*==================== PLAYER STATS ============================================
 * Attaches to: Player (parent)
 * Attribute(s): maxPower() 
 * Purpose: Increases and decreases players stats  
 ==============================================================================*/
public class PlayerStats : MonoBehaviour
{
    [Header("Power")]
    [SerializeField] float maxPower; 
    float currentPower;
    public Power powerBar;
    float newPowerBarSize; 

    [Header("Grow")]
    [SerializeField] float newScale;

    [Header("States")]
    static public int numOfPowerups;

    [Header("Change Photo")]
    ChangeProfileImage changePhoto;

    void Start()
    {
        //Power
        currentPower = 10f;
        powerBar.SetSliderMax(maxPower);
        powerBar.SetSlider(currentPower);

        //Grow
        newScale = 1;

        //Get photos 
        
 
    }

    void Update()
    {
    }

    /*------------------POWER UP---------------------------------------------------
     * Parameters: Power up amount
     * Purpose: Increases players power and assigns new values to the 
     *          power slider.
     -----------------------------------------------------------------------------*/
    public void PowerUp(float amount)
    {
        //Power
        if (currentPower >= maxPower)
        {
            newPowerBarSize = newPowerBarSize + 0.2f;
            transform.localScale = new Vector3(newPowerBarSize, 0, 0);

            maxPower = currentPower;
            powerBar.SetSliderMax(maxPower);
            powerBar.SetSlider(currentPower);
        }
        else
        {
            currentPower += amount;
            powerBar.SetSlider(currentPower);
        }

        numOfPowerups++;
        GrowPlayer();
        //ChangeProfilePhoto(); 
    }

    /*------------------GROW PLAYER---------------------------------------------------
     * Parameters: None
     * Purpose: Makes the players body bigger everytime they pick up 
     *          a powerup. 
     -----------------------------------------------------------------------------*/
    public void GrowPlayer()
    {
        newScale = newScale + 0.2f;
        transform.localScale = new Vector3(newScale, newScale, newScale); 
    }

    /*------------------CHANGE PROFILE PHOTO----------------------------------------
     * Parameters: None
     * Purpose: Changes the profile photo on the UI depending on how many 
     *          powerups have been collected. 
     * FIX: 
     * Value not assigend? 
     -----------------------------------------------------------------------------*/
    public void ChangeProfilePhoto()
    {
        switch(numOfPowerups)
        {
            case 0:
                ChangeProfileImage.NextProfilePhoto(); 
                break; 
            case 3:
                ChangeProfileImage.NextProfilePhoto();
                break;
            case 9:
                ChangeProfileImage.NextProfilePhoto();
                break;
            case 13:
                ChangeProfileImage.NextProfilePhoto();
                break;
            case 15:
                ChangeProfileImage.NextProfilePhoto();
                break;
            case 17:
                ChangeProfileImage.NextProfilePhoto();
                break;
            case 19:
                ChangeProfileImage.NextProfilePhoto();
                break;
        }
    }
}
