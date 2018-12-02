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
        string[] scoresandNames = File.ReadAllLines(path);
        int fileLength = scoresandNames.Length;
        string[] scoresFromFile = new string[(fileLength / 2)];
        string[] namesFromFile = new string[(fileLength / 2)];

        //seperate names and scores
        for(int x = 0; x < (scoresandNames.Length / 2); x++)
        {
            int arrayIndex = x * 2;
            namesFromFile[x] = scoresandNames[arrayIndex];
            scoresFromFile[x] = scoresandNames[(arrayIndex + 1)];
        }

       
        int[] scores = new int[(fileLength/ 2)];
        for (int x = 0; x < (fileLength / 2); x++)
        {
            //string line = scoresFromFile;
            int.TryParse(scoresFromFile[x], out scores[x]);
            //Debug.Log("scores converted to ints");
        }
        //sorts array so we can display top 10
        SortScores(ref namesFromFile, ref scores);
        float yCoord = 2f;
        float zCoord = 2.5f;
        //run through top 10 scores making text object for each
        for (int k = 0; k < 10; k++)
        {
            string textString = (namesFromFile[((fileLength / 2) - (1 + k))] + " " + scores[((fileLength / 2) - (1 + k))].ToString());
            Debug.Log(textString);
            Transform displayedScore = Instantiate(textBox, new Vector3(0, yCoord, zCoord), Quaternion.identity, scoreCanvas);
            //text properties are set and can be changed easily
            displayedScore.GetComponentInChildren<Text>().text = textString;
            displayedScore.GetComponentInChildren<Text>().fontSize = 20;
            yCoord = yCoord - 0.07f;
        }
        
        //Reader.Close();
    }

    void SortScores(ref string[] names, ref int[] scores)
    {
        int changeMade = 0;
        int e;
        int t;
        string r;
        string y;
        do
        {
            changeMade = 0;
            for (int i = 0; i < (scores.Length - 1); i++)
            {
                e = scores[i];
                t = scores[i + 1];
                r = names[i];
                y = names[i + 1];
                if(e > t)
                {
                    Debug.Log(("swapping" + y + " " + t + " with " + r + " " + e));
                    scores[i] = t;
                    scores[i + 1] = e;
                    names[i] = y;
                    names[i + 1] = r;
                    changeMade = 1;
                }
            }


        } while (changeMade == 1);
    }
}
