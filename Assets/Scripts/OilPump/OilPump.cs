using System;
using System.Collections;
using OilPump.Config;
using UnityEngine;

namespace OilPump
{
    public class OilPump : MonoBehaviour
    {
        [SerializeField] private OilPumpConfig config;
        private bool _complete;
        private void Awake()
        {
            
        }

        private void Start()
        {
            //StartCoroutine(Pumping());
        }

        private IEnumerator Pumping()
        {
            yield return new WaitForSeconds(config.PumpingTime);
            GameManager.Instance.Money += config.Cost;
        }
    }
}