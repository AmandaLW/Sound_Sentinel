using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is used to control the pause menu in the main game
public class Pause_Script : MonoBehaviour {
    public Canvas canvas;
    public KeyCode vivePauseButton;
    public KeyCode keyboardPauseButton;// = "Escape";
    public KeyCode resumeButton;
    GameObject tempObject;
    GameObject[] tempObjectTwo;
    // Use this for initialization
    //When scene loads turn off pause menu buttons
    void Start()
    {
        tempObject = GameObject.FindGameObjectWithTag("shield");
        tempObject.SetActive(false);
        tempObjectTwo = GameObject.FindGameObjectsWithTag("Button");
        for (int x = 0; x < tempObjectTwo.Length; x++)
        {
          tempObjectTwo[x].SetActive(false);
        }
    }
    //watch for either pause button to be pressed and open pause menu when it does
    void Update()
    {
        if (Input.GetKey(vivePauseButton) || Input.GetKey(keyboardPauseButton))
        {
            
            canvas.enabled = true;
            //reenable pause buttons
            for (int k = 0; k < tempObjectTwo.Length; k++)
            {
                tempObjectTwo[k].SetActive(true);
            }
            //pause active objects in the game
            GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
            for(int i=0; i<balls.Length; i++)
            {
                balls[i].GetComponent<Start_and_Stop>().PauseBall();
            }
            GameObject.FindGameObjectWithTag("Ball Creation").GetComponent<CreateBalls>().PauseCreation();
            GameObject.FindGameObjectWithTag("Quad").GetComponent<MediaScript>().Pause();
        }
    }
    
}
