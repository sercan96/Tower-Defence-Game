using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Image BarImage;

    public float StartSpeed = 10;
    [HideInInspector] public float speed;
    public float Health = 100;
    private float _startHealth;
    public int Value = 50;

    void Start()
    {
        speed = StartSpeed;
        _startHealth = Health;
    }
    public void TakeDamage(float amount)
    {
        Health -= amount;
        BarImage.fillAmount = Health / _startHealth;  
        if (Health <= 0)
        {
            Die();
            Debug.Log("Game Over!!");
        }
    }

    public void Slow(float pct) // percantage = yüzde
    {
        speed = StartSpeed * (1 - pct);
    }
    void Die()
    {
        PlayerStats.Money += Value;
        PlayerStats.Lives--;
        #region Statik Tanımlama
        //Direk scriptin içindeki değeri azalttık.
        //Bu scripte bağlı olan obje prefab olduğu için Wave Spawner'ın referansını yakalayamayız.
        //O sebeple static olarak yakaladık. Yani o değeri scripte sabitledik. Örneği aşlınmış olsa bile hepsinde değer değişecektir.
        #endregion
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
       
    }
    
}
    