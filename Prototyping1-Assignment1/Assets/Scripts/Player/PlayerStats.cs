using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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
        powerBar.SetSlider(currentPower); 
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            TakeDamage(10f); 
        }
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount; 
        healthBar.SetSlider(currentHealth);
    }

    public void PowerUp(float amount)
    {
        //Health
        currentHealth += amount;
        healthBar.SetSlider(currentHealth);

        //Power
        currentPower += amount; 
        powerBar.SetSlider(currentPower); 
    }
}
