using UnityEngine;

public class GunTower : Tower
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform projectileFirePoint;

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void FireAt(Enemy target)
    {
        if (bulletPrefab != null)
        {
            GameObject projectileInstance = Instantiate(bulletPrefab, projectileFirePoint.position, Quaternion.identity);
            projectileInstance.GetComponent<Projectile>().SetTarget(target.transform);
        }
    }

    protected override Enemy GetTargetEnemy()
    {
        ClearDestroyedEnemies();

        Enemy closestEnemy = null;
        float closestDistance = float.MaxValue;

        foreach (Enemy enemy in enemiesInRange)
        {

            if (enemy != null)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    closestEnemy = enemy;
                }
            }
        }

        return closestEnemy;
    }
}
