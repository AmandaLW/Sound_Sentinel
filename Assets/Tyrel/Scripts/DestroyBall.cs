using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour {

    private float speed;
    TestingResults temp;
    Rigidbody rb;
    private readonly int window = 30;
    private readonly int failwindow = 5;

    // Use this for initialization
    void Start () {
        temp = GameObject.FindGameObjectWithTag("Testing").GetComponent<TestingResults>();
        rb = gameObject.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (rb.position.x > window || rb.position.x < -window || rb.position.y > window || rb.position.y < -window || rb.position.z > window)
        {
            Destroy(gameObject);
        }
            
        if(rb.position.z < -5)
        {
            if(rb.position.x < failwindow && rb.position.x > -failwindow && rb.position.y < failwindow && rb.position.y > -failwindow)
            {
                temp.FailedCollision(speed);
                //Debug.Log(rb.position);
                //rb.velocity = Vector3.zero;
                //rb.angularVelocity = Vector3.zero;
                rb.Sleep();
            }
            else
                Destroy(gameObject);
        }
    }

    public void UpdateSpeed(float spd)
    {
        speed = spd;
    }

    private void OnApplicationQuit()
    {
        TestingResults temp = GameObject.FindGameObjectWithTag("Testing").GetComponent<TestingResults>();
        temp.TestRecords("DestroyBall", true);
    }
}
