using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOnOff : MonoBehaviour {
    //public string buttonTag;
    public Canvas canvas;
    BoxCollider box;
    //GameObject[] tempObject;
    //BoxCollider[] temp;
    public void ColliderOn(Canvas canvas)
    {
        do
        {
            box = canvas.GetComponentInChildren<BoxCollider>(true);
            box.enabled = true;
        } while (box != null);
    }
    public void ColliderOff(Canvas canvas)
    {
        do
        {
            box = canvas.GetComponentInChildren<BoxCollider>();
            box.enabled = false;
        } while (box != null);
    }

    // BoxCollider[] colliderArray;
    //shuts off buttons box colliders 
    /*
    public void DisableButton(string buttonTag)
    {
        
        tempObject = GameObject.FindGameObjectsWithTag(buttonTag); 
        for (int x = 0; x < tempObject.Length; x++)
        {
            temp[x] = GetComponentInChildren<BoxCollider>(true);
            Debug.Log(temp[0]);
            tempObject[x].SetActive(false);
        }
    }

    public void EnableButton(string buttonTag)
    {
        tempObject = GameObject.FindGameObjectsWithTag(buttonTag);
        Debug.Log(tempObject.Length);
        for (int x = 0; x < tempObject.Length; x++)
        {
            tempObject[x].SetActive(true);
        }
    }
    */

}
