using System;
using System.Collections;
using Adv;
using OilPump.Config;
using UnityEngine;

namespace OilPump
{
    public class OilPump : MonoBehaviour
    {
        [SerializeField] private OilPumpConfig config;
        private bool _complete;
        private AdvController _adv;
        private OilPumpMoneyIncreaseText _oilPumpMoneyIncreaseText;
        private OilPumpLoading _oilPumpLoading;
        private void Awake()
        {
            _adv = FindObjectOfType<AdvController>();
            _oilPumpMoneyIncreaseText = FindObjectOfType<OilPumpMoneyIncreaseText>();
            _oilPumpLoading = FindObjectOfType<OilPumpLoading>();
        }

        private void Start()
        {
            StartCoroutine(Pumping());
        }

        private IEnumerator Pumping()
        {
            while (true)
            {
                //_oilPumpLoading.IsActive = true;
                _oilPumpLoading.FillAmountZero();
                yield return new WaitForSeconds(config.PumpingTime);
                _oilPumpMoneyIncreaseText.Pump = true;
                GameManager.Instance.Money += config.Cost * _adv.AdvMultiplier;
                //_oilPumpLoading.IsActive = false;
            }
        }
    }
}