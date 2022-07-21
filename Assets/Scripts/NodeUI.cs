using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public GameObject Ui;
    
    private Node _target;

    public void SetTarget(Node target)
    {
         _target = target;
         transform.position = _target.GetBuildPosition();
         
         Ui.SetActive(true);
    }

    public void Hide()
    {
        Ui.SetActive(false);
    }
}
