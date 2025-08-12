using UnityEngine;

public class CannonTower : Tower
{
    [SerializeField] private GameObject cannonballPrefab;
    [SerializeField] private Transform projectileFirePoint;

    protected override void Update()
    {
        base.Update();
    }

    protected override void FireAt(Enemy target)
    {
        // Add Cannon Tower firing code
        if (cannonballPrefab != null)
        {
            GameObject projectileInstance = Instantiate(cannonballPrefab, projectileFirePoint.position, Quaternion.identity);
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
