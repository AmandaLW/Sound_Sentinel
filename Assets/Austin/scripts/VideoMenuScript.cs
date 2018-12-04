using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
//Generates the list of buttons to select video from 
public class VideoMenuScript : MonoBehaviour {
    public Transform videoButton;
    public Transform videoCanvas;
    void Start()
    {
        //this is the folder the game looks at when making a list of video/music options
        //to add additional file types add folder path here and file type in next array
        string[] folderPaths = { (Application.dataPath + "/Resources/Tyrel/video/"), (Application.dataPath + "/Resources/Tyrel/Music/") };
        //To add additional file types to the ingame list place them in this array.
        string[] fileTypes = { "*.mp4", "*.mp3" };
        int[] pathLength = new int[fileTypes.Length];
        for (int i = 0; i < folderPaths.Length; i++)
        {
             pathLength[i] = folderPaths[i].Length;
        }
        string buttonTag = "vButton";
        //Debug.Log(pathLength);
      
        //Debug.Log(filePaths[0]);
        float yCoord = 2f;
        float zCoord = 2.2f;
        //step through all specified file types
        for (int k = 0; k < fileTypes.Length; k++)
        {
            //read all files of a type into an array
            string[] filePaths = Directory.GetFiles(folderPaths[k], fileTypes[k]);

            //step through file of given type found in a file and create a button for each
            for (int x = 0; x < filePaths.Length; x++)
            {
                //move button down so they don't overlap
                yCoord = yCoord - 0.08f;
                //create new button as a child of the video menu canvas
                Transform buttonClone = Instantiate(videoButton, new Vector3(0, yCoord, zCoord), Quaternion.identity, videoCanvas);
                string fileName = filePaths[x].Remove(0, pathLength[k]);
                buttonClone.GetComponentInChildren<Text>().text = fileName;
                buttonClone.tag = buttonTag;
                //send video's file path to button in case that video is selected
                buttonClone.SendMessage("SetFilePath", filePaths[x]);
                //Debug.Log(fileName);
            }
        }
    }

}
