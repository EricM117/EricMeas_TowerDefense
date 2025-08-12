using System;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance;
    public event Action<int> CurrencyChanged;

    [SerializeField] private int startingCurrency;
    private int currentCurrency;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
            return;
        }

        currentCurrency = startingCurrency;
    }

    public void IncreaseCurrency(int currencyAddition)
    {
        currentCurrency += currencyAddition;
        Debug.Log($"Current money amount: {currentCurrency}");
        CurrencyChanged?.Invoke(currentCurrency);
    }

    public bool SpendCurrency(int currencyNeededForTower)
    {
        if (currentCurrency >= currencyNeededForTower)
        {
            currentCurrency -= currencyNeededForTower;
            Debug.Log($"Purchased for {currencyNeededForTower}. Remaining money amount: {currentCurrency}");
            CurrencyChanged?.Invoke(currentCurrency);
            return true;
        }

        else
        {
            Debug.Log("Not enough money!");
            return false;
        }
    }

    public int GetCurrency()
    {
        return currentCurrency;
    }
}
