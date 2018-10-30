using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initialVelocity : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {

        Vector3 target = new Vector3(0, 0, 0);
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();

        var heading = target - rb.position;
        
        rb.velocity = ((heading / heading.magnitude) * speed);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
