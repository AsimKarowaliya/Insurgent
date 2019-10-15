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
    //resume
    //exit - needs are you sure yes or no not save game
    //otpions - make options menu work 
    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    


    void Pause()
    {
        

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }


    public void LoadMenu()
    {
        // Debug.Log("Loading menu..");
        SceneManager.LoadScene("Main Menu");
    }

    public void QuiteGame()
    {
        Debug.Log("Quitting game..");
        Application.Quit();
    }

    public void OptionsMenu()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        SceneManager.LoadScene("Options menu test");
    }
}

