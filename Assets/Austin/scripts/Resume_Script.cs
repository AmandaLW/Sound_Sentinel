using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume_Script : MonoBehaviour {
    GameObject[] tempObjectTwo;
    void ResumeGame()
    {
        tempObjectTwo = GameObject.FindGameObjectsWithTag("button");
        for (int x = 0; x < tempObjectTwo.Length; x++)
        {
            tempObjectTwo[x].SetActive(false);
        }
    }
}
