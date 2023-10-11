using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public float powerUpAmount;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        { 
            other.GetComponent<PlayerStats>().PowerUp(powerUpAmount);
            Destroy(gameObject);
        }
    }
}
