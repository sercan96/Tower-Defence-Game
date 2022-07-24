using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBluePrint                        // Turretlerin özellikleri buraya eklenecek.
{
    public GameObject Prefab;
    public int Cost;

    public GameObject UpgradePrefab;
    public int UpgradeCost;

    
    
    public int GetSellAmount(int amount)
    {
        return (Cost / 2) + amount;
    }

}
