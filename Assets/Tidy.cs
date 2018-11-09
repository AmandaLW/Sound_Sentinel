using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tidy : MonoBehaviour {

    // Use this for initialization

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FloorCube")
        {
            Destroy(collision.gameObject);
        }
    }
}
