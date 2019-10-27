using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }


    public void LoadMenu()
    {
        // Debug.Log("Loading menu..");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void BossBattle()
    {
        // Debug.Log("Loading menu..");
        Time.timeScale = 1f;
        SceneManager.LoadScene("BossBattle");
    }

    public void QuiteGame()
    {
        Debug.Log("Quitting game..");
        //Application.Quit();
        SceneManager.LoadScene("Main Menu");
    }

    public void ExitGame()
    {
        Debug.Log("Exiting game..");
        Application.Quit();
    }

    public void OptionsMenu()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        SceneManager.LoadScene("Options menu test");
    }
}

