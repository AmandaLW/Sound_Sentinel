using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ColorChange : MonoBehaviour {

    Color[] colors = { Color.yellow, Color.blue, Color.cyan, Color.green, Color.red, Color.black };
    //Color[] colors = { Color.red };
    int count;
    float time = (float)0.5;
    Scene m_Scene;
    string mainScene = "Sound_Sentinel";

    public Renderer ballRenderer;
    public Texture albedo;
    

	// Use this for initialization
	void Start () {
        m_Scene = SceneManager.GetActiveScene();
        if (m_Scene.name == mainScene)
        {
            count = 0;
            ballRenderer = gameObject.GetComponent<Renderer>();
            albedo = ballRenderer.material.mainTexture;
            ballRenderer.material.color = colors[count++];
        }
        else
        {
            Debug.Log(m_Scene.name);
            SendMessage("SetHintText", colors);
        }
	}
	
	// Update is called once per frame
	virtual public void Update () {
        time = time - Time.deltaTime;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (time < 0 && count < colors.Length)
        {
            ballRenderer.material.color = colors[count];
            count++;
            time = (float)0.5;
        }
        if(ballRenderer.material.color == Color.red)
        {
            ballRenderer.material.mainTexture = Resources.Load<Texture>("Tyrel/Texture/VideoMaterialTexture");
            //ballRenderer.material.SetColor("_EmissionColor", Resources.Load<Color>("Tyrel/Texture/VideoMaterialTexture"));
            //Debug.Log(ballRenderer.material.GetTexturePropertyNameIDs());
            //ballRenderer.material.SetTexture("_MainTex", Resources.Load<Texture>("Tyrel/Texture/VideoMaterialTexture"));
        }
        albedo = ballRenderer.material.mainTexture;
    }

    public int GetColor()
    {
        return count;
    }

    public Color[] GetColorArray()
    {
        return colors;
    }
}
