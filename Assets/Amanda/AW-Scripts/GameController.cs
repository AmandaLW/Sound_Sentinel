using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour {

    private int score;
    /*public TextMeshPro Scoretext;

    // Use this for initialization
    void Start () {
        score = 0;
        UpdateScore();

    }

    
    void UpdateScore()
    {
        //Scoretext = GetComponent<TextMeshPro>();
        Scoretext.text = "Score: " + score;
    }
    */

    void Awake()
    {
        TextMeshPro textmeshPro = GetComponent<TextMeshPro>();
        textmeshPro.text = "Example of text to be displayed.";
    }


}
