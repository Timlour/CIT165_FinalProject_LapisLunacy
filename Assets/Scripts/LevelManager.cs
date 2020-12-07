using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    //Items
    PlayerData levelData;

    // Start is called before the first frame update
    void Start()
    {
        //New game data
        levelData = new PlayerData();
    }

    // Update is called once per frame
    void Update()
    {
        //Update in-game timer while the level is active
        levelData = TimerData.UpdateTimer(levelData);

        //If there are less than 10 seconds in the minute, add a 0 to the front for the width to be consistent
        if (levelData.getSeconds() < 10)
            timerText.text = "Time: " + levelData.getMinutes() + ":0" + levelData.getSeconds();

        else
            timerText.text = "Time: " + levelData.getMinutes() + ":" + levelData.getSeconds();
    }
}
