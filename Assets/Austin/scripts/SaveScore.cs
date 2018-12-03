using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
//saves score from pause menu in Sound_Sentinel scene
public class SaveScore : MonoBehaviour
{
    private int score = 0;
    private string playerName;
    //[MenuItem("Tools/Write file")]
    public void ScoreSaver(int score)
    {
        Debug.Log("saving score");
        //this is where the score will be saved
        string path = (Application.dataPath + "/Austin/Score.txt");
        playerName = VideoSingleton.Instance.playerName;
        //Write score to file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(playerName);
        writer.WriteLine(score);
        writer.Close();
    }
}
