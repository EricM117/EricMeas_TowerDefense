using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public event Action<int, int> OnHealthChanged;

    [SerializeField] private int maxHealth = 20;
    public int currentHealth;
    public GameObject gameOverMenuUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        gameOverMenuUI.SetActive(false);
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

        if (currentHealth <= 0) 
        {
            GameOver();
        }

        Debug.Log($"Current Health: {currentHealth}");
    }

    private void GameOver()
    {
        if (currentHealth <= 0)
        {
            Time.timeScale = 0f;
            gameOverMenuUI.SetActive(true);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
