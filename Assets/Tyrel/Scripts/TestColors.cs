using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TestColors : MonoBehaviour
{

    protected Color[] colors = { Color.cyan, Color.green };

    protected int count;
    protected float time = 1;

    public MeshRenderer ballRenderer;
    public Texture albedo;

    // Use this for initialization
    void Start()
    {
        count = 0;
        ballRenderer = gameObject.GetComponent<MeshRenderer>();
        albedo = ballRenderer.material.mainTexture;
        ballRenderer.material.color = Color.yellow;       
    }

    // Update is called once per frame
    virtual public void Update()
    {
        time = time - Time.deltaTime;
        if (time < 0)
            SwapColor();
    }

    private void SwapColor()
    {
        if (count < colors.Length)
        {
            ballRenderer.material.color = colors[count];
            count++;
            time = 2;
        }
        else if(count == colors.Length)
        {
            ballRenderer.material.color = Color.grey;
            count++;
            time = 2;
        }
        else
        {
            ballRenderer.material.mainTexture = Resources.Load<Texture2D>("Tyrel/Texture/VideoMaterialTexture");
            //ballRenderer.material.m
            //ballRenderer.material.SetColor("_EmissionColor", Resources.Load<Texture2D>("Tyrel/Texture/VideoMaterialTexture"));
            //Debug.Log(ballRenderer.material.GetTexturePropertyNameIDs());
            //ballRenderer.material.SetTexture("_MainTex", Resources.Load<Texture>("Tyrel/Texture/VideoMaterialTexture"));
            //ballRenderer.material = Resources.Load<Material>("Tyrel/Texture/VideoMaterialTexture");
            time = 30;
        }
        albedo = ballRenderer.material.mainTexture;
    }

    public int GetColor()
    {
        return count;
    }
}
