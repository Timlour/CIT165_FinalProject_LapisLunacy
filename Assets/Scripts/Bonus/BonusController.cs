using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour
{

    public LevelManager changeTimer;
    public int secondsAdded = 10;

    private void OnTriggerEnter(Collider other)
    {

        //If player collides with this object, add time to the clock
        if (other.gameObject.CompareTag("Player"))
        {
            changeTimer.AddToTime(secondsAdded);
            gameObject.SetActive(false);
        }

    }//end of OnTriggerEnter
}
