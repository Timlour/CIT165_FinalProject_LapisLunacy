using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimerData
{

    public static PlayerData UpdateTimer(PlayerData gameData)
    {
        gameData.setTimer(gameData.getTimer() - Time.deltaTime);
        gameData.setSeconds((int)(gameData.getTimer() % 60));

        //If the seconds are less than 0, a minute has passed. Update accordingly
        if (gameData.getTimer() < 0)
        {
            gameData.setTimer(60);
            gameData.setMinutes(gameData.getMinutes() - 1);
        }

        return gameData;

    }//end of UpdateTimer

}
