using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    //Array of all menu states
    //ASSUMPTIONS:
    /*
     * 0 = Main Menu
     * 1 = Options Menu
     */
    public GameObject[] menuStates;
    public Slider musicSlider;
    public Slider soundSlider;

    private int currentMenuState;

    // Start is called before the first frame update
    void Start()
    {
        //Start on the title screen
        currentMenuState = 0;
        menuStates[0].SetActive(true);
        menuStates[1].SetActive(false);

        //If this is the player's first time opening the game, set the default volumes
        if (PlayerPrefs.GetInt("FirstRun") == 0)
        {
            PlayerPrefs.SetFloat("MusicVol", 0.5f);
            PlayerPrefs.SetFloat("SoundVol", 0.5f);
            PlayerPrefs.SetInt("FirstRun", 1);
        }

        //Set any existing PlayerPrefs
        musicSlider.value = PlayerPrefs.GetFloat("MusicVol");
        soundSlider.value = PlayerPrefs.GetFloat("SoundVol");
    }

    public void NewGame()
    {
        //Start the game
        SceneManager.LoadScene(1);
    }//end of NewGame

    public void Options()
    {
        switch (currentMenuState)
        {
            case 0:
                //Switch to the options menu
                changeMenu(currentMenuState, 1);
                break;
            case 1:
                //Switch back to the main menu
                changeMenu(currentMenuState, 0);
                break;
        }
    }//end of Options



    public void QuitGame()
    {
        Application.Quit();
    }//end of QuitGame

    private void changeMenu(int currentState, int nextGameState)
    {
        //Swap between the current menu state and the desired menu state
        menuStates[currentState].SetActive(false);
        menuStates[nextGameState].SetActive(true);
        currentMenuState = nextGameState;
    }//end of changeMenu
}
