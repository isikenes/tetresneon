using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject pauseScreen;
    public void GoGameScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void GoHomeScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void ActivateGOS()
    {

        gameOverScreen.SetActive(true);

    }

    public void ActivatePause()
    {
        
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void DeActivatePause()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);

    }
}
