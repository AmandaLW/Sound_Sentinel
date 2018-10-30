using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeping : MonoBehaviour {
    private int totalscore = 0;
    private Text scoreboard;

	// Use this for initialization
	void Start () {
        scoreboard = gameObject.GetComponent<Text>();        
	}
	
	// Update is called once per frame
	void Update () {
        scoreboard.text = string.Format("Score: {0}", totalscore);
	}

    public void updateScore(int score)
    {
        totalscore += score;
    }
}
