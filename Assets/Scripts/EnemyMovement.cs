using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform _target;
    private int _waypointIndex;
    private Enemy _enemy;
    
    
    void Start()
    {
        _target = Waypoints.Points[0];
        _enemy = gameObject.GetComponent<Enemy>();
    }
    
    void Update()
    {
        #region Command
        // normalized = Noktalar arası geçişlerin daha smooth olmasını sağlar.
        // Scriptin point dizisine direk erişim sağladık.
        #endregion
        
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * _enemy.speed *  Time.deltaTime, Space.World);
        if (Vector3.Distance(_target.position, transform.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        _enemy.speed = _enemy.StartSpeed; // Update ile sürekli değeri 20 yapsın. Çünkü laser değdiğinde azaltıcaz.
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
}
