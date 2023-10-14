using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

/*==================== CHANGE PROFILE IMAGE ============================================
 * Attaches to: Canvas
 * Attribute(s): Image(Canvas/Image), List(sprites)
 * Purpose: Changes the sprite in Image object on UI  
 ==============================================================================*/
public class ChangeProfileImage : MonoBehaviour
{
    public Image image; 
    public List<Sprite> listOfPhotos;

    public int currentPhoto = 0;
    int oldNumOfP, newNumOfP; 
    bool next; 

    /*------------------NEXT PROFILE PHOTO---------------------------------------------------
     * Parameters: None
     * Purpose: Goes through the list and assigns a sprite to the image in canvas. 
     --------------------------------------------------------------------------------------*/
    public void Update()
    {
        newNumOfP = PlayerStats.numOfPowerups;

        if (newNumOfP > oldNumOfP)
        {
            if(CheckNext())
            {
                NextProfilePhoto();
            }
            oldNumOfP = newNumOfP;
        }
    }

    public void NextProfilePhoto()
    {
        currentPhoto++;
        //Makes sure the counter goes back to 0 if its larger than the list index 
    
        if (currentPhoto >= listOfPhotos.Count)
        {
            Debug.Log("Shouldnt be here yet");
            currentPhoto = 0;

        }

        Debug.Log("Change Image");
        image.sprite = listOfPhotos[currentPhoto];
        next = false; 
    }


    /*------------------CHANGE PROFILE PHOTO----------------------------------------
 * Parameters: None
 * Purpose: Changes the profile photo on the UI depending on how many 
 *          powerups have been collected. 
 -----------------------------------------------------------------------------*/
    public bool CheckNext()
    {
        switch (PlayerStats.numOfPowerups)
        {
            case 0:
                next = true;
                break;
            case 3:
                next = true;
                break;
            case 9:
                next = true;
                break;
            case 13:
                next = true;
                break;
            case 15:
                next = true;
                break;
            case 17:
                next = true;
                break;
            case 19:
                next = true;
                break;
            default:
                next = false;
                break; 
        }

        return next; 

    }
}
