using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected int damage = 10;
    [SerializeField] private float lifetime = 3f;
    protected float speed = 20f;
    protected Transform target;

    protected virtual void Start()
    {
        Destroy(gameObject, lifetime);
    }

    protected abstract void Update();

    public void SetTarget(Transform inputTarget)
    {
        target = inputTarget;
    }

    protected abstract void OnTriggerEnter(Collider other);
}
