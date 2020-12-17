using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOptions : MonoBehaviour
{
    //Called when the cursor clicks an item
    public void OnButtonHover()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick", PlayerPrefs.GetFloat("SoundVol")); // Play Click Sound Effect
    }//end of OnButtonHover

    public void OnButtonStartClick()
    {
        FindObjectOfType<AudioManager>().Play("StartButtonClick", PlayerPrefs.GetFloat("SoundVol")); // Play Click Sound Effect, Exclusive to Start Button
    }//end of OnButtonClick

    //Called when the cursor hovers over an item
    public void OnButtonClick()
    {
        FindObjectOfType<AudioManager>().Play("ButtonHover", PlayerPrefs.GetFloat("SoundVol")); // Play Hover Sound Effect
    }//end of OnButtonClick
}
