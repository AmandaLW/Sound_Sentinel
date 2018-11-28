using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOnOff : MonoBehaviour {
    public string buttonTag;
    GameObject[] tempObject;
    
    //shuts off buttons  
    
    public void DisableButton(string buttonTag)
    {
        
        tempObject = GameObject.FindGameObjectsWithTag(buttonTag); 
        for (int x = 0; x < tempObject.Length; x++)
        {
            tempObject[x].SetActive(false);
        }
    }   

}
