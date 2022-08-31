using System;
using System.Collections;
using System.Globalization;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using GasStation.Config;

namespace GasStation
{
    public class MoneyIncreaseText : MonoBehaviour
    {
        private CarMoveble _carMoveble;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private GasStationConfig config;
        private readonly Vector3 _targetPositionText = new(0, 4, 0);

        public bool Fuel { get; set; }
        private void Update()
        {
            if (Fuel)
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
            if (text.transform.position == _targetPositionText) Fuel = false;
            text.transform.position = Vector3.MoveTowards(text.transform.position, _targetPositionText, 2 * Time.deltaTime);
        }
    }
}