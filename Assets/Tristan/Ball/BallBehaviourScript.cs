using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//int z
//int zed

//double velocity
//double acceleration //if any

// spawn ball

// int max
// int min
//public static int GetRandomNumber(int min, int max)


//go to 0 0 0 ?????  or angle compinsation 


// random axis

//angle of attack

//int distance = 100; 

//despawn ball
//despawn all balls





public class BallBehaviourScript : MonoBehaviour {

		public Vector3 ballSpawnPoint;
		public GameObject ball;
		public float ballSpeed = 5; // constent for now
		public Rigidbody ballRigidbody;
		public float level;
		public float screenLocation;
		private Material ballMaterial;

        private float CountDown = -10f;
		
		//public GameManager gameManager;  // remove?
	/*  OLD	
	// Use this for initialization
	void Start () {
		ballRigidbody = GetComponent<Rigidbody> ();
		spawnBall();
		level = 5f;
		screenLocation = 30f;
		ballMaterial = GetComponent<Renderer>().material;
		//ballMaterial.color = Color.red;
	}*/
	
		void Start () {
		ballRigidbody = GetComponent<Rigidbody> ();

        int zed = 0;
        do
            {
                spawnBall();
                zed++;
            } while (zed < 10);
        
        level = 5f;
		screenLocation = 30f;
		ballMaterial = GetComponent<Renderer>().material;
		//ballMaterial.color = Color.red;
	}

	void spawnBall()
	{
        // create a clone of ball, at 100 100 (100 can be variables) Also, store as a rigid body?
        //Instantiate (ball);
        GameObject newball = Instantiate(ball, new Vector3(UnityEngine.Random.Range(-level, level), UnityEngine.Random.Range(-level, level), screenLocation)) as GameObject;
		//transform.position = new Vector3 (Random.Range (-level, level), Random.Range (-level, level), screenLocation);
		Vector3 gravitationPoint = new Vector3 (0,1,-5);
		ballRigidbody.velocity = gravitationPoint - transform.position;
		ballRigidbody.velocity = ballSpeed * ballRigidbody.velocity.normalized;
		level = level++;
		Debug.Log(level);
		//ball velocity towards player
		//ball.transform.position = new Vector3 (0, 0, 0);
		//ball.GetComponent<Rigidbody> ();
		///ball.GetComponent<Rigidbody> ().velocity = new Vector3 (20f, 0.0f, 0.0f);
		//ball.velocity = new Vector3 (ballSpeed, 0.0f, 0.0f);
	}

    private GameObject Instantiate(GameObject ball, Vector3 vector3)
    {
        throw new NotImplementedException();
    }

    void OnCollisionExit (Collision other){
		if (other.transform.name == "P A D L E"){
			//change color
			ballMaterial.color = Color.blue;
			// Add 1 to score
		}
		if (other.transform.name == "ball"){
			//change color
			ballMaterial.color = Color.blue;
			// Add 1 to score
		}

        CountDown = 200f;

    }




    // Update is called once per frame
    void Update () {
		// continuous spawning
		if (transform.position.z < -1 || transform.position.z > 30 || transform.position.y > 8) {
			//ballMaterial = new Material(HitBallMaterial);
			if(ballMaterial.color == Color.blue)				
				ballMaterial.color = Color.red;
			else
				ballMaterial.color = Color.blue;
			spawnBall ();
		}

        CountDown++;
        if(CountDown == 0)
        {
            spawnBall();
        }

    //Time function to spawn ball (based of random * 1000ms?)
    //spawnBall();


    }


	}




/*
//Function to get random number
private static readonly Random getrandom = new Random();

public static int GetRandomNumber(int min, int max)
{
	lock(getrandom) // synchronize
	{
		return getrandom.Next(min, max);
	}
}
*/

/*
void setBall(){
	//ballInstance = Instantiate (ball);
	//ballInstance.GetComponent<Ball>().gameManager = gameObject.GetComponent<GameManager>();
}
*/

// a mustache is just a third eyebrow 
