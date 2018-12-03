using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DisplayName : MonoBehaviour {
    public Transform displayedName;
	// Update is called once per frame
	void Update () {
        displayedName.GetComponent<Text>().text = VideoSingleton.Instance.playerName;
	}
}
