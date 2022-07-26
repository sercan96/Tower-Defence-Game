using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [System.Serializable]
[CreateAssetMenu(fileName = "new Turret",menuName = "Turret")]
public class TurretBluePrint : ScriptableObject                       // Turretlerin özellikleri buraya eklenecek.
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
