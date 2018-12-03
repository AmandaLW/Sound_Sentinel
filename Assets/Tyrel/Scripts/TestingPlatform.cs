using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TestingPlatform {
    private static TestingPlatform TestingPlatformInstance = CreateTestingPlatform();
    
    protected StreamWriter writer;

    //Singleton pattern to ensure only one file is created
    private TestingPlatform()
    {
    }
    
    private static TestingPlatform CreateTestingPlatform()
    {
        if(TestingPlatformInstance == null)
        {
            TestingPlatformInstance = new TestingPlatform();
        }
        return TestingPlatformInstance;
    }

    public static TestingPlatform Instance
    {
        get
        {
            return TestingPlatformInstance;
        }
    }
    // Use this for initializing the test file in the Singleton TestingPlatform
    private string testOutputFile;
    void Start()
    {
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
        //temp.SetWriter(new StreamWriter(file));
        TestingPlatformInstance.writer = new StreamWriter(file);
    }

    public void RecordTests(string test, bool pass = false)
    {
        var dateandtime = System.DateTime.Now.ToString("HH:mm:ss");
        if (pass)
            Instance.writer.WriteLine(dateandtime + " " + test + " " + "PASS");
        else
            TestingPlatformInstance.writer.WriteLine(dateandtime + " " + test + " " + "FAIL");
    }

    public void TestMessage(string message)
    {
        TestingPlatformInstance.writer.WriteLine(message);
    }

    public void SetWriter(StreamWriter targetFile)
    {
        TestingPlatformInstance.writer = targetFile;
    }

    private void OnDestroy()
    {
        TestingPlatformInstance.writer.Close();
    }
}
