using UnityEngine;

namespace OilPump
{
    public class OilPumpClick : MonoBehaviour
    {
        private UIManager _uiManager;

        private void Start()
        {
            _uiManager = FindObjectOfType<UIManager>();
        }

        private void OnMouseUp()
        {
            if(_uiManager.CurrentScreen != _uiManager.GameScreen) return;
            _uiManager.ShowOilPumpUpgradeMenu();
        }
    }
}