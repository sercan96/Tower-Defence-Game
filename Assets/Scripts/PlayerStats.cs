using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int StartMoney = 600;
    public static int Lives;
    public int StartLives = 1;

    void Start()
    {
        Money = StartMoney; // Dk.17.33 Video 11
        Lives = StartLives;
    }
}
