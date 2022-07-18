using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _target;
    public float Speed;
    public int DamageShot;
    // public GameObject ImpactEffect;
    public GameObject[] ExplosionParticles;
    public bool IsMissileBullet;

    
    public void Seek(Transform target) // Hedef objeyi buradan yakalıyoruz.
    {
        _target = target;
    }

    void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.position - transform.position;
        float distanceThisFrame = Speed * Time.deltaTime ;  // 70 * 250 *  1 / 250 = 70 
      
        if (dir.magnitude <= distanceThisFrame) //dir.magnitude => (x^2 + y^2 + z^2) 
        {
            Damage(_target);
            return; 
        }
        transform.Translate(dir.normalized * Time.deltaTime * Speed,Space.World); 
        // Space.World merminin temiz gitmesini sağladı.
        transform.LookAt(_target);
    }

    private void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(DamageShot);
        }
        if (e.Health <= 0)
        {
            PlayParticleRandom();
        }
        DestroyGameObject();
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    private void PlayParticleRandom()
    {
        int createRandomNumber = Random.Range(0, 4);
        if (!IsMissileBullet)
        {
            Instantiate(ExplosionParticles[0].gameObject, transform.position, transform.rotation);
            // GameObject effectIns = Instantiate(ImpactEffect, transform.position, transform.rotation);
            DestroyImmediate(ExplosionParticles[0].gameObject);
            return;
        }
        Instantiate(ExplosionParticles[createRandomNumber].gameObject, transform.position, transform.rotation);
    }

    #region HitTargetSecondWay
    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.CompareTag("Enemy"))
    //     {
    //         Destroy(gameObject);
    //     }
    // }
    

    #endregion
    
}
