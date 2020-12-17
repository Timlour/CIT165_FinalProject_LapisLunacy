using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    private float testSoundtimer;
    private bool playTestSound = false;

    public void ChangeMusicVolume(float value)
    {
        PlayerPrefs.SetFloat("MusicVol", value);
        FindObjectOfType<AudioManager>().ChangeVolume("LevelTheme", PlayerPrefs.GetFloat("MusicVol"));
        Debug.Log("Music Volume: " + PlayerPrefs.GetFloat("MusicVol"));
    }//end of ChangeMusicVolume

    public void ChangeSoundVolume(float value)
    {
        PlayerPrefs.SetFloat("SoundVol", value);
    }//end of ChangeSoundVolume

    public void StartTestSound()
    {
        playTestSound = true;
    }//end of StartTestSound

    public void StopTestSound()
    {
        playTestSound = false;
    }//end of StopTestSound

    void Update()
    {
        if (playTestSound)
            TestSoundVolume();
    }

    void TestSoundVolume()
    {
        Debug.Log("Testing Sound Volume...");
        testSoundtimer += Time.deltaTime;
        if (testSoundtimer >= 0.5f)
        {
            FindObjectOfType<AudioManager>().Play("TestSound", PlayerPrefs.GetFloat("SoundVol")); // Play Test Sound For Volume
            testSoundtimer = 0;
        }
    }//end of TestSoundVolume
}
