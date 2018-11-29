using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingPlatform {
    private static TestingPlatform TestingPlatformInstance = CreateTestingPlatform();

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
}
