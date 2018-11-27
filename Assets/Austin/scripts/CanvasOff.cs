using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CanvasOff : MonoBehaviour {
        
    public Canvas canvas;
    // Use this for initialization
    void Start() {
        canvasOff();
        Debug.Log(VideoSingleton.Instance.VideoString);
    }

     public void canvasOff()
    {
        canvas = canvas.GetComponent<Canvas>();
        canvas.enabled = false;
    }
}
