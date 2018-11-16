using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume_Script : MonoBehaviour
{
    GameObject[] tempObject;
    GameObject[] balls;
    //shuts off buttons box colliders when the game is started again
    public void ResumeGame()
    {
        tempObject = GameObject.FindGameObjectsWithTag("Button");
        for (int x = 0; x < tempObject.Length; x++)
        {
            Debug.Log("turning button hit boxes off");
            tempObject[x].SetActive(false);
        }       
        balls = GameObject.FindGameObjectsWithTag("ball");
        for (int i = 0; i < balls.Length; i++)
        {
                balls[i].GetComponent<Start_and_Stop>().ResumeBall();
        }
        GameObject.FindGameObjectWithTag("Ball Creation").GetComponent<CreateBalls>().ResumeCreation();
        GameObject.FindGameObjectWithTag("Quad").GetComponent<VideoScript>().Resume();
    }
}
