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

    private int currentPhoto = 0;

    /*------------------NEXT PROFILE PHOTO---------------------------------------------------
     * Parameters: None
     * Purpose: Goes through the list and assigns a sprite to the image in canvas. 
     --------------------------------------------------------------------------------------*/
    public void NextProfilePhoto()
    {
        currentPhoto++;
        Debug.Log("inside the function");

        //Makes sure the counter goes back to 0 if its larger than the list index 
        if (currentPhoto >= listOfPhotos.Count)
        {
            Debug.Log("Shouldnt be here yet");
            currentPhoto = 0;

        }
        Debug.Log("Change Image");

        image.sprite = listOfPhotos[currentPhoto];
    }
}
