using System;
using System.Collections;
using System.Globalization;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using GasStation.Config;
using OilPump.Config;

namespace OilPump
{
    public class OilPumpMoneyIncreaseText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private OilPumpConfig config;
        private readonly Vector3 _targetPositionText = new(0, 4, 0);

        public bool Pump { get; set; }
        private void Update()
        {
            if (Pump)
            {
                ShowFuelText();
                text.text = "+" + ((float) Math.Round(config.Cost, 0)).ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                text.text = " ";
                text.transform.position = new Vector3(0, 3, 0);
            }
        }

        private void ShowFuelText()
        {
            if (text.transform.position == _targetPositionText) Pump = false;
            text.transform.position = Vector3.MoveTowards(text.transform.position, _targetPositionText, 2 * Time.deltaTime);
        }
    }
}