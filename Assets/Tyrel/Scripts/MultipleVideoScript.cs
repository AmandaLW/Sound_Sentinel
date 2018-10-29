using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MultipleVideoScript : MonoBehaviour {

    public RenderTexture vidTexture;
    public VideoClip videoToPlay;

    private GameObject plane;
    private GameObject cube; 
    private GameObject sphere;
    private GameObject capsule;
    private GameObject cylinder;

    // Use this for initialization
    void Start () {
        plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

        cCubeVid();
        cPlaneVid();
        cCapVid();
        cCylVid();
        cSphereVid();
    }
	
	// Update is called once per frame
	void Update () {
        cube.gameObject.GetComponent<Rigidbody>().transform.Translate(Vector3.left * Time.deltaTime);
        //cube.gameObject.GetComponent<Rigidbody>().AddForce(Vector3(-1, 1, 0));
    }

    private void cPlaneVid()
    {
       
    }

    void cCubeVid()
    {        
        cube.transform.position = new Vector3(0, 5.5f, 0);

        //Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        //rb.AddForce(Vector3.left * 100f);
        VideoPlayer videoPlayer = gameObject.AddComponent<VideoPlayer>();
        //VideoSource videoSource = gameObject.AddComponent<VideoSource>();
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();

        //gameObject.AddComponent<RenderTexture>();
        videoPlayer.targetTexture = vidTexture;
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.RenderTexture;

        videoPlayer.clip = videoToPlay;
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

        //Assign the Audio from Video to AudioSource to be played
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);

        //Play Video
        videoPlayer.Play();

        //Play Sound
        audioSource.Play();
    }

    private void cSphereVid()
    {
        sphere.transform.position = new Vector3(0, 1.5f, 0);
    }

    private void cCapVid()
    {
       
        capsule.transform.position = new Vector3(2, 1, 0);
    }

    private void cCylVid()
    {
        cylinder.transform.position = new Vector3(-2, 1, 0);
    }
}
