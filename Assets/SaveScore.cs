using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class SaveScore : MonoBehaviour
{
    private int score = 0;
    [MenuItem("Tools/Write file")]
    public void ScoreSaver()
    {
        string path = (Application.dataPath + "/Austin/Score.txt");

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(score);
        writer.Close();

        //Re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(path);
        //TextAsset asset = Resources.Load("Score");

        //Print the text from the file
        //Debug.Log(.text);
    }
}
