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
    //private AudioSource audioSource;
    private AudioSource musicSource;

    //Define variables to hold the path of the files that list the viable items to be played
    private string m_path;
    //string videoList;

    //Define a list that will hold the media path+filenames to be loaded
    private List<string> multimedia = new List<string>();
    private string mediaType;
    private int multimediaIndex;

    private float time = 1;
    //private float timeRemaining;

    private bool musicPaused = false;

    // Use this for initialization
    void Start()
    {
        //Add VideoPlayer to the GameObject
        videoPlayer = gameObject.AddComponent<VideoPlayer>();

        //Add AudioSource to the GameObject
        //audioSource = gameObject.AddComponent<AudioSource>();
        musicSource = gameObject.AddComponent<AudioSource>();

        //Initialize the path
        //Application.dataPath returns the Assets folder when being run in Unity
        m_path = Application.dataPath + "/Resources/";


        //Read all viable media types into a list
        multimedia.AddRange(System.IO.Directory.GetFiles(m_path, "*.mp4"));
        multimedia.AddRange(System.IO.Directory.GetFiles(m_path, "*.mp3"));

        //foreach (string m in multimedia)
        //    Debug.Log(m);

        multimediaIndex = Random.Range(0, multimedia.Count - 1);
        multimediaIndex = multimedia.Count - 2;

        PlayNext();
    }

    
    void Update()
    {
        time = time - Time.deltaTime;
        if (time < 0)
        {
            if (mediaType == "mp4" && ((float)videoPlayer.frameCount - videoPlayer.frame) < 10 && musicPaused == false)
            {
                multimediaIndex = (multimediaIndex + 1) % multimedia.Count;
                PlayNext();
            }
            else if (mediaType == "mp3" && !musicSource.isPlaying && musicPaused == false)
            {
                multimediaIndex = (multimediaIndex + 1) % multimedia.Count;
                PlayNext();
            }
            time = 1;
        }
    }

    private void PlayVideo()
    {
        Debug.Log(System.DateTime.Now.ToString("HH:mm:ss") + " Play video");
        //Set display target to override current object material
        videoPlayer.renderMode = VideoRenderMode.MaterialOverride;

        //Disable Play on Awake for both Video and Audio
        videoPlayer.playOnAwake = false;
        //audioSource.playOnAwake = false;

        //We want to play from URL or path names
        videoPlayer.source = VideoSource.Url;

        //Set video To Play then prepare Audio to prevent Buffering
        videoPlayer.url = multimedia[multimediaIndex];

        //Set Audio Output to AudioSource
        videoPlayer.audioOutputMode = VideoAudioOutputMode.Direct;

        //Assign the Audio from Video to AudioSource to be played
        //videoPlayer.EnableAudioTrack(0, true);
        //videoPlayer.SetTargetAudioSource(0, audioSource);

        //videoPlayer.isLooping = true;
        //Play Video
        videoPlayer.Play();

        //Play Sound
        //audioSource.Play();
    }

    private void PlayMusic()
    {
        Debug.Log(System.DateTime.Now.ToString("HH:mm:ss") + " Play music");
        //Load file as audio clip
        musicSource.clip = Resources.Load<AudioClip>(System.IO.Path.GetFileNameWithoutExtension(multimedia[multimediaIndex]));

        //Debug.Log((audioSource.clip == null) ? "clip is null" : "clip is not null");
       
        //Play song
        musicSource.Play();
    }

    private void PlayNext()
    {
        if (multimedia[multimediaIndex].Contains(".mp4"))
        {
            Debug.Log(System.DateTime.Now.ToString("HH:mm:ss") + "-  This is an mp4");
            Debug.Log(multimedia[multimediaIndex]);
            mediaType = "mp4";
            PlayVideo();
        }
        else if (multimedia[multimediaIndex].Contains(".mp3"))
        {
            Debug.Log(System.DateTime.Now.ToString("HH:mm:ss") + "-  This is an mp3");
            Debug.Log(multimedia[multimediaIndex]);
            mediaType = "mp3";
            PlayMusic();
        }
        else
        {
            Debug.Log(System.DateTime.Now.ToString("HH:mm:ss") + "-  Invalid media type.");
            multimediaIndex = (multimediaIndex + 1) % multimedia.Count;
            PlayNext();
        }
    }

    public void Pause()
    {
        videoPlayer.Pause();
        musicSource.Pause();
        musicPaused = true;
    }

    public void Resume()
    {
        videoPlayer.Play();
        musicSource.UnPause();
        musicPaused = false;
    }

    //This function reports to the testing system when the game is quit
    private void OnApplicationQuit()
    {
        TestingResults temp = GameObject.FindGameObjectWithTag("Testing").GetComponent<TestingResults>();
        temp.TestRecords("MediaScript", true);
    }
}