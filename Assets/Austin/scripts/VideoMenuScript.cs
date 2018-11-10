using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class VideoMenuScript : MonoBehaviour {
    public Transform videoButton;
    public Transform videoCanvas;
	void Start () {
        string videoFolder= @"C:\Users\pizza\Documents\Github\Sound_Sentinel\Assets\Tyrel\Videos";
        int pathLength = (videoFolder.Length + 1);
        Debug.Log(pathLength);
        string[] filePaths = Directory.GetFiles(videoFolder, "*.mp4");
        Debug.Log(filePaths[0]);
        for (int x = 0; x < filePaths.Length; x++)
        {
            Transform buttonClone = Instantiate(videoButton, new Vector3(0, 0, 0), Quaternion.identity, videoCanvas);
            string fileName = filePaths[x].Remove(0, pathLength);
            buttonClone.GetComponentInChildren<Text>().text = fileName;
            Debug.Log(fileName);
        }
    }

}
