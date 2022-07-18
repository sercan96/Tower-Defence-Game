using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Text LivesText;

    void Update()
    {
        LivesText.text = PlayerStats.Lives.ToString() + " LIVES";
    }
}
