using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Hint_Script : MonoBehaviour {
   // public Text hintText;
    public Transform ballText;
    public Transform hintPanel;
	// Use this for initialization
	void SetHintText(Color[] colors)
    {
        float xCoord = 0.63f;
        float yCoord = 1.64f;
        float zCoord = 1;
        string textString;
        for (int x = 0; x < (colors.Length - 1); x++)
        {
            textString = "Balls of this color are worth " + (x + 1) + " points.";
            Transform hintText = Instantiate(ballText, new Vector3(xCoord, yCoord, zCoord), Quaternion.identity, hintPanel);
            hintText.GetComponentInChildren<Text>().text = textString;
            hintText.GetComponentInChildren<Text>().color = colors[x];
            yCoord = yCoord - 0.11f;

        }
        textString = "Balls of this color explode!;";
        Transform lastText = Instantiate(ballText, new Vector3(xCoord, yCoord, zCoord), Quaternion.identity, hintPanel);
        lastText.GetComponentInChildren<Text>().text = textString;
        lastText.GetComponentInChildren<Text>().color = colors[(colors.Length - 1)];
    }
	
}
