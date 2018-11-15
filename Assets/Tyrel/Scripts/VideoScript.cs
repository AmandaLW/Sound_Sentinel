using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoScript : MonoBehaviour
{
    //Define a variable that will hold the location of the video you want to play
    private VideoClip videoToPlay;

    //Define variables to hold the videoplayer
    private VideoPlayer videoPlayer;
    private VideoSource videoSource;

    //Define a variable to hold the audioplayer
    private AudioSource audioSource;

    //Define variables to hold the path of the files that list the viable items to be played
    string m_path;
    string videoList;
    
    //Define an array that will hold the video filenames to be loaded
    string[] videos;
    int videoCount;

    // Use this for initialization
    void Start()
    {
        //Initialize the path and the filename
        //Application.dataPath returns the Assets folder when being run in Unity
        m_path = Application.dataPath + "/Tyrel/Videos/";
        videoList = m_path + "VideoList.list";

        //Read all lines from the file into the array
        videos = System.IO.File.ReadAllLines(videoList);
        
        //loop through all lines read from file
        for(int i=0; i< videos.Length; i++)
        {
            //NO is effectively the comment code for this list
            //Check for a the comment code to be present
            if (videos[i].Substring(0, 2) == "NO")
            {
                //Set the line equal to a viable option of NO is present at the front of the line
                videos[i] = ""; //*****MUST FIX******
            }
            //If it is not a full URL then we must add a path to the filename
            else if (videos[i].Substring(0, 4) != "http")
            {
                string temp = videos[i];
                videos[i] = "file:///" + m_path + temp;
            }
            videoCount = Random.Range(0, videos.Length);
        }

        PlayVideo();
    }

    
    void Update()
    {
        if(videoPlayer.isPlaying == false)
        {
            videoCount = (videoCount + 1) % videos.Length;
            //PlayVideo();
        }
    }

    void PlayVideo()
    {
        //Add VideoPlayer to the GameObject
        videoPlayer = gameObject.AddComponent<VideoPlayer>();

        //Add AudioSource to the GameObject
        audioSource = gameObject.AddComponent<AudioSource>();

        //Set display target to override current object material
        videoPlayer.renderMode = VideoRenderMode.MaterialOverride;

        //Disable Play on Awake for both Video and Audio
        videoPlayer.playOnAwake = false;
        audioSource.playOnAwake = false;

        //We want to play from URL or path names
        videoPlayer.source = VideoSource.Url;

        //Set video To Play then prepare Audio to prevent Buffering
        //Random selection from list
        //videoCount = 3;
        videoPlayer.url = videos[videoCount];

        //Set Audio Output to AudioSource
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

        //Assign the Audio from Video to AudioSource to be played
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);

        videoPlayer.isLooping = true;
        //Play Video
        videoPlayer.Play();

        //Play Sound
        audioSource.Play();
    }

    //This function reports to the testing system when the game is quit
    private void OnApplicationQuit()
    {
        TestingResults temp = GameObject.FindGameObjectWithTag("Testing").GetComponent<TestingResults>();
        temp.TestRecords("VideoScript", true);
    }
}