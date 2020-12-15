using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartTextEffects : MonoBehaviour
{
    public TextMeshProUGUI startText;
    public int maxIndex = 4;

    private float textTimer;
    private int currentIndex;
    private int prevIndex;

    Color32 endingColor = new Color32(255, 255, 255, 255);
    Color32 startingColor = new Color32(3, 252, 223, 255);
    Color32 currentColor;

    // Start is called before the first frame update
    void Awake()
    {
        startText = gameObject.GetComponent<TextMeshProUGUI>();
        textTimer = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        textTimer += Time.deltaTime;
        if (textTimer >= 0.1f)
        {
            textTimer = 0.0f;
            //Update current letter
            currentColor = startingColor;
            updateWordColor(currentIndex, currentColor);
            //Switch back previous letter
            currentColor = endingColor;
            updateWordColor(prevIndex, currentColor);

            //Move onto next letter, if the end is reached loop back around
            prevIndex = currentIndex;
            currentIndex += 1;
            if (currentIndex > maxIndex)
            {
                currentIndex = 0;
                prevIndex = maxIndex;
            }
        }
    }

    void updateWordColor(int charIndex, Color32 currentColor)
    {

            int meshIndex = startText.textInfo.characterInfo[charIndex].materialReferenceIndex;
            int vertexIndex = startText.textInfo.characterInfo[charIndex].vertexIndex;

            Color32[] vertexColors = startText.textInfo.meshInfo[meshIndex].colors32;
            vertexColors[vertexIndex + 0] = currentColor;
            vertexColors[vertexIndex + 1] = currentColor;
            vertexColors[vertexIndex + 2] = currentColor;
            vertexColors[vertexIndex + 3] = currentColor;

        startText.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
    }//end of updateWordColor
}
