using DI.Attributes.Register;
using Entities.Enemies.Interfaces;
using Entities.Other.Interfaces;
using UnityEngine;
using Utilities.Behaviours;

namespace Entities.Other
{
    [Register(typeof(ITreeDataObject))]
    [Register(typeof(IEnemy))]
    internal class Tree : KernelEntityBehaviour, ITreeDataObject, IEnemy
    {
        [SerializeField]
        private TreeDataObject entityData;

        public TreeDataObject Data => entityData;

        public GameObject Instance => gameObject;
    }
}