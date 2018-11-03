using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Script : MonoBehaviour {
    public Canvas canvas;
    public KeyCode pauseButton;
    // Use this for initialization
    void Start()
    {
        canvasOff();
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
        }  
    }

}
