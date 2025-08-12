using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public event Action<int, int> OnHealthChanged;

    private NavMeshAgent agent;
    private Animator animator;
    [SerializeField] private Transform endPoint;
    [SerializeField] private string animatorParam_IsWalking;
    [SerializeField] private int damage;
    [SerializeField] private int maxHealth;
    [SerializeField] private int moneyAmountDrop;
    [SerializeField] private float speed;
    private int currentHealth;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator.SetBool(animatorParam_IsWalking, true);
        currentHealth = maxHealth;
        agent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (agent.hasPath || agent.pathStatus == NavMeshPathStatus.PathComplete)
            {
                ReachedEnd();
            }
        }
    }

    public void Initialize(Transform inputEndPoint)
    {
        endPoint = inputEndPoint;
        agent.SetDestination(endPoint.position);
    }

    public void TakeDamage(int damageAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth = Mathf.Max(currentHealth - damageAmount, 0);
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
        }

        if (currentHealth <= 0)
        {
            CurrencyManager.instance.IncreaseCurrency(moneyAmountDrop);
            Destroy(gameObject);
        }

        Debug.Log($"Enemy Current Health: {currentHealth}");
    }


    private void ReachedEnd()
    {
        animator.SetBool(animatorParam_IsWalking, false);
        GameManager.instance.playerHealth.TakeDamage(damage);
        Destroy(gameObject);
    }
}
