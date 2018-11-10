using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AW_MoveAsteroid : MonoBehaviour {

    Rigidbody m_Rigidbody;
    float m_Speed;



    // The target marker.
    public Transform target;

    // Speed in units per sec.
    public float speed = 8;
    

    void Start()
    {
        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody>();
        //Set the speed of the GameObject
        m_Speed = 10.0f;
    }

    void Update()
    {
        // The step size is equal to speed times frame time.
        //float step = speed * Time.deltaTime;


        // Move our position a step closer to the target.
        // transform.position = Vector3.MoveTowards(transform.position, target.localPosition, step);

        // m_Rigidbody.velocity = transform.forward * m_Speed;

        transform.position += transform.forward * Time.deltaTime * speed;


    }
}
