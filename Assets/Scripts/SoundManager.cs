using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClipClose;
    [SerializeField] private AudioClip audioClipMoney;

    private UIManager _uiManager;

    private void Awake()
    {
        _uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 30);
        }
        else
        {
            Load();
        }

        _uiManager.CloseMenu += CloseSound;
        GameManager.Instance.IncreaseMoney += IncreaseMoney;
    }

    private void FixedUpdate()
    {
        ChangeVolume();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    private void CloseSound()
    {
        audioSource.PlayOneShot(audioClipClose);
    }

    private void IncreaseMoney()
    {
        audioSource.PlayOneShot(audioClipMoney);
    }
}
