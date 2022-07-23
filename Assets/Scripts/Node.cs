using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color HoverColor;
    public Color NotEnoughMoneyColor;
    private Renderer _rend;

    [Header("Optional")]
    public GameObject Turret;
    
    private Color _startColor;
    public Vector3 PositionOffset;
    private BuildManager _buildManager;
    public NodeUI NodeUı;

    public bool IsUpgrade;

    public TurretBluePrint TurretBluePrint;

    void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
        _buildManager= BuildManager.Instance;
    }
    
    void OnMouseEnter() // Mouse ile üzerine gelindiğinde
    {
        if (!_buildManager.CanBuild) return; // Renginide değiştiremesin. Turret seçilmedi
        if (_buildManager.HasMoney)
            _rend.material.color = HoverColor;
        else
            _rend.material.color = NotEnoughMoneyColor;
    }
    void OnMouseDown() // Mouse ile tıklandığında
    {
        //if (_buildManager.GetToTurretBuild() == null) return; // içinde obje yoksa seçim yapamasın
        if (!_buildManager.CanBuild) return; // Boşsa
        if (Turret != null) // içinde obje varsa aynı yere bir tane daha eklenmesin.
        {
            _buildManager.SelectNode(this);
            // NodeUı.SetTarget(this); // Tüm Node lere bu referansı vermek zahmetli iştir.
            
            Debug.Log("Cant build there");
            return;
        }

        #region Command
        // Create Turret Build
        // GameObject turretToBuild = BuildManager.Instance.GetToTurretBuild();
        // Turret = Instantiate(turretToBuild, transform.position + PositionOffset, transform.rotation);
        #endregion

        // _buildManager.BuildTurretOn(this); // Bu scripte bağlı objeyi ver.
        BuildTurret(_buildManager.GetTurretToBuild());
    }


    public void BuildTurret(TurretBluePrint bluePrint)
    {
        if (PlayerStats.Money < bluePrint.Cost) return;
        
        GameObject turret = (GameObject)Instantiate(bluePrint.Prefab, GetBuildPosition(), Quaternion.identity);
        Turret = turret;

        TurretBluePrint = bluePrint; // upgrade edeceğimiz için bu değere objemizi eşitlememiz gerekir.
        
        GameObject buildEffect = Instantiate(_buildManager.BuildEffect,GetBuildPosition(),_buildManager.BuildEffect.transform.rotation);
        Destroy(buildEffect,5f);
        
        PlayerStats.Money -= bluePrint.Cost;
        
        Debug.Log("Turret Build! Money Left : " + PlayerStats.Money);
    }
    
    public void UpgradeTurret()
    {
        if (PlayerStats.Money < TurretBluePrint.UpgradeCost) return;
        
        Destroy(Turret); // Destroy old Turret
        
        //Build a new one
        GameObject turret = (GameObject)Instantiate(TurretBluePrint.UpgradePrefab, GetBuildPosition(), Quaternion.identity);
        Turret = turret;
        
        GameObject buildEffect = Instantiate(_buildManager.BuildEffect,GetBuildPosition(),_buildManager.BuildEffect.transform.rotation);
        Destroy(buildEffect,5f);
        
        PlayerStats.Money -= TurretBluePrint.UpgradeCost;
        
        IsUpgrade = true;
        
        Debug.Log("Turret Build! Money Left : " + PlayerStats.Money);
    }

    public void SellTurret(int amount)
    {
        PlayerStats.Money += TurretBluePrint.GetSellAmount(amount);
        
        //Sell effect
        GameObject sellEffect = Instantiate(_buildManager.SellEffect,GetBuildPosition(),_buildManager.BuildEffect.transform.rotation);
        Destroy(sellEffect,5f);
        
        //Destroy
        Destroy(Turret);
        TurretBluePrint = null;
        IsUpgrade = false;
    }
    



    public Vector3 GetBuildPosition()
    {
        return transform.position + PositionOffset;
    }

    void OnMouseExit()
    {
        _rend.material.color = _startColor;
    }
}
