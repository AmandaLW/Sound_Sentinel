using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume_Script : MonoBehaviour
{
    GameObject[] tempObject;

    //shuts off buttons box colliders when the game is started again
    void ResumeGame()
    {
        tempObject = GameObject.FindGameObjectsWithTag("button");
        for (int x = 0; x < tempObject.Length; x++)
        {
            tempObject[x].SetActive(false);
        }
    }
}
