using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Turret : MonoBehaviour
{

    [Header("General")]
    
    public float Range = 10f;
    
    [Header("Use Bullets(Default)")]
    
    public GameObject BulletPrefab;
    public Transform FirePoint;
    public float FireRate = 1;
 
    
    [Header("Unity Setup Fields")]
    
    public Transform PartToRotate;
    public string EnemyTag = "Enemy";

    [Header("Use Laser")] 
    public float DamageOverTime = 100f;
    public bool UseLaser = true;
    public float SlowPct = .5f;

    [HideInInspector]public ParticleSystem LaserEffect;
    [HideInInspector] public LineRenderer LineRenderer; // referansı inspectorde gizledik.
    [HideInInspector] public GameObject LightImpact;
   
    
    private Transform _target;
    private Enemy _targetEnemy;
    private float _turnSpeed = 5f;
    private float _fireCountdown;


    void Start()
    {
        InvokeRepeating("UpdateTarget",0f,0.5f);
    }

    void Update()
    {
        if (_target == null) // Hedef obje sürekli değişiyor.
        {
            if (UseLaser)
            {
                if (LineRenderer.enabled)
                {
                    LineRenderer.enabled = false;
                    LightImpact.SetActive(false);
                    LaserEffect.Stop();
                }
            }
            return;
        }
        TargetLockOn();
        
        if (UseLaser)
        {
            Laser();
        }
        else
        {
            if (_fireCountdown <= 0)
            {
                Shoot();
                _fireCountdown = 1 / FireRate;
            }
            _fireCountdown -= Time.deltaTime;
        }
    }

    private void Laser()
    {
        _targetEnemy.TakeDamage(DamageOverTime * Time.deltaTime);
        #region Second Way
        // _target.GetComponent<Enemy>().TakeDamage(DamageOverTime * Time.deltaTime);
        #endregion
        // Update te çalıştığı için lazer her değdiğinde azar azar canını alactacaktır
        _targetEnemy.Slow(SlowPct); // Lazer değdiği sürece hızını yavaşlat.

        if (!LineRenderer.enabled)
        {
            LineRenderer.enabled = true;
            LightImpact.SetActive(true);
            LaserEffect.Play();
        }
        LineRenderer.SetPosition(0,FirePoint.position); // lazerin çıkacağı ilk pozisyon
        LineRenderer.SetPosition(1,_target.position); // lazerin çıkacağı ikinci pozisyon
        
        Vector3 dir = FirePoint.position - _target.position;
        LaserEffect.transform.position = _target.position;
        LaserEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

    private void Shoot()
    {
        GameObject bulletGo = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        if(bullet != null)
            bullet.Seek(_target);
    }

    #region Objeleri Yakalama ve Rotasyon Verme
    void TargetLockOn() // Rotasyon işlemi
    {
        Vector3 dir = _target.position - transform.position;  // Hedefe doğru rotasyon veriyoruz.
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        // Vector3 rotation = lookRotation.eulerAngles; // rotasyonda yumuşak geçiş için
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation,lookRotation,Time.deltaTime * _turnSpeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f,rotation.y,0f);
    }

    void UpdateTarget() // Gelen objeleri yakalıyoruz.
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
        GameObject nearestObj = null;  // Forech 'te tanımlanan değerlere döngünün dışından ulaşılamadığı için bu değere eşitledik.
        float shortestDistance = Mathf.Infinity;
        foreach (GameObject enemy in enemies) // Enemies dizisinin içerisinde GameObject tutuyor.
        {
            float distanceToEnemy =  Vector3.Distance(transform.position ,enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy; // mesafeyi eşitledik.
                nearestObj = enemy; // objeyi eşitledik
            }
        }
        if (nearestObj !=null && shortestDistance <= Range)
        {
            _target = nearestObj.transform;
            _targetEnemy = _target.GetComponent<Enemy>();
            // Update te GEtComponent yapmamızın sebebi sürekli farklı bir objeyi yakalamak istememiz.
        }
        else
        {
            _target = null;
        }
    }
    
    #endregion
    
    void OnDrawGizmosSelected() // Selected => Objeye tıklandığında tetiklenir.
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
