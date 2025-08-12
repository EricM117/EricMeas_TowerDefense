using UnityEngine;
using TMPro;

public class CurrencyText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currencyText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateCurrencyText(CurrencyManager.instance.GetCurrency());
    }

    private void UpdateCurrencyText(int amount)
    {
        currencyText.text = $"$ {amount}";
    }
}
