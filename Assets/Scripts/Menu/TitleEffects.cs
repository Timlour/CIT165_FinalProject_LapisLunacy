using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TitleEffects : MonoBehaviour
{
    public TextMeshProUGUI titleText;

    private float textTimer;
    private const int firstWord = 0;
    private const int secondWord = 6;
    private int currentWord;


    Color32 endingColor = new Color32(255, 255, 255, 255);
    Color32 startingColor  = new Color32(64, 128, 192, 255);
    Color32 currentColor;

    // Start is called before the first frame update
    void Awake()
    {
        titleText = gameObject.GetComponent<TextMeshProUGUI>();
        textTimer = 0.0f;
        currentWord = firstWord;
        currentColor = startingColor;
    }

    // Update is called once per frame
    void Update()
    {
        textTimer += Time.deltaTime;
        if (textTimer >= 0.33f)
        {
            textTimer = 0.0f;
            switch (currentWord)
            {
                case firstWord:
                    updateWordColor(firstWord, 5);
                    currentWord = secondWord;
                    break;

                case secondWord:
                    updateWordColor(secondWord, 12);
                    currentWord = firstWord;

                    if (currentColor.Equals(startingColor))
                        currentColor = endingColor;
                    else
                        currentColor = startingColor;
                    
                    break;
            }
        }
    }

    void updateWordColor(int startIndex, int endIndex)
    {
        for (int i = 0; i < endIndex - startIndex; ++i)
        {
            int charIndex = startIndex + i;
            int meshIndex = titleText.textInfo.characterInfo[charIndex].materialReferenceIndex;
            int vertexIndex = titleText.textInfo.characterInfo[charIndex].vertexIndex;

            Color32[] vertexColors = titleText.textInfo.meshInfo[meshIndex].colors32;
            vertexColors[vertexIndex + 0] = currentColor;
            vertexColors[vertexIndex + 1] = currentColor;
            vertexColors[vertexIndex + 2] = currentColor;
            vertexColors[vertexIndex + 3] = currentColor;
        }

        titleText.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
    }//end of updateWordColor
}
