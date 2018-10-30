using System.Collections;
using System.Collections.Generic;
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

}
