using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
{
    public Wave[] Waves;
    
    public Transform EnemyPrefab;
    public Transform EnemyPos;
    public Transform EnemySpawnerParentObj;
    //public Material EnemyMat;
    public Text WaveCountDownText;
    public float CountDown = 2;
    public float TimeBetweenWaves = 5;
    public int WaveIndex;
    public static int EnemiesAlive = 0; // Bu değer tüm heryerde aynı kalsın.


    void Update()
    {
        if (EnemiesAlive > 0) return;
        if (CountDown <= 0)
        {
            StartCoroutine(SpawnWave(0.5f));
            CountDown = TimeBetweenWaves;
            return;
        }
        
        CountDown -= Time.deltaTime;
        // WaveCountDownText.text = Mathf.Round(CountDown).ToString(CultureInfo.InvariantCulture);
        CountDown = Mathf.Clamp(CountDown, 0f, Mathf.Infinity);
        WaveCountDownText.text = $"{CountDown:00.00}";
        
        //Mathf.Round => CountDown değerini int olarak işleyebilmemizi sağladı.
    }

    IEnumerator SpawnWave(float waitTime) // Enemy Spawn System
    {
        PlayerStats.Rounds++;

        Wave wave = Waves[WaveIndex];
        
        for (int i = 0; i < wave.Count; i++) // wave bir dizi değil, scriptiniçerisindeki count değişkenini aldık. Waves[i].Count aynı.
        {
            SpawnEnemy(wave.Enemy);
            yield return new WaitForSeconds(1f / wave.Rate); // Aynı anda oluşmamaları için.
        }
        WaveIndex++;

        if (WaveIndex == Waves.Length)
        {
            Debug.Log("Level WON");
            this.enabled = false;
        }

    }
    
    void SpawnEnemy(GameObject enemyPrefab)
    {
        //EnemyMat.color = Random.ColorHSV(0, 1, 0.5f, 1, 1, 1) + Color.gray;
        Instantiate(enemyPrefab,EnemyPos.position,EnemyPos.rotation,EnemySpawnerParentObj);
        PlayerStats.IncreaseLıves();
        EnemiesAlive++;

    }

}
