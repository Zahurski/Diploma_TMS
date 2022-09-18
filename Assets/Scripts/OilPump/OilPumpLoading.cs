using GasStation.Config;
using OilPump.Config;
using UnityEngine;
using UnityEngine.UI;

namespace OilPump
{
    public class OilPumpLoading : MonoBehaviour
    {
        [SerializeField] private Image loadingImage;
        [SerializeField] OilPumpConfig config;
        [SerializeField] private Canvas canvas;

        public bool IsActive { get; set; }

        private void Awake()
        {
            canvas.enabled = true;
            loadingImage.fillAmount = 0;
        }

        private void Update()
        {
            loadingImage.fillAmount += 1f / config.PumpingTime * Time.deltaTime;
        }

        public void FillAmountZero()
        {
            loadingImage.fillAmount = 0;
        }
    }
}
