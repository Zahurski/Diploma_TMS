using UnityEngine;

namespace GasStation.Config
{
    [CreateAssetMenu(fileName = "GasStationConfig", menuName = "Configs/GasStationConfig", order = 0)]
    public class GasStationConfig : ScriptableObject
    {
        [SerializeField] private float startUpgradeCost = 0f;
        [SerializeField] private float costMultiplier = 1.7f;
        [SerializeField] private float cost = 2f;
        [SerializeField] private float carSpeed = 8f;
        [SerializeField] private float spawnDelay = 1f;
        [SerializeField] private float fuelingTime = 1f;

        public float StartUpgradeCost => startUpgradeCost;
        public float CostMultiplier => costMultiplier;
        public float Cost => cost;
        public float CarSpeed => carSpeed;
        public float SpawnDelay => spawnDelay;
        public float FuelingTime => fuelingTime;
    }
}