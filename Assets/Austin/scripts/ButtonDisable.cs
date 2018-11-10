using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDisable : MonoBehaviour {
    public string buttonTag;
    GameObject[] tempObject;

    //shuts off buttons box colliders when the game is started again
    public void DisableButton()
    {
        tempObject = GameObject.FindGameObjectsWithTag(buttonTag);
        for (int x = 0; x < tempObject.Length; x++)
        {
            tempObject[x].SetActive(false);
        }
    }


}
