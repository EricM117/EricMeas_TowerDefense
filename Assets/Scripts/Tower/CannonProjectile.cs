using System;
using System.Collections;
using UnityEngine;

public class CannonProjectile : Projectile
{
    [SerializeField] private GameObject explosionEffectPrefab;
    private float cannonProjectileSpeed = 10f;
    private float explosionRadius = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            transform.position += direction * cannonProjectileSpeed * Time.deltaTime;
            transform.forward = direction;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.transform == target)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                CannonExplode();
            }
        }
    }

    private void CannonExplode()
    {
        Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);

        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyEnemies in collidersToDestroy)        
        {
            Enemy enemy = nearbyEnemies.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        Destroy(gameObject);
        Debug.Log("BOOM!");
    }
}
