using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _gasStationUpgradeMenu;
    [SerializeField] private GameObject _oilPumpUpgradeMenu;
    
    private GameObject _currentScreen;

    public GameObject CurrentScreen => _currentScreen;
    public GameObject GameScreen => _gameScreen;

    private void Awake()
    {
        _currentScreen = _gameScreen;
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