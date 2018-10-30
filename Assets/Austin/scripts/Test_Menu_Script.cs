using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Test_Menu_Script : MonoBehaviour {
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
