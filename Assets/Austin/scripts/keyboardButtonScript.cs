using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboardButtonScript : MonoBehaviour {
    string keyboardLetter;
    public void SetLetter(string letter)
    {
        keyboardLetter = letter;
        Debug.Log(keyboardLetter);
    }

    public void addLetterToName()
    {
        if (VideoSingleton.Instance.playerName.Length < 12)
        {
            Debug.Log(VideoSingleton.Instance.playerName);
            VideoSingleton.Instance.playerName = (VideoSingleton.Instance.playerName + keyboardLetter);
            Debug.Log(VideoSingleton.Instance.playerName);
        }
    }
    public void backspace()
    {
        if (VideoSingleton.Instance.playerName.Length > 0)
        {
            string backOne = VideoSingleton.Instance.playerName.Remove(VideoSingleton.Instance.playerName.Length - 1);
            VideoSingleton.Instance.playerName = backOne;
        }
    }   

        
}
