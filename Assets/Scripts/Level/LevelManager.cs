using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public int timeLimitSeconds = 60;

    //Items
    PlayerData levelData;

    // Start is called before the first frame update
    void Start()
    {
        //New game data
        levelData = new PlayerData(timeLimitSeconds);
    }

    // Update is called once per frame
    void Update()
    {
        //Update in-game timer while the level is active
        levelData = TimerData.UpdateTimer(levelData);

        //If the timer has reached or passed 0, time is up
        if((levelData.getMinutes() == 0 && levelData.getSeconds() == 0 && levelData.getTimer() < 60) || levelData.getMinutes() < 0)
        {
            timerText.text = "Time's Up!";
            //End the game, as the player lost
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
}
