using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
