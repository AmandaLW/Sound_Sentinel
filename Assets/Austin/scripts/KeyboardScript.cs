using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class KeyboardScript : MonoBehaviour {
    public Transform keyboardButton;
    public Transform keyboardCanvas;
	public void SetupKeyboard()
    {
        string[] lineOne = { "q", "w", "e", "r", "t", "y", "u", "i", "o", "p"};
        string[] lineTwo = { "a", "s", "d", "f", "g", "h", "j", "k", "l"};
        string[] lineThree = { "z", "x", "e", "v", "b", "n", "m"};
        float xCoord = -0.5f;
        float yCoord = 1.8f;
        float zCoord = 2;
        string letter;
        for(int x = 0; x < lineOne.Length; x++)
        {
            letter = lineOne[x];
            Transform buttonClone = Instantiate(keyboardButton, new Vector3(xCoord, yCoord, zCoord), Quaternion.identity, keyboardCanvas);
            buttonClone.GetComponentInChildren<Text>().text = letter;
            buttonClone.SendMessage("SetLetter", letter);
            xCoord = xCoord + 0.12f;
        }
        xCoord = -0.5f;
        yCoord = yCoord - 0.12f;
        for (int k = 0; k < lineTwo.Length; k++)
        {
            letter = lineTwo[k];
            Transform buttonClone = Instantiate(keyboardButton, new Vector3(xCoord, yCoord, zCoord), Quaternion.identity, keyboardCanvas);
            buttonClone.GetComponentInChildren<Text>().text = letter;
            buttonClone.SendMessage("SetLetter", letter);
            xCoord = xCoord + 0.12f;
        }
        xCoord = -0.5f;
        yCoord = yCoord - 0.12f;
        for (int i = 0; i < lineThree.Length; i++)
        {
            letter = lineThree[i];
            Transform buttonClone = Instantiate(keyboardButton, new Vector3(xCoord, yCoord, zCoord), Quaternion.identity, keyboardCanvas);
            buttonClone.GetComponentInChildren<Text>().text = letter;
            buttonClone.SendMessage("SetLetter", letter);
            xCoord = xCoord + 0.12f;
        }
    }
}
