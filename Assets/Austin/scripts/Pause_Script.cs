using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Script : MonoBehaviour {
    public Canvas canvas;
    public KeyCode pauseButton;
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
        if (Input.GetKey(pauseButton))
        {
            canvas.enabled = true;
            tempObject = GameObject.FindGameObjectWithTag("shield");
            tempObject.SetActive(false);
            tempObject = GameObject.FindGameObjectWithTag("rightcontroller");
            tempObject.SetActive(true);
            for (int x = 0; x < tempObjectTwo.Length; x++)
            {
                tempObjectTwo[x].SetActive(true);
            }


        }
        if (Input.GetKey(resumeButton))
        {
            tempObject = GameObject.FindGameObjectWithTag("shield");
            tempObject.SetActive(true);
        }
    }

}
