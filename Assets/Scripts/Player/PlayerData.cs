//Add this if the material in the class may be converted to binary at some point
//Useful for serializing in save data
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]

public class PlayerData
{

    private float timer;
    private int minutes, seconds;
    private int sceneIndex;
    private int timeLimit;

    public PlayerData(int timeLimit)
    {
        this.timeLimit = timeLimit;
        this.minutes = timeLimit / 60;
        this.seconds = timeLimit % 60;
        this.timer = timeLimit % 60;
    }//end of PlayerData

    //Getters
    public float getTimer()
    {
        return this.timer;
    }

    public int getMinutes()
    {
        return this.minutes;
    }

    public int getSeconds()
    {
        return this.seconds;
    }

    public int getSceneIndex()
    {
        return this.sceneIndex;
    }

    public int getTimeLimit()
    {
        return this.timeLimit;
    }

    //Setters
    public void setTimer(float timer)
    {
        this.timer = timer;
    }

    public void setMinutes(int minutes)
    {
        this.minutes = minutes;
    }

    public void setSeconds(int seconds)
    {
        this.seconds = seconds;
    }

    public void setSceneIndex(int sceneIndex)
    {
        this.sceneIndex = sceneIndex;
    }

    public void setTimeLimit(int timeLimit)
    {
        this.timeLimit = timeLimit;
    }
}