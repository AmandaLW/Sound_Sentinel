﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TestScript : MonoBehaviour {
    public Canvas mainMenuCanvas;
    public Canvas testMenuCanvas;
    public Canvas helpMenuCanvas;
    public void MenuTest()
    {
        testMenuCanvas = testMenuCanvas.GetComponent<Canvas>();
        testMenuCanvas.enabled = false;
        mainMenuCanvas = mainMenuCanvas.GetComponent<Canvas>();
        mainMenuCanvas.enabled = true;
        Wait();
        Debug.Log("entering help menu");
        mainMenuCanvas = mainMenuCanvas.GetComponent<Canvas>();
        mainMenuCanvas.enabled = false;
        helpMenuCanvas = helpMenuCanvas.GetComponent<Canvas>();
        helpMenuCanvas.enabled = true;
        Debug.Log("leaving help");
        Wait();
        Debug.Log("entering main menu");
        mainMenuCanvas = mainMenuCanvas.GetComponent<Canvas>();
        mainMenuCanvas.enabled = true;
        helpMenuCanvas = helpMenuCanvas.GetComponent<Canvas>();
        helpMenuCanvas.enabled = false;
        Wait();
        string sceneName = "Sound_Sentinel";
        SceneManager.LoadScene(sceneName);
    }
    IEnumerator Wait()
    {
        Debug.Log("waiting");
        yield return new WaitForSeconds(5);
     
    }
}
