using System;
using System.Collections;
using System.Collections.Generic;
using GasStation.Config;
using OilPump.Config;
using UnityEngine;

public class FirstLoad : MonoBehaviour
{
    [SerializeField] private GasStationConfig gasStation;
    [SerializeField] private OilPumpConfig oilPump;
    private float _moneySum;

    private void Start()
    {
        _moneySum = gasStation.Cost + oilPump.Cost;
    }
}
