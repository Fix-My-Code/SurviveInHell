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

internal class BuffTypeList : KernelEntityBehaviour
{
    [SerializeField]
    private List<GameObject> allBuffs;

    [SerializeField]
    private List<GameObject> buffList;



    private List<GameObject> baseBuffItems = new List<GameObject>();

    private void OnEnable()
    {
        allBuffs.ForEach(x => baseBuffItems.Add(x));

        for(int i = 0; i < 3; i++) { 
            if(baseBuffItems.Count <= 0)
            {
                return;
            }

            var randomInt = Randomizer.RandomIntValue(0, baseBuffItems.Count);
            var buff = Instantiate(baseBuffItems[randomInt], transform);
            if(buff.TryGetComponent<WeaponBuffEnabler>(out var weaponEnabler))
            {

                weaponEnabler.onAction += AddBuffsInList;
            }
            baseBuffItems.RemoveAt(randomInt);
            buff.gameObject.SetActive(true);
        }

        baseBuffItems.Clear();
    }

    private void AddBuffsInList(List<GameObject> buffs)
    {
        if (!allBuffs.Contains(buffs[0]))
        {
            allBuffs.AddRange(buffs);
        }
    }

    private void OnDisable()
    {
        GetComponentsInChildren<BaseBuffUIItem>(true).ForEach(x => Destroy(x.gameObject));
    }

    [ConstructMethod(typeof(PlayerKernel))]
    private void Construct(IKernel kernel)
    {

    }
}
