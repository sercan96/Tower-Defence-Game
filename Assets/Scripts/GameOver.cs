using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text RoundText;
    public SceneFader SceneFader;
    

    void OnEnable()
    {
        RoundText.text = PlayerStats.Rounds.ToString();
    }
    
    public void Replay()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        SceneFader.FadeTo("MainMenu");
    }
}
