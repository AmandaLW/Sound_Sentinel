using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour {

    Score ballsmackin;

	// Use this for initialization
	void Start () {

        ballsmackin = GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<Score>();
		
	}
	
	// Update is called once per frame
	void Update () {


		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ball")
        {
            ballsmackin.UpdateScore(1);
            Explode();
            
        }
    }

    private void Explode()
    {
         var exp = GetComponent<ParticleSystem>();
        exp.Play();
       // Destroy(gameObject, exp.duration);
    }
}
