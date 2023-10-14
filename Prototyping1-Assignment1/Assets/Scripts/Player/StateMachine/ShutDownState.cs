using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

/*==================== SHUT DOWN STATE ============================================
 * Attaches to: None
 * Attribute(s): Private 
 * Purpose: Handles player movement during Shut Down state.  
 ==============================================================================*/
public class ShutDownState : PlayerBaseState
{
    float movSpeed, rotSpeed;
    int oldNumOfPowerUps, newNumOfPowerUps;

    /*------------------ENTER STATE----------------------------------------------
     * Parameters: player
     * Purpose: Sets movement speed and camera rotation speed
     ---------------------------------------------------------------------------*/
    public override void EnterState(PlayerStateManager player)
    {
        movSpeed = 7f;
        rotSpeed = 200f;

        PlayerMovement1.SetMovementSpeed(movSpeed);
        FirstPersonCamera.SetRotationSpeed(rotSpeed, rotSpeed);
    }


    /*------------------UPDATE STATE---------------------------------------------
     * Parameters: player
     * Purpose: Everytime the player picks up a power up
     *          the movement and camera rotation speed slow down. 
     ---------------------------------------------------------------------------*/
    public override void UpdateState(PlayerStateManager player)
    {
        newNumOfPowerUps = PlayerStats.numOfPowerups;

        if (newNumOfPowerUps > oldNumOfPowerUps)
        {
            movSpeed = movSpeed - 1f;
            rotSpeed = rotSpeed - 28f;

            oldNumOfPowerUps = newNumOfPowerUps;

            PlayerMovement1.SetMovementSpeed(movSpeed);
            FirstPersonCamera.SetRotationSpeed(rotSpeed, rotSpeed);

            if(movSpeed < 1 || rotSpeed < 1)
            {
                //SomeMono.StartCoroutine("DoCoroutine", this.AwaitDeath()); 
                Death(); 
            }
        }
    }


    /*------------------AWAIT DEATH-----------------------------------------------
     * Parameters: None
     * Purpose: Waits x seconds before running Death()
     ---------------------------------------------------------------------------*/
    private IEnumerator AwaitDeath()
    {
        yield return new WaitForSeconds(3f);
        Death(); 
    }


    /*------------------DEATH-----------------------------------------------------
     * Parameters: None
     * Purpose: Unlocks cursor and changes scene 
     ---------------------------------------------------------------------------*/
    public void Death()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None; UnityEngine.Cursor.visible = true;
        SceneManager.LoadScene("GameOverScene");
    }



    /*------------------SOME MONO-------------------------------------------------
     * Parameters: IEnumerator Coroutine 
     * Purpose: StartCoroutine() Needs Monobehaviour to work 
     *          this class is to run that function. 
     ---------------------------------------------------------------------------*/
    public class SomeMono : MonoBehaviour
    {
        static public IEnumerator DoCoroutine(IEnumerator cor)
        {
            while(cor.MoveNext())
                yield return cor.Current; 
        }
    }
}
