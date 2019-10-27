using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{

    //new game
    //saved game
    //options 
    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
        SceneManager.LoadScene("InGame");
        
    }

    public void OptionsMenu()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        SceneManager.LoadScene("Options menu test");
    }

    public void ExitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();

    }
}
