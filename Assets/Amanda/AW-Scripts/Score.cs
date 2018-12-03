using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;





public class Score : MonoBehaviour
{
    private Text scoreText;
    private int score;

    void Start()
    {
        scoreText = gameObject.GetComponent<Text>();
        score = 0;
      

    }

    void Update()
    {
        scoreText.text = string.Format("Score: {0}", score);
    }

    public void UpdateScore(int balls)
    {
        // scoreText.text = "Score: " + score;
        score += balls;
    }

    private void OnDestroy()
    {
        string playerName = "pizza";
        //this is where the score will be saved
        string path = (Application.dataPath + "/Austin/Score.txt");
        if (VideoSingleton.Instance.playerName.Length > 0)
        {
            playerName = VideoSingleton.Instance.playerName;
        }
        //Write score to file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(playerName);
        writer.WriteLine(score);
        writer.Close();
    }

}
