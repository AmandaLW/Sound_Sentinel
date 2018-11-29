using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShieldCollision : MonoBehaviour {

    ScoreKeeping scoreScript;

	// Use this for initialization
	void Start () {
        scoreScript = GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<ScoreKeeping>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            scoreScript.updateScore(1);
        }
    }

    private void OnApplicationQuit()
    {
        GameObject.FindGameObjectWithTag("Testing").GetComponent<TestingResults>().RecordTests("ShieldCollision", true);
    }
}
