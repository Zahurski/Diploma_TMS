using System.Globalization;
using UnityEngine;
using TMPro;

public class UIGameScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;

    private void Start()
    {
        OnMoneyValueChanged(GameManager.Instance.Money);
        GameManager.Instance.OnMoneyValueChange += OnMoneyValueChanged;
    }

    private void OnMoneyValueChanged(float value)
    {
        moneyText.text = value.ToString(CultureInfo.InvariantCulture);
    }
}
