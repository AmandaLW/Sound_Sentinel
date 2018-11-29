using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class TopScores : MonoBehaviour {
    public Transform scoreCanvas;
    public Transform textBox;
    public void DisplayScores()
    {
        string path = (Application.dataPath + "/Austin/Score.txt");
        //StreamReader Reader = new StreamReader(path);
        string[] scoresFromFile = File.ReadAllLines((Application.dataPath + "/Austin/Score.txt"));
        int fileLength = scoresFromFile.Length;
        int[] scores = new int[fileLength];

        for (int x = 0; x < fileLength; x++)
        {
            //string line = scoresFromFile;
            int.TryParse(scoresFromFile[x], out scores[x]);
            Debug.Log("scores converted to ints");
        }
        Array.Sort(scores);
        float yCoord = 2f;
        float zCoord = 2.5f;
        for (int k = 0; k < scores.Length; k++)
        {
            Debug.Log("Displaying scores");
            string textString = scores[k].ToString();
            Transform displayedScore = Instantiate(textBox, new Vector3(0, yCoord, zCoord), Quaternion.identity, scoreCanvas);
            textBox.GetComponentInChildren<Text>().text = textString;
            textBox.GetComponentInChildren<Text>().fontSize = 20;
            yCoord -= 0.07f;
        }
        //Reader.Close();
    }
}
