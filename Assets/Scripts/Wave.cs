using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// [System.Serializable]
[CreateAssetMenu(fileName = "New wave", menuName = "Enemy Type")]
public class Wave : ScriptableObject
{
    public GameObject Enemy;
    public int Count;
    public int Rate;

}
