using System;
using System.Globalization;
using Ads;
using GasStation.Config;
using OilPump.Config;
using UnityEngine;

public class FirstLoad : MonoBehaviour
{
    private const string LAST_PLAYED_TIME = "LastPlayedTime";
    [SerializeField] private GasStationConfig gasStation;
    [SerializeField] private OilPumpConfig oilPump;

    private RewardedAdsButton _ads;
    private float _moneySum;
    private float _totalMoney;

    private void Awake()
    {
        _ads = FindObjectOfType<RewardedAdsButton>();
    }

    private void Start()
    {
        _moneySum = gasStation.Cost + oilPump.Cost;
        CalculateOfflineIncome();
        _ads.RewardedAdsShowComplete += GetBounty;
    }

    public void Getx2()
    {
        _ads.ShowAd();
    }
    
    public void Getx1()
    {
        
    }

    private void GetBounty()
    {;
        GameManager.Instance.Money += (float)Math.Round(_totalMoney, 0);
        print("Добавлено: " + (float)Math.Round(_totalMoney, 0));
    }
    
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString(LAST_PLAYED_TIME, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
    }
    
    private void CalculateOfflineIncome()
    {
        string lastPlayedTimeString = PlayerPrefs.GetString(LAST_PLAYED_TIME, null);
        if(lastPlayedTimeString == null) return;

        var lastPlayedTime = DateTime.Parse(lastPlayedTimeString, CultureInfo.InvariantCulture);
        int timeSpanRestriction = 2 * 60 * 60;
        double secondSpan = (DateTime.UtcNow - lastPlayedTime).TotalSeconds;

        if (secondSpan > timeSpanRestriction)
            secondSpan = timeSpanRestriction;

        _totalMoney = (float)secondSpan * _moneySum/10;
        print("Вас небыло в игре: " + secondSpan + "Вы заработали: " + _totalMoney);
    }
}
