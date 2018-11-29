using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBalls : MonoBehaviour {
    public GameObject ball;
    public float frequency;
    public float start_speed;

    //private int numberOfBalls = 0;
    private Vector3 target;
    private float target_x = 0;
    private float target_y = 0;
    private float x = 0;
    private float y = 0;
    private readonly float z = 29;

    private float speed;
    private float timer = 0;

    private const int MAX_x = 10;
    private const int MAX_y = 8;
    private const float MAX_targetx = (float)0.5;
    private const float MAX_targety = (float)0.25;
    private const float MIN_frequency = (float)0.01;
    private int MAX_Speed;

    private bool pause = false;

    // Use this for initialization
    void Start () {
        speed = start_speed;
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Sound_Sentinel")
            MAX_Speed = 10;
        else
            MAX_Speed = 30;
    }
	
	// Update is called once per frame
	void Update () {
        if (pause == false)
        {
            Creation();
        }
    }

    private void Creation()
    {
        timer -= Time.deltaTime;
        //start_speed = speed;


        if (timer <= 0f)
        {
            //Using prototype pattern use the prefab as my prototype to create all future classes of this prototype
            GameObject temp = Instantiate(ball, new Vector3(Random.Range(-x, x), Random.Range(-y, y), z), Quaternion.identity) as GameObject;

            target = new Vector3(Random.Range(-target_x, target_x), Random.Range(-target_y + (float)1.5, target_y + (float)1.5), 0);

            var heading = target - temp.transform.position;

            temp.gameObject.GetComponent<Rigidbody>().velocity = heading.normalized * Random.Range(start_speed, speed);
            temp.GetComponent<DestroyBall>().UpdateSpeed(speed);

            //numberOfBalls += 1;
            if (speed < MAX_Speed)
                speed += (float)0.2;
            if (x < MAX_x)
                x += (float)0.5;
            if (y < MAX_y)
                y += (float)0.5;
            if (frequency > MIN_frequency)
                frequency -= (float)0.001;
            if (target_x < MAX_targetx)
                target_x += (float)0.1;
            if (target_y < MAX_targety)
                target_y += (float)0.1;

            timer = Random.Range(0, frequency);
        }
    }

    private void OnApplicationQuit()
    {
        TestingResults temp = GameObject.FindGameObjectWithTag("Testing").GetComponent<TestingResults>();
        temp.RecordTests("CreateBalls", true);
    }

    public void PauseCreation()
    {
        pause = true;
    }

    public void ResumeCreation()
    {
        pause = false;
    }
}
