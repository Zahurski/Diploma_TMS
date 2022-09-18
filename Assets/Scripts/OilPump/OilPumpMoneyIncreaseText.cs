using System;
using System.Collections;
using System.Globalization;
using Adv;
using Components;
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
        private Vector3 _targetPositionText;
        private OilPumpComponent _oilPump;
        private AdvController _adv;

        public bool Pump { get; set; }

        private void Awake()
        {
            _oilPump = FindObjectOfType<OilPumpComponent>();
            _adv = FindObjectOfType<AdvController>();
        }

        private void Start()
        {
            _targetPositionText = new Vector3(0, 4, _oilPump.transform.position.z);
        }

        private void Update()
        {
            if (Pump)
            {
                ShowFuelText();
                text.text = "+" + ((float) Math.Round(config.Cost * _adv.AdvMultiplier, 0)).ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                text.text = " ";
                text.transform.position = new Vector3(0, 3, _oilPump.transform.position.z);
            }
        }

        private void ShowFuelText()
        {
            if (text.transform.position == _targetPositionText) Pump = false;
            text.transform.position = Vector3.MoveTowards(text.transform.position, _targetPositionText, 2 * Time.deltaTime);
        }
    }
}