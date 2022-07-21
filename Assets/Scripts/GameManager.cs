using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static bool GameIsOver;
  public GameObject GameOverUI;

  void Start()
  {
    GameIsOver = false; // oyun resetlendiğinde bu değişken statik olduğu için değeri değişebilir o sebeple tekrardan false çekiyoruz.
    Debug.Log(GameIsOver);
  }

  void Update()
  {
    if (GameIsOver) return;
    if (Input.GetKeyDown(KeyCode.E)) EndGame();
    if (PlayerStats.Lives < 0)    EndGame();
  }

  private void EndGame()
  {
    GameIsOver = true;
    GameOverUI.SetActive(true);
  }


}
