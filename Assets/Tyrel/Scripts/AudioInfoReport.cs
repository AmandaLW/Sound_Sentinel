using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInfoReport : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var temp = GetComponent<AudioSource>();
        Debug.Log("clip: " + temp.clip);
        Debug.Log(temp.outputAudioMixerGroup);
        Debug.Log(temp);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
