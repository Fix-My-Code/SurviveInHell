using System.Collections.Generic;
using UnityEngine;
using Utillites;

namespace UI
{
    public class BuffListtUI : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> buffs;

        [SerializeField]
        private Transform container;

        private List<GameObject> _buffs = new List<GameObject>();

        private void OnEnable()
        {
            _buffs.AddRange(buffs.ToArray());

            for (int i = 0; i < 3; i++)
            {
                if (_buffs.Count == 0)
                {
                    return;
                }

                var randomInt = Randomizer.RandomIntValue(0, _buffs.Count);

                _buffs[randomInt].SetActive(true);
                _buffs.RemoveAt(randomInt);
            }
        }

        private void OnDisable()
        {
            foreach(var buff in buffs)
            {
                buff.SetActive(false);
            }
        }
    }
}