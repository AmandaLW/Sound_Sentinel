using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class VideoMenuScript : MonoBehaviour {
    public Transform videoButton;
    public Transform videoCanvas;
	void Start ()
    {
        string videoFolder = Application.dataPath + "/Tyrel/Videos/";
        int pathLength = (videoFolder.Length);
        string buttonTag = "vButton";
        Debug.Log(pathLength);
        string[] filePaths = Directory.GetFiles(videoFolder, "*.mp4");
        Debug.Log(filePaths[0]);
        for (int x = 0; x < filePaths.Length; x++)
        {
            float yCoord = 1.5f;
            float zCoord = 2.5f;
            yCoord = yCoord + (x * 0.07f);
            //zCoord = zCoord + (x * 0.1f);
            Transform buttonClone = Instantiate(videoButton, new Vector3(0, yCoord, zCoord), Quaternion.identity, videoCanvas);
            string fileName = filePaths[x].Remove(0, pathLength);
            buttonClone.GetComponentInChildren<Text>().text = fileName;
            buttonClone.tag = buttonTag;
            buttonClone.SendMessage("SetFilePath", filePaths[x]);
            Debug.Log(fileName);
        }

        //after all the buttons are created turn them off until use
       /* GameObject[] tempObject = GameObject.FindGameObjectsWithTag(buttonTag);
        for (int x = 0; x < tempObject.Length; x++)
            {
                tempObject[x].SetActive(false);
            }
        */
    }

}
