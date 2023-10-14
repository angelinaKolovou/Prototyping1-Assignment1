using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCube : MonoBehaviour
{
    static Renderer ren; 
    // Start is called before the first frame update
    void Start()
    {
        ren = GetComponent<Renderer>();
    }

    static public void ChangeColour(bool canLift)
    {
        if (canLift)
        {
            Debug.Log("New Colour");
            ren.material.color = Color.yellow;

        }
    }
}
