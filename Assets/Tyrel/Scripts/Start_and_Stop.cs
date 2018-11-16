using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_and_Stop : MonoBehaviour {
    Vector3 heading;
    Rigidbody rb;
    bool paused = false;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PauseBall()
    {
        if(paused == false)
        {
            heading = rb.velocity;
            rb.Sleep();
            paused = true;
        }
    }

    public void ResumeBall()
    {
        if(paused == true)
        {
            rb.WakeUp();
            rb.velocity = heading;
            paused = false;
        }
    }
}
