using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this class does nothing but shows you how to use menu prefabs
    //To use a prefab in a script make a varible to assign it to

    //here we use instantiate to make a new copy of our prefab as a game object and assign it to buttonClone so we can set values
    //parameters for Istantiate in this case are 
    //Instantiate(referenceToPrefab, vector3(based off origin in game not parent canvas), Quaternion.identity, parentCanvas);
    
    //an example 
    //Transform buttonClone = Instantiate(buttonCopy, new Vector3(0, 1.5, 0), Quaternion.identity, buttonCanvas);
    
    //now we can use buttonClone to set all sorts of properties on the new object
    //some properties are accessed directly and some need to be searched for 

    //tag is accessed directly
    //buttonClone.tag = buttonTag;

    //the buttons text is a child of the button and needs to be searched for
    //buttonClone.GetComponentInChildren<Text>().text = textString;
}
