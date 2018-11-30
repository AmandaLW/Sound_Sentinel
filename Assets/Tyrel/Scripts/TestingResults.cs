using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TestingResults : MonoBehaviour
{
    public TestingPlatform temp = TestingPlatform.Instance;

    

    // Use this for testing what speed the balls pass through the shield
    private int failedBalls = 0;
    private float failedSpeed = 100;
    private float time = 15;
    public void FailedCollision(float speed)
    {
        failedBalls += 1;
        if (speed < failedSpeed)
        {
            failedSpeed = speed;
        }
        time = time - Time.deltaTime;
        if (time < 0)
        {
            string dateandtime = System.DateTime.Now.ToString("HH:mm:ss");
            temp.TestMessage(dateandtime + "  Current Fail Speed: " + failedSpeed + "  Number of Failed Balls: " + failedBalls);
            failedBalls = 0;
            failedSpeed = 100;
            time = 15;
        }
    }

}
