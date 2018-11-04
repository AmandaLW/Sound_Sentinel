using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingResults : MonoBehaviour {

    private int failedBalls = 0;
    private float failedSpeed = 1000;
    private float time = 15;
    private float[] temp = new float[15];
    private int counter = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time = time - Time.deltaTime;
        if (time < 0f)
        {
            Debug.Log("Current Fail Speed: " + failedSpeed);
            Debug.Log(string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}", temp[0], temp[1], temp[2], temp[3], temp[4], temp[5], temp[6], temp[7], temp[8], temp[9], temp[10], temp[11], temp[12], temp[13], temp[14]));
            Debug.Log("Number of Failed Balls: " + failedBalls);
            time = 15;
        }
	}

    public void FailedCollision(float speed)
    {
        failedBalls += 1;
        if (speed < failedSpeed)
            failedSpeed = speed;
        if (counter < 15)
        {
            temp[counter] = failedSpeed;
            counter++;
        }
    }
}
