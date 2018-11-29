using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MediaInfoReport : MonoBehaviour {
    private float time = 15;
	// Use this for initialization
	void Start () {
        
    }
	// Update is called once per frame
	void Update () {
        time = time - Time.deltaTime;
        if (time < 0)
            ReportInfo();
	}

    private void ReportInfo()
    {
        var temp = GetComponent<AudioSource>();
        Debug.Log("clip: " + temp.clip);
        Debug.Log(temp.outputAudioMixerGroup);
        Debug.Log(temp);
        var tempVid = GetComponent<VideoPlayer>();
        Debug.Log(tempVid.targetTexture);
        Debug.Log(tempVid.texture);
        Debug.Log(tempVid.targetMaterialRenderer);
        Debug.Log(tempVid.targetMaterialProperty);
        //Debug.Log(tempVid.GetComponent<RenderTexture>().name);
        Debug.Log(GetComponent<MeshRenderer>().material);
        time = 60;
    }
}
