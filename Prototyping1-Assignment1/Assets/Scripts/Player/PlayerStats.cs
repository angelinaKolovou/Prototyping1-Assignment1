using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*==================== PLAYER STATS ============================================
 * Attaches to: Player (parent)
 * Attribute(s): maxHealth(), maxPower() 
 * Purpose: Increases and decreases players stats  
 ==============================================================================*/
public class PlayerStats : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] float maxHealth;
    float currentHealth;
    public Health healthBar;

    [Header("Power")]
    [SerializeField] float maxPower; 
    float currentPower;
    public Power powerBar; 
    

    void Start()
    {
        //Health
        currentHealth = maxHealth;
        healthBar.SetSliderMax(maxHealth);

        //Power
        currentPower = 10f;
        powerBar.SetSliderMax(maxHealth);
        powerBar.SetSlider(currentPower); 
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            TakeDamage(10f); 
        }
    }

    /*------------------TAKE DAMAGE---------------------------------------------------
     * Parameters: Damage amount
     * Purpose: Reduces player health and assigns new value to the 
     *          healthbar slider.
     --------------------------------------------------------------------------------*/
    public void TakeDamage(float amount)
    {
        currentHealth -= amount; 
        healthBar.SetSlider(currentHealth);
    }

    /*------------------POWER UP---------------------------------------------------
     * Parameters: Power up amount
     * Purpose: Increases player health and power and assigns new values to the 
     *          healthbar and power sliders.
     -----------------------------------------------------------------------------*/
    public void PowerUp(float amount)
    {
        //Health
        if (currentHealth >= maxHealth)
        {
            maxHealth = currentHealth;
            healthBar.SetSliderMax(maxHealth);
            healthBar.SetSlider(currentHealth);
        }
        else
        {
            currentHealth += amount;
            healthBar.SetSlider(currentHealth);
        }

        //Power
        if (currentPower >= maxPower)
        {
            maxPower = currentPower;
            powerBar.SetSliderMax(maxPower);
            powerBar.SetSlider(currentPower);
        }
        else
        {
            currentPower += amount;
            powerBar.SetSlider(currentPower);
        }

    }
}
