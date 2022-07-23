using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager _buildManager;
    public TurretBluePrint StandardTurret; // Bu objenin birden fazla özelliği oludğu için ayrı bir sctipttte data tutması gerekir.
    public TurretBluePrint MissileLauncher;
    public TurretBluePrint LaserBeamer;

    void Start()
    {
        _buildManager = BuildManager.Instance;
    }
    public void SelectStandartTurret() // Button Click
    {
        Debug.Log("Standart Turret Selected");
        _buildManager.SelectTurretToBuild(StandardTurret); // Tek bir yerden örneği alındığı için objeleri yakalayabiliyoruz.
    }    
    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher Selected");
        _buildManager.SelectTurretToBuild(MissileLauncher);
    }
    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer Selected");
        _buildManager.SelectTurretToBuild(LaserBeamer);
    }
}
