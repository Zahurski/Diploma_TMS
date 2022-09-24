using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _gasStationUpgradeMenu;
    [SerializeField] private GameObject _oilPumpUpgradeMenu;
    [SerializeField] private GameObject _firtsEntry;
    [SerializeField] private GameObject _settings;
    
    private GameObject _currentScreen;

    public GameObject CurrentScreen => _currentScreen;
    public GameObject GameScreen => _gameScreen;

    private void Awake()
    {
        _currentScreen = _gameScreen;
    }

    public void Initialize()
    {
        ShowFirstEntryMenu();
    }

    public void ShowFirstEntryMenu()
    {
        _currentScreen.SetActive(false);
        _firtsEntry.SetActive(true);
        _currentScreen = _firtsEntry;
    }
    
    public void ShowSettingsMenu()
    {
        _currentScreen.SetActive(false);
        _settings.SetActive(true);
        _currentScreen = _settings;
    }

    public void ShowGasStationUpgradeMenu()
    {
        _currentScreen.SetActive(false);
        _gasStationUpgradeMenu.SetActive(true);
        _currentScreen = _gasStationUpgradeMenu;
    }

    public void ShowOilPumpUpgradeMenu()
    {
        _currentScreen.SetActive(false);
        _oilPumpUpgradeMenu.SetActive(true);
        _currentScreen = _oilPumpUpgradeMenu;
    }

    public void Close()
    {
        _currentScreen.SetActive(false);
        _currentScreen = _gameScreen;
        _currentScreen.SetActive(true);
    }
}