using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int StartMoney = 600;
    
    public static int Lives;
    public int StartLives = 1;
    
    public static int Rounds;
    public int StartRounds = 0;

    void Start()
    {
        Money = StartMoney; // Static oldukları için sahne yenilemesinde eski tuttukları değerleri almasını engelledik.
        Lives = StartLives;
        Rounds = StartRounds;
    }
    
    public static void IncreaseLıves()
    {
        Lives++;
    }
}
