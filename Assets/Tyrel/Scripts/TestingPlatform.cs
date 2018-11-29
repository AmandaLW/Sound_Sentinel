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

    public void RecordTests(string test, bool pass = false)
    {
        var dateandtime = System.DateTime.Now.ToString("HH:mm:ss");
        if (pass)
            writer.WriteLine(dateandtime + " " + test + " " + "PASS");
        else
            writer.WriteLine(dateandtime + " " + test + " " + "FAIL");
    }

    public void TestMessage(string message)
    {
        writer.WriteLine(message);
    }

    public void SetWriter(StreamWriter targetFile)
    {
        writer = targetFile;
    }

    private void OnDestroy()
    {
        writer.Close();
    }
}
