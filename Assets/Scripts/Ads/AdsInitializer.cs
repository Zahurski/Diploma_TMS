using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    using UnityEngine;
    using UnityEngine.Advertisements;
 
    public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
    {
        [SerializeField] string _androidGameId;
        [SerializeField] string _iOSGameId;
        [SerializeField] bool _testMode = true;
        private InterstitialAdExample _interstitial;
        private RewardedAdsButton _rewarded;
        private BannerAdExample _banner;
        private string _gameId;
 
        void Awake()
        {
            InitializeAds();
            _interstitial = FindObjectOfType<InterstitialAdExample>();
            _rewarded = FindObjectOfType<RewardedAdsButton>();
            _banner = FindObjectOfType<BannerAdExample>();
        }
 
        public void InitializeAds()
        {
            _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
                ? _iOSGameId
                : _androidGameId;
            Advertisement.Initialize(_gameId, _testMode, this);
        }
 
        public void OnInitializationComplete()
        {
            Debug.Log("Unity Ads initialization complete.");
            _interstitial.LoadAd();
            _rewarded.LoadAd();
            _banner.LoadBanner();
        }
 
        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
        }
    }
}