using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePrefab : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.left * (Random.Range(-100,100)/2));
        rb.AddForce(Vector3.up * (Random.Range(-100,100)/2));
        rb.AddForce(Vector3.forward * (Random.Range(-100, 100)/2));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
