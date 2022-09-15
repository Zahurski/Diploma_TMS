using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Adv
{
    public class AdvController : MonoBehaviour
    {
        [SerializeField] private int advMultiplier = 1;
        [SerializeField] private Button button;

        public int AdvMultiplier => advMultiplier;

        //проверка
        public void AdvOn()
        {
            StartCoroutine(AdvActiveTime());
        }

        private IEnumerator AdvActiveTime()
        {
            advMultiplier = 2;
            button.interactable = false;
            yield return new WaitForSeconds(15);
            advMultiplier = 1;
            button.interactable = true;
        }
    }
}