using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public float updateInterval = 0.5f;
    private float accum = 0f;
    private int frames = 0;
    private float timeleft;
    public TextMeshProUGUI fpsDisplay;

    void Start()
    {
        timeleft = updateInterval;
    }

    void Update()
    {
        timeleft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        ++frames;

        if (timeleft <= 0f)
        {
            float fps = accum / frames;
            fpsDisplay.text = fps.ToString("F2");

            if (fps < 30)
            {
                fpsDisplay.color = Color.yellow;
            } else if (fps < 10)
            {
                fpsDisplay.color = Color.red;
            } else
            {
                fpsDisplay.color = Color.green;
            }

            timeleft = updateInterval;
            accum = 0f;
            frames = 0;
        }
    }
}
