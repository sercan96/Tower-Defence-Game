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

    void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
        _buildManager= BuildManager.Instance;

        // rend = GetComponent<Renderer>();
        //NodeMaterial = transform.parent.gameObject.GetComponent<MeshRenderer>().material;
    }

    void OnMouseDown() // Mouse ile tıklandığında
    {
        //if (_buildManager.GetToTurretBuild() == null) return; // içinde obje yoksa seçim yapamasın
        if (!_buildManager.CanBuild) return; // Boşsa
        if (Turret != null) // içinde obje varsa aynı yere bir tane daha eklenmesin.
        {
            Debug.Log("Cant build there");
            return;
        }
        // Create Turret Build
        // GameObject turretToBuild = BuildManager.Instance.GetToTurretBuild();
        // Turret = Instantiate(turretToBuild, transform.position + PositionOffset, transform.rotation);
        _buildManager.BuildTurretOn(this); // Bu scripte bağlı objeyi ver.
    }
    void OnMouseEnter() // Mouse ile üzerine gelindiğinde
    {
        if (!_buildManager.CanBuild) return; // Renginide değiştiremesin
        if (_buildManager.HasMoney)
            _rend.material.color = HoverColor;
        else
            _rend.material.color = NotEnoughMoneyColor;
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
