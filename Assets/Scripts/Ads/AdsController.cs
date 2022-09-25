using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Ads
{
    public class AdsController : MonoBehaviour
    {
        [SerializeField] private int adsMultiplier = 1;
        [SerializeField] private Button button;

        public int AdvMultiplier => adsMultiplier;

        //проверка
        public void AdsOn()
        {
            StartCoroutine(AdsActiveTime());
        }

        private IEnumerator AdsActiveTime()
        {
            adsMultiplier = 2;
            button.interactable = false;
            yield return new WaitForSeconds(15);
            adsMultiplier = 1;
            button.interactable = true;
        }
    }
}