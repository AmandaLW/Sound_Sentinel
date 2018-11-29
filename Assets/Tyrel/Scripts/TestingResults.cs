using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TestingResults : MonoBehaviour
{
    public TestingPlatform temp = TestingPlatform.Instance;

    // Use this for initializing the test file in the Singleton TestingPlatform
    private string testOutputFile;
    void Start () {
        string dateandtime = System.DateTime.Now.ToString("yyyy MMM dd  HH.mm.ss");
        string devFolder = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        if (devFolder.Contains("Tyrel"))
            devFolder = "Tyrel/";
        else if (devFolder.Contains("Amanda"))
            devFolder = "Amanda/";
        else if (devFolder.Contains("Austin") || devFolder.Contains("Menu"))
            devFolder = "Austin/";
        else if (devFolder.Contains("Tristan"))
            devFolder = "Tristan/";
        else
            devFolder = "";

        testOutputFile = "tst/" + devFolder + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name + "_" + dateandtime + ".tst";
        var file = File.Open(testOutputFile, FileMode.OpenOrCreate, FileAccess.Write);
        temp.SetWriter(new StreamWriter(file));
    }

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
