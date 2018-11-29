using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CanvasOff : MonoBehaviour {
    //script disables canvas on load

    //drag canvas to disable to this variable in the inspector
    public Canvas canvas;
    // Use this for initialization
    void Start() {
        canvasOff();
    }

     public void canvasOff()
    {
        canvas = canvas.GetComponent<Canvas>();
        canvas.enabled = false;
    }
}
