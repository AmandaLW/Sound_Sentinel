using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoButton : MonoBehaviour {
    public string filePath;


    public void SetFilePath(string path)
    {
        filePath = path;
        //Debug.Log("file path set");
    }
	public void PassFilePath()
    {
        VideoSingleton.Instance.VideoString = filePath;
        Debug.Log(VideoSingleton.Instance.VideoString);
      //MyScript temp = GameObject.GetComponent<SceneChange>;
      //temp.SceneChanger("Sound_Sentinel");
    }
}
