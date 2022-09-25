using System;
using System.Globalization;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private UIManager _uiManager;
    
    private float _money = 0;
    private float _diamond = 0;
    public Action<float> OnMoneyValueChange = null;
    public Action<float> OnDiamondValueChange = null;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        _uiManager.Initialize();
    }

    public float Money
    {
        get => _money;

        set
        {
            if (value >= 0)
            {
                _money = value;
                _money = (float) Math.Round(_money, 0);
                OnMoneyValueChange?.Invoke(_money);
            }
        }
    }
    
    public float Diamond
    {
        get => _diamond;

        set
        {
            if (value >= 0)
            {
                _diamond = value;
                _diamond = (float) Math.Round(_diamond, 0);
                OnDiamondValueChange?.Invoke(_diamond);
            }
        }
    }
}
