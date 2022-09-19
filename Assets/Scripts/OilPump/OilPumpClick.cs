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

        private void OnMouseDown()
        {
            _uiManager.ShowOilPumpUpgradeMenu();
        }
    }
}