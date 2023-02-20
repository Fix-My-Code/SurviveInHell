using DI.Attributes.Construct;
using DI.Kernels;
using GameContext;
using UnityEngine;
using UnityEngine.UI;
using Utilities.Behaviours;

internal class SwitchSceneButtonUI : KernelEntityBehaviour
{
    [SerializeField]
    private Scenes scene;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Play);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(Play);
    }

    private void Play()
    {
        _sceneSwitcher.SwitchScene(scene);
    }

    [ConstructField(typeof(GameKernel))]
    private ISceneSwitcher _sceneSwitcher;
}
