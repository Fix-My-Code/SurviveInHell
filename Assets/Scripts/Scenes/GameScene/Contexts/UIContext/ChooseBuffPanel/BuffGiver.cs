using DI.Extensions;
using PlayerContext.BuffSystem.Weapon.Abstracts;
using System.Collections.Generic;
using UIContext.Abstracts;
using UnityEngine;
using Utilities.Behaviours;
using Utilities;
using System.Linq;
using System;

namespace UIContext.ChooseBuffPanel
{
    internal class BuffGiver : KernelEntityBehaviour
    {
        [SerializeField]
        private Transform container;

        [SerializeField]
        private List<GameObject> allBuffs;

        private RerollButton rerollButton;

        private List<GameObject> _baseBuffItems = new List<GameObject>();
        private List<GameObject> _availableItems = new List<GameObject>();

        private void Awake()
        {
            rerollButton = GetComponentInChildren<RerollButton>(true);
            rerollButton.onReroll += Roll;
        }

        private void OnEnable()
        {
            Roll();        
        }

        private void OnDisable()
        {
            GetComponentsInChildren<BaseBuffUIItem>(true).ForEach(x => Destroy(x.gameObject));
        }

        private void OnDestroy()
        {
            rerollButton.onReroll -= Roll;
        }

        private void AddBuffsInList(List<GameObject> buffs, WeaponBuffEnabler weaponBuffEnabler)
        {
            if (buffs.Any() && !allBuffs.Contains(buffs[0]) && buffs.Any())
            {
                allBuffs.AddRange(buffs);
            }
            GameObject currentBuffObject = gameObject;

            foreach (var buff in allBuffs)
            {
                if (buff.TryGetComponent<WeaponBuffEnabler>(out var currentBuff))
                {
                    var type = currentBuff.GetType();
                    var type1 = weaponBuffEnabler.GetType();

                    if (type == type1)
                    {
                        currentBuffObject = buff;
                        break;
                    }

                }
            }

            allBuffs.Remove(currentBuffObject);
        }

        private void Roll()
        {
            _baseBuffItems.AddRange(allBuffs);

            if (_availableItems.Any())
            {
                _availableItems.ForEach(x => Destroy(x));
                _availableItems.Clear();
            }

            for (int i = 0; i < 3; i++)
            {
                if (_baseBuffItems.Count <= 0)
                {
                    return;
                }

                var randomInt = Randomizer.RandomIntValue(0, _baseBuffItems.Count);
                var buff = Instantiate(_baseBuffItems[randomInt], container);
                if (buff.TryGetComponent<WeaponBuffEnabler>(out var weaponEnabler))
                {
                    weaponEnabler.onAction += AddBuffsInList;
                }
                _baseBuffItems.RemoveAt(randomInt);
                buff.gameObject.SetActive(true);
                _availableItems.Add(buff);
            }

            _baseBuffItems.Clear();
        }
    }
}