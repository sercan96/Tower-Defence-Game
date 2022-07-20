using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Image BarImage;
    
    public float speed = 20f;
    public float Health = 100;
    public int Val

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

    void Die()
    {
        PlayerStats.Money += Value;
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
    
}
    