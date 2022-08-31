using UnityEngine;

namespace OilPump.Config
{
    [CreateAssetMenu(fileName = "OilPumpConfig", menuName = "Configs/OilPumpConfig", order = 0)]
    public class OilPumpConfig : ScriptableObject
    {
        [SerializeField] private float startUpgradeCost = 0f;
        [SerializeField] private float costMultiplier = 1.7f;
        [SerializeField] private float cost = 2f;
        [SerializeField] private float pumpingTime = 1f;

        public float StartUpgradeCost => startUpgradeCost;
        public float CostMultiplier => costMultiplier;
        public float Cost => cost;
        public float PumpingTime => pumpingTime;
    }
}