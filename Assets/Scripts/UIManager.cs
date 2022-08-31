using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _gasStationUpgradeMenu;
    
    private GameObject _currentScreen;
    
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

    public void Close()
    {
        _currentScreen.SetActive(false);
        _currentScreen = _gameScreen;
        _currentScreen.SetActive(true);
    }
}