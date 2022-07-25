using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneFader SceneFader;
    public string LevelToLoad;
    
    public void Play()
    {
        SceneFader.FadeTo(LevelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
