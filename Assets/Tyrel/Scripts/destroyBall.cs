using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        if (rb.position.x > 50 || rb.position.y > 50 || rb.position.z < -1 || rb.position.z > 50)
            Destroy(gameObject);
    }
}
