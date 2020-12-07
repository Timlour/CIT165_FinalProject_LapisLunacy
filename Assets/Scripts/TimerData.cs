using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimerData
{

    public static PlayerData UpdateTimer(PlayerData gameData)
    {
        gameData.setTimer(gameData.getTimer() + Time.deltaTime);
        gameData.setSeconds((int)(gameData.getTimer() % 60));

        //If the seconds are equal to or more than 60, a minute has passed. Update accordingly
        if (gameData.getTimer() >= 60)
        {
            gameData.setTimer(0);
            gameData.setMinutes(gameData.getMinutes() + 1);
        }

        return gameData;

    }//end of UpdateTimer

}
