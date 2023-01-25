using DI.Extensions;
using PlayerContext.BuffSystem.Weapon.Abstracts;
using System.Collections.Generic;
using UIContext.Abstracts;
using UnityEngine;
using Utilities.Behaviours;
using Utillities;

namespace UIContext.ChooseBuffPanel
{
    internal class BuffGiver : KernelEntityBehaviour
    {
        [SerializeField]
        private List<GameObject> allBuffs;

        [SerializeField]
        private List<GameObject> availableBuffList;

        private List<GameObject> _baseBuffItems = new List<GameObject>();

        private void OnEnable()
        {
            LoadBuff();
        }

        private void OnDisable()
        {
            GetComponentsInChildren<BaseBuffUIItem>(true).ForEach(x => Destroy(x.gameObject));
        }

        private void LoadBuff()
        {
            allBuffs.ForEach(x => _baseBuffItems.Add(x));

            for (int i = 0; i < 3; i++)
            {
                if (_baseBuffItems.Count <= 0)
                {
                    return;
                }

                var randomInt = Randomizer.RandomIntValue(0, _baseBuffItems.Count);
                var buff = Instantiate(_baseBuffItems[randomInt], transform);
                if (buff.TryGetComponent<WeaponBuffEnabler>(out var weaponEnabler))
                {
                    weaponEnabler.onAction += AddBuffsInList;
                }
                _baseBuffItems.RemoveAt(randomInt);
                buff.gameObject.SetActive(true);
            }

            _baseBuffItems.Clear();
        }

        private void AddBuffsInList(List<GameObject> buffs, WeaponBuffEnabler weaponBuffEnabler)
        {
            if (!allBuffs.Contains(buffs[0]))
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

    }
}
