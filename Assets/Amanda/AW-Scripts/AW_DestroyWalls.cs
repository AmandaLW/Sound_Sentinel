using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AW_DestroyWalls : MonoBehaviour {


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FloorCube")
        {
            Destroy(collision.gameObject);
        }
    }
}
