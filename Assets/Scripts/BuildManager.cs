using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;
    
    // public GameObject StandartTurretPrefab;
    // public GameObject PurchaseMissileLouncher;
    
    public GameObject BuildEffect;
    public GameObject SellEffect;
    public NodeUI NodeUı;
    private Node _selectedNode;

    
    private TurretBluePrint _turretToBuild;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Build Manager in scene");
            return;
        }
        Instance = this;
    }
    
    
    #region ChooseTurret
    // Prefab objeyi buradan yakalıyoruz.
    // GetToTurretBuild methodu null değilse yani içinde obje yoksa mouse ile seçim yapılmasına izin verilmeyecek.
    #endregion
    // public TurretBluePrint GetToTurretBuild() 
    // {
    //     return _turretToBuild; 
    // }

    public bool CanBuild {get {return _turretToBuild !=null; }} // herhamgi bir turret seçilmişse
    public bool HasMoney {get {return PlayerStats.Money >= _turretToBuild.Cost; }}

    public void SelectTurretToBuild(TurretBluePrint turret) // istediğimiz turret objesini buraya ekliyeceğiz.
    {
        _turretToBuild = turret; // Aldığımız turret objesini bu scriptin referansına kaydediyoruz.
        DeSelectNode(); // Naşka bir Turret tıklandığında gizle
    }

    public TurretBluePrint GetTurretToBuild() // Yakaladığı objeyi döndürür.
    {
        return _turretToBuild;
    }

    public void SelectNode(Node node)
    {
        if (_selectedNode == node) // iki defa aynı node ' a tıklanmışsa da üstündeki upgrade gizlensin.
        {
            DeSelectNode();
            return;
        }
        _selectedNode = node;
        // NodeUI.transform.position = node.GetBuildPosition();
        NodeUı.SetTarget(node); // Tüm Node'lere eklemek yerine referansı buradan ekliyoruz.
    }

    public void DeSelectNode()
    {
        _selectedNode = null;
        NodeUı.Hide();  // Naşka bir işlem yapıldığında gizle
    }
}
