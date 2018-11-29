using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoStressTest : MediaScript
{   
    override public void PlayVideo()
    {
        //Set display target to override current object material
        videoPlayer.renderMode = VideoRenderMode.MaterialOverride;
        
        //Disable Play on Awake for both Video and Audio
        videoPlayer.playOnAwake = false;

        //We want to play from URL or path names
        videoPlayer.source = VideoSource.Url;

        //Set video To Play then prepare Audio to prevent Buffering
        videoPlayer.url = multimedia[multimediaIndex];

        //Set Audio Output to AudioSource
        videoPlayer.audioOutputMode = VideoAudioOutputMode.Direct;

        //Play Video
        videoPlayer.Play();
    }
}
