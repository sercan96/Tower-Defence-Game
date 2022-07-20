using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
{
    public Transform EnemyPrefab;
    public Transform EnemyPos;
    public Transform EnemySpawnerParentObj;
    public Material EnemyMat;
    public Text WaveCountDownText;
    public float CountDown = 2;
    public float TimeBetweenWaves = 10;
    public int WaveNumber = 1;


    void Update()
    {
        if (CountDown <= 0)
        {
            StartCoroutine(SpawnWave(0.5f));
            CountDown = TimeBetweenWaves;
        }
        CountDown -= Time.deltaTime;
        // WaveCountDownText.text = Mathf.Round(CountDown).ToString(CultureInfo.InvariantCulture);
        CountDown = Mathf.Clamp(CountDown, 0f, Mathf.Infinity);
        WaveCountDownText.text = $"{CountDown:00.00}";
        
        //Mathf.Round => CountDown değerini int olarak işleyebilmemizi sağladı.
    }

    IEnumerator SpawnWave(float waitTime)
    {
        for (int i = 0; i < WaveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(waitTime); // Aynı anda oluşmamaları için.
        }
        WaveNumber++;
    }
    
    void SpawnEnemy()
    {
        EnemyMat.color = Random.ColorHSV(0, 1, 0.5f, 1, 1, 1) + Color.gray;
        Instantiate(EnemyPrefab,EnemyPos.position,EnemyPos.rotation,EnemySpawnerParentObj);
        PlayerStats.Lives++;
    }
    
}
