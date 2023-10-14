using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

/*==================== GAME OVER MANAGER ============================================
 * Attaches to: Empty game object (GameOverInstance)
 * Attribute(s): Private 
 * Purpose: Makes it possible to call a delay while running the code
 *          in ShutDownState
 ===================================================================================*/
public class GameOverManager : MonoBehaviour
{
    private static GameOverManager _instance;

    private void Awake()
    {
        if (_instance == null) _instance = this;
    }


    /*------------------RUN DEATH ADTER SECONDS-----------------------------------------------------
     * Parameters: float delay
     * Purpose: Creates delay before running Death()
     ---------------------------------------------------------------------------*/
    public static void RunDeathAfterSeconds(float delay)
    {
        Assert.IsNotNull(_instance);
        _instance.Invoke(nameof(Death), delay);
    }


    /*------------------DEATH-----------------------------------------------------
     * Parameters: None
     * Purpose: Unlocks cursor and changes scene 
     ---------------------------------------------------------------------------*/
    private void Death()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None; UnityEngine.Cursor.visible = true;
        SceneManager.LoadScene("GameOverScene");
    }
}
