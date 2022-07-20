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
    public int Value = 50;

    void Start()
    {
        speed = StartSpeed;
    }
    public void TakeDamage(float amount)
    {
        Health -= amount;
        BarImage.fillAmount -= amount / 100f; 
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
        Destroy(gameObject);
    }
    
}
    