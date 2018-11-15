using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour {

    Color[] colors = { Color.blue, Color.cyan, Color.green, Color.yellow, Color.red, Color.black };
    int count;

    Renderer ballRenderer;

	// Use this for initialization
	void Start () {
        count = 0;
        ballRenderer = gameObject.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        ballRenderer.material.color = colors[count];
        if (count < colors.Length)
            count++;
    }
}
