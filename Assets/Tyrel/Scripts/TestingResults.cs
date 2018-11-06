using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TestingResults : MonoBehaviour {

    private int failedBalls = 0;
    private float failedSpeed = 1000;
    private float time = 15;
    
    private string testOutputFile;

    StreamWriter writer;

	// Use this for initialization
	void Start () {
        string dateandtime = System.DateTime.Now.ToString("yyyy-MMM-dd_HH-mm-ss");
        testOutputFile = "tst/Tyrel/testlog_" + dateandtime + ".tst";
        var file = File.Open(testOutputFile, FileMode.OpenOrCreate, FileAccess.Write);
        writer = new StreamWriter(file);
    }
	
	// Update is called once per frame
	void Update () {
        time = time - Time.deltaTime;
        if (time < 0)
        {
            string dateandtime = System.DateTime.Now.ToString("HH:mm:ss");
            writer.WriteLine(dateandtime);
            writer.WriteLine("Current Fail Speed: " + failedSpeed);
            writer.WriteLine("Number of Failed Balls: " + failedBalls);
            time = 15;
        }
	}

    public void FailedCollision(float speed)
    {
        failedBalls += 1;
        if (speed < failedSpeed)
        {
            failedSpeed = speed;
            time = 0;
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
