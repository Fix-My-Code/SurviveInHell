using Buffs;
using Buffs.Weapon;
using Cysharp.Threading.Tasks;
using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Extensions;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities.Behaviours;
using Utillites;

internal class BuffTypeList : MonoBehaviour
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

    private void AddBuffsInList(List<GameObject> buffs)
    {
        if (!allBuffs.Contains(buffs[0]))
        {
            allBuffs.AddRange(buffs);
        }
    }
}
