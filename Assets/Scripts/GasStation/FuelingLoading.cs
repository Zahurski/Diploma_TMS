using System;
using GasStation.Config;
using UnityEngine;
using UnityEngine.UI;

public class FuelingLoading : MonoBehaviour
{
    [SerializeField] private Image loadingImage;
    [SerializeField] GasStationConfig config;
    private Canvas _canvas;
    private bool _deactivateTimer;

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
        loadingImage.fillAmount += 1f / config.FuelingTime * Time.deltaTime;
    }
}
