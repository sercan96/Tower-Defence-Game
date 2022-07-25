using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelected : MonoBehaviour
{
    public SceneFader SceneFader;

    public void Select(string levelSelect)
    {
        SceneFader.FadeTo(levelSelect);
    }
}
