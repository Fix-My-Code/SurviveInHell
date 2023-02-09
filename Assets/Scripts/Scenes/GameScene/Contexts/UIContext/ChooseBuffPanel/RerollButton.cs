using DI.Attributes.Construct;
using DI.Kernels;
using GameContext.Abstracts.Interfaces;
using System;
using UnityEngine;
using UnityEngine.UI;
using Utilities.Behaviours;

namespace UIContext.ChooseBuffPanel
{
    internal class RerollButton : KernelEntityBehaviour
    {
        public Action onReroll;

        [SerializeField]
        private Button rerollButton;

        private int CountTrigger
        {
            get => _countTrigger; 
            set 
            {
                _countTrigger = value;

                if (_countTrigger > _maxTrigger) 
                {
                    AddReroll();
                }

                onReroll?.Invoke();
            }
        }

        private int _countTrigger;
        private int _maxTrigger;

        private void Awake()
        {
            _maxTrigger = 2;
            rerollButton.onClick.AddListener(RerollBuff);
        }

        private void RerollBuff()
        {
            CountTrigger += 1;
            _playerHealth.ApplyDamage((int)((_playerHealth.CurrentHealth / 100) * 20));
        }

        private void AddReroll()
        {
            Debug.Log("Реклама");
        }

        [ConstructField(typeof(PlayerKernel))]
        private IDamagable _playerHealth;
    }
}