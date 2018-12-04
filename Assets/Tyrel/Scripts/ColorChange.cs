using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ColorChange : MonoBehaviour {

    Color[] colors = { Color.blue, Color.cyan, Color.green, Color.red, Color.black };
    //Color[] colors = { Color.green, Color.red };
    int count;
    float time = (float)0.5;
    Scene m_Scene;
    string mainScene = "Sound_Sentinel";

    Renderer ballRenderer;

	// Use this for initialization
	void Start () {
        m_Scene = SceneManager.GetActiveScene();
        if (m_Scene.name == mainScene)
        {
            count = 0;
            ballRenderer = gameObject.GetComponent<Renderer>();
            ballRenderer.material.color = Color.yellow;
        }
        else
        {
            Debug.Log(m_Scene.name);
            SendMessage("SetHintText", colors);
        }
	}
	
	// Update is called once per frame
	void Update () {
        time = time - Time.deltaTime;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (time < 0 && count < colors.Length)
        {
            ballRenderer.material.color = colors[count];
            count++;
            if (count == colors.Length)
            {
                ballRenderer = Resources.Load<Renderer>("Tyrel/Texture/VideoMaterialTexture");
            }
            time = (float)0.5;
        }
    }

    public int GetColor()
    {
        return count;
    }
}
