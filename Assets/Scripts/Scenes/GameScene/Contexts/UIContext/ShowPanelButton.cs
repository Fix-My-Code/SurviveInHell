using UnityEngine;
using UnityEngine.UI;

public class ShowPanelButton : MonoBehaviour
{
    [SerializeField]
    private Button button;

    [SerializeField]
    private GameObject panel;

    private void Awake()
    {
        button.onClick.AddListener(OnButtonClickHandler);
    }

    private void OnButtonClickHandler()
    {
        panel.SetActive(panel.activeInHierarchy ? false : true);
    }

}
