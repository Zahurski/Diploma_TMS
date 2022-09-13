using System;
using GasStation.Config;
using TMPro;
using UnityEngine;

namespace GasStation
{
    public class UpgradableGasStation : MonoBehaviour
    {
        [SerializeField] private GasStationButtonController button;
        [SerializeField] private GasStationConfig config;
        private float _currentCost = 0f;
        private float _currentFuelingTime;

        public float CurrentCost => _currentCost;

        private void Start()
        {
            if (_currentCost < config.StartUpgradeCost)
            {
                _currentCost = config.StartUpgradeCost;
            }
            
            button.RefreshGasStationInfo();
        }

        public void UpgradeCost()
        {
            if (GameManager.Instance.Money >= _currentCost)
            {
                //TODO: связать цену с уровнем 
                config.Level++;
                config.Cost++;
                GameManager.Instance.Money -= _currentCost;
                button.RefreshGasStationInfo();
                var newCost = _currentCost + _currentCost * config.CostMultiplier;
                _currentCost = newCost;
            }
        }

        public void UpgradeFueling()
        {
            //TODO: добавить интеректибл кнопки
            if(config.LevelFueling == 50) return;

            if (GameManager.Instance.Money >= config.CostFueling)
            {
                config.LevelFueling++;
                config.FuelingTime -= config.DecreaseFueling;
                GameManager.Instance.Money -= config.CostFueling;
                config.CostFueling *= 1.8f;
                button.RefreshGasStationInfo();
            }
        }

        public void UpgradeSpawnDelay()
        {
            if(config.LevelSpawnDelay == 50) return;
            
            if (GameManager.Instance.Money >= config.CostSpawnDelay)
            {
                config.LevelSpawnDelay++;
                config.SpawnDelay -= config.DecreaseSpawnDelay;
                GameManager.Instance.Money -= config.CostSpawnDelay;
                config.CostSpawnDelay *= 2f;
                button.RefreshGasStationInfo();
            }
        }
    }
}