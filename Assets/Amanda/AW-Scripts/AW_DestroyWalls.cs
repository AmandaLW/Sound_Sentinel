using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AW_DestroyWalls : MonoBehaviour {
    Score ballsmackin;

    void Start()
    {
        ballsmackin = GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<Score>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FloorCube")
        {
            Destroy(collision.gameObject);
            ballsmackin.UpdateScore(1);
        }
    }
}
