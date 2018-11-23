using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TestingResults : MonoBehaviour {

    private int failedBalls = 0;
    private float failedSpeed = 100;
    private float time = 15;
    
    private string testOutputFile;
    StreamWriter writer;

	// Use this for initialization
	void Start () {
        string dateandtime = System.DateTime.Now.ToString("yyyy MMM dd  HH.mm.ss");
        string devFolder = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        if (devFolder.Contains("Tyrel"))
            devFolder = "Tyrel/";
        else if (devFolder.Contains("Amanda"))
            devFolder = "Amanda/";
        else if (devFolder.Contains("Austin"))
            devFolder = "Austin/";
        else if (devFolder.Contains("Tristan"))
            devFolder = "Tristan/";
        else
            devFolder = "";

        testOutputFile = "tst/" + devFolder + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name + "_" + dateandtime + ".tst";
        var file = File.Open(testOutputFile, FileMode.OpenOrCreate, FileAccess.Write);
        writer = new StreamWriter(file);
    }
	
	// Update is called once per frame
	void Update () {
        time = time - Time.deltaTime;
        if (time < 0)
        {
            string dateandtime = System.DateTime.Now.ToString("HH:mm:ss");
            writer.WriteLine(dateandtime + "  Current Fail Speed: " + failedSpeed + "  Number of Failed Balls: " + failedBalls);
            failedBalls = 0;
            failedSpeed = 100;
            time = 15;
        }
	}

    public void FailedCollision(float speed)
    {
        failedBalls += 1;
        if (speed < failedSpeed)
        {
            failedSpeed = speed;
            //time = 0;
            //TestRecords("Shield Collision fail speed: " + failedSpeed, false);
        }
    }

    private void OnDestroy()
    {
        writer.Close();
    }

    public void TestRecords(string test, bool pass = false)
    {
        var dateandtime = System.DateTime.Now.ToString("HH:mm:ss");
        if(pass)
            writer.WriteLine(dateandtime + " " + test + " " + "PASS");
        else
            writer.WriteLine(dateandtime + " " + test + " " + "FAIL");
    }
}
