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
        string videoFolder = Application.dataPath + "/Resources/";
        //To add additional file types to the ingame list place them in this array.
        string[] fileTypes = {"*.mp4", "*.mp3" };
        int pathLength = (videoFolder.Length);
        string buttonTag = "vButton";
        //Debug.Log(pathLength);
      
        //Debug.Log(filePaths[0]);
        float yCoord = 1.5f;
        float zCoord = 2.5f;
        for (int k = 0; k < fileTypes.Length; k++)
        {
            string[] filePaths = Directory.GetFiles(videoFolder, fileTypes[k]);
            for (int x = 0; x < filePaths.Length; x++)
            {
                yCoord = yCoord - 0.07f;
                //zCoord = zCoord + (x * 0.1f);
                Transform buttonClone = Instantiate(videoButton, new Vector3(0, yCoord, zCoord), Quaternion.identity, videoCanvas);
                string fileName = filePaths[x].Remove(0, pathLength);
                buttonClone.GetComponentInChildren<Text>().text = fileName;
                buttonClone.tag = buttonTag;
                buttonClone.SendMessage("SetFilePath", filePaths[x]);
                Debug.Log(fileName);
            }
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
