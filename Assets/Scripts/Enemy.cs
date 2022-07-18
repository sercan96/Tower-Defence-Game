using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 20f;
    public int Health = 100;
    public int Value = 50;
    
    private Transform _target;
    private int _waypointIndex;

    public Image BarImage;
    
    
    void Start()
    {
        _target = Waypoints.Points[0];
    }
    
    void Update()
    {
        #region Command
        // normalized = Noktalar arası geçişlerin daha smooth olmasını sağlar.
        // Scriptin point dizisine direk erişim sağladık.
        #endregion
        
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized* speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(_target.position, transform.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    #region Command2
    // Static olan referanslara diğer scriptlerden direk erişilebildiği için o scriptin referansını almamıza gerek kalmaz.
    // Çünkü tek bir yerden tanımlanmıştır. Singleton yapısı ile benzerdir. Singleton da script tek bir yerden örneği alınarak ulaşılabiliyorken;
    // staticte scriptin içerisindeki sadece bir referansı direk alabiliyoruz ve bu referans tüm objelerde tanımlanmış oluyor.
    #endregion
    
    void GetNextWaypoint()
    {
        if (_waypointIndex >= Waypoints.Points.Length - 1)
        {
            EndPath();
            return;
        }
        _waypointIndex++;
        _target = Waypoints.Points[_waypointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject); // end noktası
    }
    
    public void TakeDamage(int amount)
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
    