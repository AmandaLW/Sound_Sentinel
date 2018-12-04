using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script is run when the resume button is hit resumes game objects and disables pause menu
public class Resume_Script : MonoBehaviour
{
    GameObject tempObject;
    GameObject[] balls;
    public void ResumeGame()
    {
        //shuts buttons off so they dont interfere with balls
        //tempObject = GameObject.FindGameObjectsWithTag("Button");
        //for (int x = 0; x < tempObject.Length; x++)
        //{
          //  Debug.Log("turning button hit boxes off");
          //  tempObject[x].SetActive(false);
        //}       
        //resumes game objects
        balls = GameObject.FindGameObjectsWithTag("ball");
        for (int i = 0; i < balls.Length; i++)
        {
                balls[i].GetComponent<Start_and_Stop>().ResumeBall();
        }
        tempObject.SetActive(true);
        GameObject.FindGameObjectWithTag("Ball Creation").GetComponent<CreateBalls>().ResumeCreation();
        GameObject.FindGameObjectWithTag("Quad").GetComponent<MediaScript>().Resume();
    }
}
