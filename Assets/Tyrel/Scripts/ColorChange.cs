using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour {

    Color[] colors = { Color.blue, Color.cyan, Color.green, new Color(255, 165, 0), Color.red, Color.black };
    int count;
    float time = (float)0.5;

    Renderer ballRenderer;

	// Use this for initialization
	void Start () {
        count = 0;
        ballRenderer = gameObject.GetComponent<Renderer>();
        ballRenderer.material.color = Color.yellow;
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
            time = (float)0.5;
        }
    }

    public int GetColor()
    {
        return count;
    }
}
