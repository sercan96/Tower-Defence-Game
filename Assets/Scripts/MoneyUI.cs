using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    private Text _moneyText;

    void Awake()
    {
        _moneyText = gameObject.GetComponent<Text>();
    }
    void Update()
    {
        _moneyText.text = "$ " + PlayerStats.Money;
    }
}
