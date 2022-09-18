using System;
using GasStation.Config;
using UnityEngine;
using UnityEngine.UI;

public class FuelingLoading : MonoBehaviour
{
    [SerializeField] private Image loadingImage;
    [SerializeField] GasStationConfig config;
    [SerializeField] private Canvas canvas;
    private bool _deactivateTimer;

    public bool IsActive { get; set; }

    private void Awake()
    {
        loadingImage.fillAmount = 0;
    }

    private void Update()
    {
        if (!IsActive)
        {
            canvas.enabled = false;
            loadingImage.fillAmount = 0;
            return;
        }
        canvas.enabled = true;
        loadingImage.fillAmount += 1f / config.FuelingTime * Time.deltaTime;
    }
}
