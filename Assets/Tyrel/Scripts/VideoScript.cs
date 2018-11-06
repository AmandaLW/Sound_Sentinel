using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoScript : MonoBehaviour
{
    //Video To Play
    private VideoClip videoToPlay;

    private VideoPlayer videoPlayer;
    private VideoSource videoSource;

    //Audio
    private AudioSource audioSource;

    string m_path;// = Application.dataPath + "/Tyrel/Videos/";
    string videoList;// = Application.dataPath + "/Tyrel/Videos/VideoList.list";
    //string[] videos = System.IO.File.ReadAllLines(Application.dataPath + "/Tyrel/Videos/VideoList.list");

    //string[] videos;

    // Use this for initialization
    void Start()
    {
        string temp;

        m_path = Application.dataPath + "/Tyrel/Videos/";
        videoList = m_path + "VideoList.list";

        string[] videos = System.IO.File.ReadAllLines(videoList);

        for(int i=0; i< videos.Length; i++)
        {
            temp = videos[i].Substring(0, 4);

            if (videos[i].Substring(0, 2) == "NO")
            {
                videos[i] = "";
            }
            else if (temp != "http")
            {
                temp = videos[i];
                videos[i] = "file:///" + m_path + temp;
            }
            
        }

        PlayVideo(videos);
        //Debug.Log("Returned from playing video");
    }

    //
    private void Update()
    {
        
    }

    void PlayVideo(string[] videos)
    {
        //Add VideoPlayer to the GameObject
        videoPlayer = gameObject.AddComponent<VideoPlayer>();

        //Add AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();

        //Set display target to override current object material
        videoPlayer.renderMode = VideoRenderMode.MaterialOverride;

        //Disable Play on Awake for both Video and Audio
        videoPlayer.playOnAwake = false;
        audioSource.playOnAwake = false;

        //We want to play from video clip not from url
        //videoPlayer.source = VideoSource.VideoClip;
        videoPlayer.source = VideoSource.Url;

        //Set video To Play then prepare Audio to prevent Buffering
        //videoPlayer.clip = videoToPlay;
        videoPlayer.url = videos[Random.Range(0, videos.Length)];

        //Set Audio Output to AudioSource
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

        //Assign the Audio from Video to AudioSource to be played
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);

        //Play Video
        videoPlayer.Play();

        //Play Sound
        audioSource.Play();
    }
    private void OnApplicationQuit()
    {
        TestingResults temp = GameObject.FindGameObjectWithTag("Testing").GetComponent<TestingResults>();
        temp.TestRecords("VideoScript", true);
    }
}