using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneFader SceneFader;
    
    public void Play()
    {
        SceneFader.FadeTo("MainLevel");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
