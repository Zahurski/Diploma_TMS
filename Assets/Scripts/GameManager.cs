using System;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private const string LAST_PLAYED_TIME = "LastPlayedTimea";
    private const string MONEY = "Moneya";
    private const string DIAMOND = "Diamonda";
    public static GameManager Instance;

    private UIManager _uiManager;
    
    private float _money = 0;
    private float _diamond = 0;
    public Action<float> OnMoneyValueChange = null;
    public Action<float> OnDiamondValueChange = null;
    
    public static string LastPlayedTime => LAST_PLAYED_TIME;
    
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
        
        Load();
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

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat(MONEY, _money);
        PlayerPrefs.SetFloat(DIAMOND, _diamond);
        PlayerPrefs.SetString(LAST_PLAYED_TIME, DateTime.UtcNow.ToString(CultureInfo.CurrentCulture));
    }

    private void Load()
    {
        if (!PlayerPrefs.HasKey(MONEY))
        {
            PlayerPrefs.SetFloat(MONEY, 0);
            _uiManager.ShowGameScreen();
        }
        else
        {
            _uiManager.Initialize();
            _money = PlayerPrefs.GetFloat(MONEY);
        }
        
        if (!PlayerPrefs.HasKey(DIAMOND))
        {
            PlayerPrefs.SetFloat(DIAMOND, 0);
        }
        else
        {
            _diamond = PlayerPrefs.GetFloat(DIAMOND);
        }
    }
}
