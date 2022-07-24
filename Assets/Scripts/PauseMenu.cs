using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public GameObject PauseUI;
    public SceneFader SceneFader;
    public string MainMenu = "MainMenu";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    public void Toggle() // continue button
    {
        PauseUI.SetActive(!PauseUI.activeSelf); 
        // True veya false yapmak yerine şuanki durumu neyse tersini al diyerek daha performanslı bir iş yapmış oluyoruz.
        if (PauseUI.activeSelf)
        {
            Time.timeScale = 0; // Oyunu durdur anlamına gelir.
        }
        else
        {
            Time.timeScale = 1; // Oyun kaldığı yerden devam eder.
        }
        
    }

    public void Retry()
    {
        #region Time.timeScale Command
        //Time.timeScale = 1;
        //Sahne yenilediğimizde oyun durdurma eski haline gelmez. Onu tekrar 1 e eşitlemek zorundayız.
        //Çünkü Scale statik olarak tanımlanmıştır.
        #endregion
        
        Toggle();
        SceneFader.FadeTo(SceneManager.GetActiveScene().name); // Şuanki sahnenin ismi
    }

    public void Menu()
    {
        Toggle();
        SceneFader.FadeTo(MainMenu);
    }
}
