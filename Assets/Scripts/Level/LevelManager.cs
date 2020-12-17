using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI timerText, finalTimeText;
    public GameObject inGameUI, gameOverUI, gameWinUI;
    public int timeLimitSeconds = 60;
    public int secondsUntilTitleScreen = 5;

    private bool gameActive = true;
    private float timerUntilMainMenu;

    //Items
    PlayerData levelData;

    CanvasGroup canvGroup;
    UIFader uiFader;

    // Start is called before the first frame update
    void Start()
    {
        //New game data
        levelData = new PlayerData(timeLimitSeconds);

        //UI Fader
        uiFader = gameObject.GetComponent<UIFader>();
    }

    // Update is called once per frame
    void Update()
    {
        //Update in-game timer while the level is active
        if (gameActive)
        {
            levelData = TimerData.UpdateTimer(levelData);

            //If the timer has reached or passed 0, time is up
            if ((levelData.getMinutes() == 0 && levelData.getSeconds() == 0 && levelData.getTimer() < 60) || levelData.getMinutes() < 0)
            {
                timerText.text = "Time's Up!";
                //End the game, as the player lost
                GameOverScreen();
            }
            else
            {
                //If there are less than 10 seconds in the minute, add a 0 to the front for the width to be consistent
                if (levelData.getSeconds() < 10)
                    timerText.text = "Time: " + levelData.getMinutes() + ":0" + levelData.getSeconds();

                else
                    timerText.text = "Time: " + levelData.getMinutes() + ":" + levelData.getSeconds();
            }
        }
        else
        {
            //If the game is not active, go back to the main menu after a specified amount of time
            timerUntilMainMenu += Time.deltaTime;
            if(timerUntilMainMenu >= secondsUntilTitleScreen)
                //Go back to the main menu
                SceneManager.LoadScene(0);
        }
    }

    public void AddToTime(int seconds)
    {
        //Add to the timer
        levelData.setTimer(levelData.getTimer() + seconds);
    }//end of AddToTime

    private void GameOverScreen()
    {
        gameActive = false;
        FindObjectOfType<AudioManager>().Stop("LevelTheme"); // Stops Level Theme and plays GameOverJingle
        FindObjectOfType<AudioManager>().Play("GameOverJingle");

        //Set the canvas to the in-game screen and fade it out with a coroutine
        canvGroup = inGameUI.GetComponent<CanvasGroup>();
        uiFader.Fade(canvGroup, false);

        //Set the canvas to the current screen and fade it in with a coroutine
        canvGroup = gameOverUI.GetComponent<CanvasGroup>();
        uiFader.Fade(canvGroup, true);

    }//end of GameOverScreen

    public void GameWinScreen()
    {
        gameActive = false;
        FindObjectOfType<AudioManager>().Stop("LevelTheme"); // Stops Level Theme and plays ClearJingle
        FindObjectOfType<AudioManager>().Play("ClearJingle");

        //If there are less than 10 seconds in the minute, add a 0 to the front for the width to be consistent
        if (levelData.getSeconds() < 10)
            finalTimeText.text = "Final Time: " + levelData.getMinutes() + ":0" + levelData.getSeconds();

        else
            finalTimeText.text = "Final Time: " + levelData.getMinutes() + ":" + levelData.getSeconds();

        //Set the canvas to the in-game screen and fade it out with a coroutine
        canvGroup = inGameUI.GetComponent<CanvasGroup>();
        uiFader.Fade(canvGroup, false);

        //Set the canvas to the current screen and fade it in with a coroutine
        canvGroup = gameWinUI.GetComponent<CanvasGroup>();
        uiFader.Fade(canvGroup, true);
    }//end of GameOverScreen
}
