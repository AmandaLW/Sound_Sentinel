using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioData : MonoBehaviour {
    private float[] samples = new float[512];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void GetAudioData()
    {
        GetComponent<AudioSource>().GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }
}
