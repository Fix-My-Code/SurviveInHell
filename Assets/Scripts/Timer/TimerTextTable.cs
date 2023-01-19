using TMPro;
using UnityEngine;

namespace TimeKeeper
{
    public class TimerTextTable : MonoBehaviour
    {
        private ITimer timer;

        private TextMeshProUGUI text;

        void Start()
        {
            timer = FindObjectOfType<Timer>();

            text = GetComponent<TextMeshProUGUI>();

            timer.OnTimerUpdate += OutputText;
        }

        private void OutputText(float value)
        {
            text.text = value.ToString();
        }

        private void OnDestroy()
        {
            timer.OnTimerUpdate -= OutputText;
        }
    }
}