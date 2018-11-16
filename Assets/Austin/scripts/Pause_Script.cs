using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Script : MonoBehaviour {
    public Canvas canvas;
    public KeyCode vivePauseButton;
    public KeyCode keyboardPauseButton;// = "Escape";
    public KeyCode resumeButton;
    GameObject tempObject;
    GameObject[] tempObjectTwo;
    // Use this for initialization
    void Start()
    {
        canvasOff();
        tempObjectTwo = GameObject.FindGameObjectsWithTag("Button");
        Debug.Log(tempObjectTwo.Length);
        for (int x = 0; x < tempObjectTwo.Length; x++)
        {
          tempObjectTwo[x].SetActive(false);
        }
       //tempObject = GameObject.FindGameObjectWithTag("rightcontroller");
       // tempObject.SetActive(false);
    }
    public void canvasOff()
    {
        canvas = canvas.GetComponent<Canvas>();
        canvas.enabled = false;
    }
    void Update()
    {
        //Debug.Log(keyboardPauseButton);
        if (Input.GetKey(vivePauseButton) || Input.GetKey(keyboardPauseButton))
        {
            canvas.enabled = true;
           // tempObject = GameObject.FindGameObjectWithTag("shield");
           // tempObject.SetActive(false);
           // tempObject = GameObject.FindGameObjectWithTag("rightcontroller");
           // tempObject.SetActive(true);
           //GameObject.FindGameObjectWithTag("BallCreation").GetComponent<CreateBalls>().PauseCreation();
            for (int k = 0; k < tempObjectTwo.Length; k++)
            {
                tempObjectTwo[k].SetActive(true);
            }
            GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
            for(int i=0; i<balls.Length; i++)
            {
                balls[i].GetComponent<Start_and_Stop>().PauseBall();
            }
            GameObject.FindGameObjectWithTag("Ball Creation").GetComponent<CreateBalls>().PauseCreation();
            GameObject.FindGameObjectWithTag("Quad").GetComponent<VideoScript>().Pause();
        }
        if (Input.GetKey(resumeButton))
        {
           // Resume_Script.ResumeGame();
        }
    }
    
}
