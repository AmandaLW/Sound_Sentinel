using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//control the instantiated video buttons
public class VideoButton : MonoBehaviour {
    public string filePath;

    //will accept message sent from VideoMenuScript with corresponding file path
    public void SetFilePath(string path)
    {
        filePath = path;
        //Debug.Log("file path set");
    }
    //If this button is pressed the file path will be placed in the singleton so it can be passed to the next scene
	public void PassFilePath()
    {
        VideoSingleton.Instance.VideoString = filePath;
        Debug.Log(VideoSingleton.Instance.VideoString);
    }
}
