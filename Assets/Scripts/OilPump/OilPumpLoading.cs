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
        private Canvas _canvas;

        public bool IsActive { get; set; }

        private void Awake()
        {
            _canvas = gameObject.GetComponent<Canvas>();
            loadingImage.fillAmount = 0;
        }

        private void Update()
        {
            if (!IsActive)
            {
                _canvas.enabled = false;
                loadingImage.fillAmount = 0;
                return;
            }
            _canvas.enabled = true;
            loadingImage.fillAmount += 1f / config.PumpingTime * Time.deltaTime;
        }
    }
}
