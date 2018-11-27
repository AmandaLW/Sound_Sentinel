using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class VideoMenuScript : MonoBehaviour {
    public Transform videoButton;
    public Transform videoCanvas;
	void Start () {
        string videoFolder = Application.dataPath + "/Tyrel/Videos/";
        int pathLength = (videoFolder.Length);
        Debug.Log(pathLength);
        string[] filePaths = Directory.GetFiles(videoFolder, "*.mp4");
        Debug.Log(filePaths[0]);
        for (int x = 0; x < filePaths.Length; x++)
        {
            float yCoord = 1.5f;
            float zCoord = 2.5f;
            yCoord = yCoord + (x * 0.05f);
            //zCoord = zCoord + (x * 0.1f);
            Transform buttonClone = Instantiate(videoButton, new Vector3(0, yCoord, zCoord), Quaternion.identity, videoCanvas);
            string fileName = filePaths[x].Remove(0, pathLength);
            buttonClone.GetComponentInChildren<Text>().text = fileName;
            buttonClone.GetComponentInChildren<Text>().tag = "vButton";
            Debug.Log(fileName);
        }
    }

}
