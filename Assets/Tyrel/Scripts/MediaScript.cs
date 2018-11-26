using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class MediaScript : MonoBehaviour
{
    //Define a variable that will hold the location of the video you want to play
    //private VideoClip videoToPlay;

    //Define variables to hold the videoplayer
    private VideoPlayer videoPlayer;
    //private VideoSource videoSource;

    //Define a variable to hold the audioplayer
    private AudioSource audioSource;

    //Define variables to hold the path of the files that list the viable items to be played
    string m_path;
    //string videoList;

    //Define a list that will hold the media path+filenames to be loaded
    List<string> multimedia = new List<string>();
    string mediaType;
    int multimediaIndex;

    // Use this for initialization
    void Start()
    {
        //Add VideoPlayer to the GameObject
        videoPlayer = gameObject.AddComponent<VideoPlayer>();

        //Add AudioSource to the GameObject
        audioSource = gameObject.AddComponent<AudioSource>();

        //Initialize the path
        //Application.dataPath returns the Assets folder when being run in Unity
        m_path = Application.dataPath + "/Resources/";


        //Read all viable media types into a list
        multimedia.AddRange(System.IO.Directory.GetFiles(m_path, "*.mp4"));
        multimedia.AddRange(System.IO.Directory.GetFiles(m_path, "*.mp3"));

        //foreach (string m in multimedia)
        //    Debug.Log(m);

        multimediaIndex = Random.Range(0, multimedia.Count - 1);
        //multimediaIndex = multimedia.Count - 1;

        PlayNext();
    }

    
    void Update()
    {
        if (mediaType == "mp4" && ((float)videoPlayer.frameCount - videoPlayer.frame) < 10)
        {
            multimediaIndex = (multimediaIndex + 1) % multimedia.Count;
            PlayNext();
        }
        else if(mediaType == "mp3" && !audioSource.isPlaying)
        {
            multimediaIndex = (multimediaIndex + 1) % multimedia.Count;
            PlayNext();
        }
    }

    private void PlayVideo()
    {
        
        //Set display target to override current object material
        videoPlayer.renderMode = VideoRenderMode.MaterialOverride;

        //Disable Play on Awake for both Video and Audio
        videoPlayer.playOnAwake = false;
        audioSource.playOnAwake = false;

        //We want to play from URL or path names
        videoPlayer.source = VideoSource.Url;

        //Set video To Play then prepare Audio to prevent Buffering
        videoPlayer.url = multimedia[multimediaIndex];

        //Set Audio Output to AudioSource
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

        //Assign the Audio from Video to AudioSource to be played
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);

        //videoPlayer.isLooping = true;
        //Play Video
        videoPlayer.Play();

        //Play Sound
        audioSource.Play();
    }

    private void PlayMusic()
    {
        //Load file as audio clip
        audioSource.clip = Resources.Load<AudioClip>(System.IO.Path.GetFileNameWithoutExtension(multimedia[multimediaIndex]));

        //Debug.Log((audioSource.clip == null) ? "clip is null" : "clip is not null");
       
        //Play song
        audioSource.Play();
    }

    private void PlayNext()
    {
        if (multimedia[multimediaIndex].Contains(".mp4"))
        {
            //Debug.Log("This is an mp4");
            mediaType = "mp4";
            PlayVideo();
        }
        else if (multimedia[multimediaIndex].Contains(".mp3"))
        {
            //Debug.Log("This is an mp3");
            mediaType = "mp3";
            PlayMusic();
        }
        else
        {
            Debug.Log("Invalid media type.");
            multimediaIndex = (multimediaIndex + 1) % multimedia.Count;
            PlayNext();
        }
    }

    public void Pause()
    {
        videoPlayer.Pause();
        audioSource.Pause();
    }

    public void Resume()
    {
        videoPlayer.Play();
        audioSource.UnPause();
    }

    //This function reports to the testing system when the game is quit
    private void OnApplicationQuit()
    {
        TestingResults temp = GameObject.FindGameObjectWithTag("Testing").GetComponent<TestingResults>();
        temp.TestRecords("MediaScript", true);
    }
}