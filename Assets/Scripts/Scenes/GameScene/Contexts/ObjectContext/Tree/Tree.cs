using DI.Attributes.Register;
using ObjectContext.Enemies.Abstracts.Interfaces;
using ObjectContext.Tree.Abstarts;
using ObjectContext.Tree.Abstarts.Interfaces;
using UnityEngine;
using Utilities.Behaviours;

namespace ObjectContext.Tree
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