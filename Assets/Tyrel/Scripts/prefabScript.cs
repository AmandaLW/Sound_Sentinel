using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabScript : MonoBehaviour {
    public Transform[] prefabItems;
    //public Transform spherefab;
    public int creationNumber; //[Assign in Editor]
    public int delay_in_seconds;

	// Use this for initialization
	void Start () {
        StartCoroutine(pause());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator pause()
    {
        int pos_x;
        int pos_y;
        for (int i = 0; i < creationNumber; i++)
        {
            pos_x = -10;
            pos_y = 0;
            for(int j=0; j < prefabItems.Length; j++)
            {
                Instantiate(prefabItems[j], new Vector3(pos_x, pos_y, 5), Quaternion.identity);
                pos_x += 5;
            }
            //pos_x *= -1;
            //pos_y *= -1;
            

            //Instantiate(cubefab, new Vector3(pos1, 0, 5), Quaternion.identity);
            //Instantiate(spherefab, new Vector3(pos2, 0, 5), Quaternion.identity);
            yield return new WaitForSeconds(delay_in_seconds);
        }
    }
}
