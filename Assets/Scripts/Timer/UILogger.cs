using TMPro;
using UnityEngine;

namespace Timer
{

    public class UILogger : MonoBehaviour, ILogger
    {
        [SerializeField]
        private TextMeshProUGUI _text;

        public void Logger(string message)
        {
            _text.text = message;
        }
    }
}