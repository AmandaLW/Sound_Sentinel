using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class MediaScript : MonoBehaviour
{
    //Define variables to hold the videoplayer
    protected VideoPlayer videoPlayer;

    //Define a variable to hold the audioplayer
    protected AudioSource musicSource;

    //Define variables to hold the path of the files that list the viable items to be played
    protected string m_path;

    //Define a list that will hold the media path+filenames to be loaded
    protected List<string> multimedia = new List<string>();
    protected int multimediaIndex;

    //Use as a file type marker
    protected string mediaType;

    //Initialize the time variable for the update function
    protected float time = 1;

    //Used to determine if the music is paused instead of not playing
    protected bool musicPaused = false;

    // Use this for initialization
    public void Start()
    {
        //Add VideoPlayer to the GameObject
        videoPlayer = gameObject.AddComponent<VideoPlayer>();

        //Add AudioSource to the GameObject
        musicSource = gameObject.AddComponent<AudioSource>();

        //var media = VideoSingleton.Instance.VideoString;
        if (VideoSingleton.Instance.VideoString == "random")
        {
            GetMediaList();
            PlayNext(multimedia[multimediaIndex]);
        }
        else
            PlayNext(VideoSingleton.Instance.VideoString);
        
    }

    private void GetMediaList()
    {
        //Initialize the path
        //Application.dataPath returns the Assets folder when being run in Unity
        m_path = Application.dataPath + "/Resources/Tyrel/";
        
        //Read all viable media types into a list
        multimedia.AddRange(System.IO.Directory.GetFiles(m_path + "Video/", "*.mp4"));
        multimedia.AddRange(System.IO.Directory.GetFiles(m_path + "Music/", "*.mp3"));

        //foreach (string m in multimedia)
        //    Debug.Log(m);

        multimediaIndex = Random.Range(0, multimedia.Count - 1);
        //multimediaIndex = multimedia.Count - 2;
    }

    
    private void Update()
    {
        //Use update to check if the video or music is done playing
        //Only check once a second
        time = time - Time.deltaTime;
        if (time < 0)
        {
            if (mediaType == "mp4" && ((float)videoPlayer.frameCount - videoPlayer.frame) < 10 && musicPaused == false)
            {
                multimediaIndex = (multimediaIndex + 1) % multimedia.Count;
                if (VideoSingleton.Instance.VideoString == "random")
                    PlayNext(multimedia[multimediaIndex]);
                else
                    gameObject.GetComponent<SceneChange>().SceneChanger("Menu_Scene");
            }
            else if (mediaType == "mp3" && !musicSource.isPlaying && musicPaused == false)
            {
                multimediaIndex = (multimediaIndex + 1) % multimedia.Count;
                if (VideoSingleton.Instance.VideoString == "random")
                    PlayNext(multimedia[multimediaIndex]);
                else
                    gameObject.GetComponent<SceneChange>().SceneChanger("Menu_Scene");
            }
            time = 1;
        }
    }

    virtual public void PlayVideo(string videoSource)
    {
        //Set display target to override current object material
        //videoPlayer.renderMode = VideoRenderMode.MaterialOverride;
        //videoPlayer.targetTexture = gameObject.GetComponent<RenderTexture>();
        //videoPlayer.targetMaterialRenderer = gameObject.GetComponent<Renderer>();
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        videoPlayer.targetTexture = Resources.Load<RenderTexture>("Tyrel/Textures/VideoMaterialTexture");

        //Disable Play on Awake for both Video and Audio
        videoPlayer.playOnAwake = false;

        //We want to play from URL or path names
        videoPlayer.source = VideoSource.Url;

        //Set video To Play then prepare Audio to prevent Buffering
        videoPlayer.url = videoSource;

        //Set Audio Output to AudioSource
        videoPlayer.audioOutputMode = VideoAudioOutputMode.Direct;

        //Play Video
        videoPlayer.Play();
    }

    private void PlayMusic(string music)
    {
        //Load file as audio clip
        musicSource.clip = Resources.Load<AudioClip>(System.IO.Path.GetFileNameWithoutExtension(music));
       
        //Play song
        musicSource.Play();

        //Add the call to visualization function for the song here
    }

    private void PlayNext(string media)
    {
        //Call function to play MP4
        if (media.Contains(".mp4"))
        {
            mediaType = "mp4";
            PlayVideo(media);
        }
        //Call the function to play MP3
        else if (media.Contains(".mp3"))
        {
            mediaType = "mp3";
            PlayMusic(media);
        }
        //If the media type is incorrect then it will send a debug log and play the next song
        else
        {
            Debug.Log(System.DateTime.Now.ToString("HH:mm:ss") + "-  Invalid media type.");
            multimediaIndex = (multimediaIndex + 1) % multimedia.Count;
            PlayNext(multimedia[multimediaIndex]);
        }
    }

    //This function is used to pause the video and music players
    public void Pause()
    {
        videoPlayer.Pause();
        musicSource.Pause();
        musicPaused = true;
    }
    //This function is used to resume the video and music players
    public void Resume()
    {
        videoPlayer.Play();
        musicSource.UnPause();
        musicPaused = false;
    }

    //This function reports to the testing system when the game is quit
    private void OnApplicationQuit()
    {
        //TestingResults temp = GameObject.FindGameObjectWithTag("Testing").GetComponent<TestingResults>();
        GameObject.FindGameObjectWithTag("Testing").GetComponent<TestingResults>().RecordTests("MediaScript", true);
        //TestingPlatform.Instance.RecordTests(gameObject.name, true);
        //Resources.UnloadAsset(videoPlayer);
    }
}