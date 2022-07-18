using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Build Manager in scene");
            return;
        }
        Instance = this;
    }

    // public GameObject StandartTurretPrefab;
    // public GameObject PurchaseMissileLouncher;
    private TurretBluePrint _turretToBuild;
    public GameObject BuildEffect;
    
    #region ChooseTurret
    // Prefab objeyi buradan yakalıyoruz.
    // GetToTurretBuild methodu null değilse yani içinde obje yoksa mouse ile seçim yapılmasına izin verilmeyecek.
    #endregion
    // public TurretBluePrint GetToTurretBuild() 
    // {
    //     return _turretToBuild; 
    // }
    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < _turretToBuild.Cost) return;
        
        GameObject turret = (GameObject)Instantiate(_turretToBuild.Prefab, node.GetBuildPosition(), Quaternion.identity);
        node.Turret = turret;
        GameObject buildEffect = Instantiate(BuildEffect, node.GetBuildPosition(),BuildEffect.transform.rotation);
        Destroy(buildEffect,5f);
        
        PlayerStats.Money -= _turretToBuild.Cost;
        Debug.Log("Turret Build! Money Left : " + PlayerStats.Money);
    }
    public bool CanBuild {get {return _turretToBuild !=null; }}
    public bool HasMoney {get {return PlayerStats.Money >= _turretToBuild.Cost; }}

    public void SelectTurretToBuild(TurretBluePrint turret) // istediğimiz turret objesini buraya ekliyeceğiz.
    {
        _turretToBuild = turret;
    }
}
