using DI.Attributes.Register;
using UnityEngine;
using Utilities.Behaviours;

namespace ObjectContext.Tree
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