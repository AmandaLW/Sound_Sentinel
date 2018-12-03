using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnApplicationQuit()
    {
        TestingResults tests = GameObject.FindGameObjectWithTag("Testing").GetComponent<TestingResults>();

        tests.tests.RecordTests(gameObject.name, true);

        //TestingPlatform.Instance.RecordTests(gameObject.name, true);

    }
}
