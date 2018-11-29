using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine.UI;
using UnityEngine;
//reads scores in from file sorts them and displays top 10
public class TopScores : MonoBehaviour {
    public Transform scoreCanvas;
    public Transform textBox;
    public void DisplayScores()
    {
        //read in scores from file
        string path = (Application.dataPath + "/Austin/Score.txt");
        //StreamReader Reader = new StreamReader(path);
        string[] scoresFromFile = File.ReadAllLines(path);
        int fileLength = scoresFromFile.Length;
        int[] scores = new int[fileLength];

        for (int x = 0; x < fileLength; x++)
        {
            //string line = scoresFromFile;
            int.TryParse(scoresFromFile[x], out scores[x]);
            //Debug.Log("scores converted to ints");
        }
        //sorts array so we can display top 10
        Array.Sort(scores);
        float yCoord = 2f;
        float zCoord = 2.5f;
        //run through top 10 scores making text object for each
        for (int k = 0; k < 10; k++)
        {
            string textString = scores[(scores.Length - (1 + k))].ToString();
            //Debug.Log(textString);
            Transform displayedScore = Instantiate(textBox, new Vector3(0, yCoord, zCoord), Quaternion.identity, scoreCanvas);
            //text properties are set and can be changed easily
            displayedScore.GetComponentInChildren<Text>().text = textString;
            displayedScore.GetComponentInChildren<Text>().fontSize = 20;
            yCoord = yCoord - 0.07f;
        }
        
        //Reader.Close();
    }
}
