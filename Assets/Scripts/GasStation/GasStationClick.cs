using System;
using UnityEngine;

namespace GasStation
{
    public class GasStationClick : MonoBehaviour
    {
        private UIManager _uiManager;

        private void Start()
        {
            _uiManager = FindObjectOfType<UIManager>();
        }

        private void OnMouseUp()
        {
            if(_uiManager.CurrentScreen != _uiManager.GameScreen) return;
            _uiManager.ShowGasStationUpgradeMenu();
        }
    }
}