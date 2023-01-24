using DI.Attributes.Register;
using ObjectContext.Enemies.Abstracts.Interfaces;
using ObjectContext.Trees.Abstracts;
using ObjectContext.Trees.Abstracts.Interfaces;
using UnityEngine;
using Utilities.Behaviours;

namespace ObjectContext.Trees
{
    [Register(typeof(ITreeDataObject),
              typeof(IEnemy))]
    internal class Tree : KernelEntityBehaviour, ITreeDataObject, IEnemy
    {
        [SerializeField]
        private TreeDataObject entityData;

        public TreeDataObject Data => entityData;

        public GameObject Instance => gameObject;
    }
}