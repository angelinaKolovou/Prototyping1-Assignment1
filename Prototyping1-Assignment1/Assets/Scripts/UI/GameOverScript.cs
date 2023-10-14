using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*==================== GAME OVER SCRIPT ============================================
 * Attaches to: Game Over Background (Canvas UI)
 * Attribute(s): None
 * Purpose: Handles Quit button in game over scene
 ===================================================================================*/
public class GameOverSript : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
