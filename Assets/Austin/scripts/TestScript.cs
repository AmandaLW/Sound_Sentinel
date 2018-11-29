using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Does a test run through of button presses to insure navigation works
public class TestScript : MonoBehaviour {
    public Button StartButton;
    public Button TestMenuButton;
    public Button TestBackButton;
    public Button ScoreBackButton;
    public Button HelpBackButton;
    public Button HelpMenuButton;
    public Button ScoreMenuButton;
    public void MenuTest()
    {
        //calls onclick functions from the inspector
        TestMenuButton.onClick.Invoke();
        TestBackButton.onClick.Invoke();
        HelpMenuButton.onClick.Invoke();
        HelpBackButton.onClick.Invoke();
        ScoreMenuButton.onClick.Invoke();
        ScoreBackButton.onClick.Invoke();
        StartButton.onClick.Invoke();
    }
 
}
