using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
//saves score from pause menu in Sound_Sentinel scene
public class SaveScore : MonoBehaviour
{
    private int score = 0;
    private string playerName = "pizza";
    [MenuItem("Tools/Write file")]
    public void ScoreSaver()
    {
        //this is where the score will be saved
        string path = (Application.dataPath + "/Austin/Score.txt");

        //Write score to file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(playerName);
        writer.WriteLine(score);
        writer.Close();

        //Re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(path);
    }
}
