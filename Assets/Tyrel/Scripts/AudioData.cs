using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioData : MonoBehaviour {
    public float[] samples = new float[512];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetAudioData();
	}

    void GetAudioData()
    {
        GetComponent<AudioSource>().GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }
}
