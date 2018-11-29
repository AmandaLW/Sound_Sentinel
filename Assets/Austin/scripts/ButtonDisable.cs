using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDisable : MonoBehaviour {
    public string buttonTag;
    GameObject[] tempObject;
    
    //shuts off buttons with a certain tag so they don't interfere with other menus
    public void DisableButton(string buttonTag)
    {
        tempObject = GameObject.FindGameObjectsWithTag(buttonTag); 
        for (int x = 0; x < tempObject.Length; x++)
        {
            tempObject[x].SetActive(false);
        }
    }   

}
