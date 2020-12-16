using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI Fader Tutorial Using a Coroutine Found On https://www.youtube.com/watch?v=YYD_tBBS4FY

public class UIFader : MonoBehaviour
{

    public float Duration = 0.4f;

    public void Fade(CanvasGroup canvGroup, bool fadeIn)
    {
        //Either fade in or out, based on the boolean
        StartCoroutine(FadeUI(canvGroup, canvGroup.alpha, fadeIn ? 1 : 0));

    }//end of Fade

    public IEnumerator FadeUI(CanvasGroup canvGroup, float start, float end)
    {

        float counter = 0.0f;

        //While the counter is less than the duration, slowly affect the alpha
        while(counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / Duration);

            //No return value needed
            yield return null;
        }

    }//end of FadeUI

}
