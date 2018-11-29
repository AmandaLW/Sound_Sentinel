using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Change scene to the passed one can be run using a button or sendmessage
public class SceneChange : MonoBehaviour {

	public void SceneChanger(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
