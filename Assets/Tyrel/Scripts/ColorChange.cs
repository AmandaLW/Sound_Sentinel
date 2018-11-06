using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour {

    float red = 0;
    float green = 150;
    float blue = 150;

    int increment = 10;

    Renderer ballRenderer;

	// Use this for initialization
	void Start () {
        ballRenderer = gameObject.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        ballRenderer.material.color = new Color(red, green, blue);
        red += 50;
        green += increment;
        blue += increment;
    }
}
