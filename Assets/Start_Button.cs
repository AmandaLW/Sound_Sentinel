using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Button : MonoBehaviour {
	
     void OnClick(){
			Debug.Log("onclick");
		    string sceneName = "Sound_Sentinel";
			
            SceneManager.LoadScene(sceneName);
			
	   }
	   
}
