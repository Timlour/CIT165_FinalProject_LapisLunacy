using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        //Start the game
        SceneManager.LoadScene(1);
    }//end of NewGame

    public void Options()
    {

    }//end of Options

    public void QuitGame()
    {
        Application.Quit();
    }//end of QuitGame
}
