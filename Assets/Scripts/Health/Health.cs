using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public event Action<int, int> OnHealthChanged;

    [SerializeField] private int maxHealth = 20;
    private int currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public bool IsDead()
    {
        return currentHealth > 0;
    }

    public void TakeDamage(int damageAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth = Mathf.Max(currentHealth - damageAmount, 0);
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
        }

        Debug.Log($"Current Health: {currentHealth}");
    }
}
