using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject Ui;
    
    private Node _target;
    public Text UpgradeCost;
    public Text SellCost;
    public Button UpgradeButton;

    public void SetTarget(Node target)
    {
         _target = target;
         transform.position = _target.GetBuildPosition();
                  
         Ui.SetActive(true);
         
         if (!_target.IsUpgrade) // Upgrade edilmemişse
         {
             UpgradeCost.text = "$" + _target.TurretBluePrint.UpgradeCost;
             SellCost.text = "$" + _target.TurretBluePrint.GetSellAmount(0);
             UpgradeButton.interactable = true;
         }
         else
         {
             UpgradeCost.text = "DONE";
             UpgradeButton.interactable = false;
             
             // For Sell
             SellCost.text = "$" + _target.TurretBluePrint.GetSellAmount(30);
         }
    }

    public void Hide()
    {
        Ui.SetActive(false);
    }

    public void Upgrade() // Buton ile çalışacak.
    {
        _target.UpgradeTurret();
        BuildManager.Instance.DeSelectNode();
    }

    public void Sell()
    {
        if (!_target.IsUpgrade)
        {
            _target.SellTurret(0);
            BuildManager.Instance.DeSelectNode();
        }
        else
        {
            _target.SellTurret(30);
            BuildManager.Instance.DeSelectNode();
        }
  
    }
}
