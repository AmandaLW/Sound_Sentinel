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
        TestingResults temp = GameObject.FindGameObjectWithTag("Testing").GetComponent<TestingResults>();

        temp.TestRecords(gameObject.name, true);

    }
}
