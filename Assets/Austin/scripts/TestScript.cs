using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TestScript : MonoBehaviour {
    public Canvas mainMenuCanvas;
    public Canvas testMenuCanvas;
    public Canvas helpMenuCanvas;
    public void MenuTest()
    {
        Debug.Log("button pressed");
       // Wait();
        Debug.Log("returned from wait");
        
        testMenuCanvas = testMenuCanvas.GetComponent<Canvas>();
        testMenuCanvas.enabled = false;
        mainMenuCanvas = mainMenuCanvas.GetComponent<Canvas>();
        mainMenuCanvas.enabled = true;
        //Update();
        Debug.Log("entering help menu");
        mainMenuCanvas = mainMenuCanvas.GetComponent<Canvas>();
        mainMenuCanvas.enabled = false;
        helpMenuCanvas = helpMenuCanvas.GetComponent<Canvas>();
        helpMenuCanvas.enabled = true;
        Debug.Log("leaving help");
        //Update();
        Debug.Log("entering main menu");
        mainMenuCanvas = mainMenuCanvas.GetComponent<Canvas>();
        mainMenuCanvas.enabled = true;
        helpMenuCanvas = helpMenuCanvas.GetComponent<Canvas>();
        helpMenuCanvas.enabled = false;
        //Update();
        string sceneName = "Sound_Sentinel";
        SceneManager.LoadScene(sceneName); 
    }
    IEnumerator Wait()
    {
        Debug.Log("enter wait");
        testMenuCanvas = testMenuCanvas.GetComponent<Canvas>();
        testMenuCanvas.enabled = false;
        mainMenuCanvas = mainMenuCanvas.GetComponent<Canvas>();
        mainMenuCanvas.enabled = true;
        //Update();
        yield return new WaitForSeconds(5);
       
        Debug.Log("entering help menu");
        mainMenuCanvas = mainMenuCanvas.GetComponent<Canvas>();
        mainMenuCanvas.enabled = false;
        helpMenuCanvas = helpMenuCanvas.GetComponent<Canvas>();
        helpMenuCanvas.enabled = true;
        Debug.Log("leaving help");
        //Update();
        yield return new WaitForSeconds(5);
        Debug.Log("entering main menu");
        mainMenuCanvas = mainMenuCanvas.GetComponent<Canvas>();
        mainMenuCanvas.enabled = true;
        helpMenuCanvas = helpMenuCanvas.GetComponent<Canvas>();
        helpMenuCanvas.enabled = false;
        //Update();
        yield return new WaitForSeconds(5);
        string sceneName = "Sound_Sentinel";
        SceneManager.LoadScene(sceneName);
        Debug.Log("waiting");
        yield return new WaitForSeconds(5);
     
    }
  /*  void Wait(int time)
    {
        while(time-Time.deltaTime > 0f)
        {
            //do nothing
        }
    } */
 
}
