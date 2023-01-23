using TMPro;
using UnityEngine;

namespace UIContext.GameOver
{
    public class BlinkText : MonoBehaviour
    {
        public float blinkTime = 0.5f; 
        public float minAlpha = 0.2f; 
        public float maxAlpha = 1f; 
        public TextMeshProUGUI blinkText;

        private void Start()
        {
            InvokeRepeating("Blink", 0, blinkTime);
        }

        private void Blink()
        {
            float currentAlpha = blinkText.color.a;
            if (currentAlpha == minAlpha)
            {
                blinkText.color = new Color(blinkText.color.r, blinkText.color.g, blinkText.color.b, maxAlpha);
            } 
            else
            {
                blinkText.color = new Color(blinkText.color.r, blinkText.color.g, blinkText.color.b, minAlpha);
            }
        }
    }
}