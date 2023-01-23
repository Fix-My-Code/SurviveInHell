using DI.Attributes.Construct;
using DI.Attributes.Register;
using DI.Interfaces.KernelInterfaces;
using GameContext.Abstracts.Interfaces;
using GameContext.Components;
using ObjectContext.Enemies.Abstracts.Interfaces;
using ObjectContext.Tree.Abstarts.Interfaces;
using Utilities.Emergence;

namespace ObjectContext.Tree.Abstarts
{
    [Register(typeof(IHealthView),
              typeof(IDamagable))]
    internal class TreeHealthController : BaseHealthComponent
    {
        internal virtual void Initialize(ITreeDataObject entity)
        {
            MaxHealth = entity.Data.MaxHealth;
            CurrentHealth = entity.Data.MaxHealth;
            onDead += OnDeadHeandler;
            IsInitialize = true;
        }

        private void OnDeadHeandler()
        {
            SpawnInteractObject.Instance.SpawnApple(_treeData.Data.appleType, _parent.Instance.transform);
            Destroy(_parent.Instance);
        }

        #region KernelEntity

        [ConstructField]
        private ITreeDataObject _treeData;

        [ConstructField]
        private IEnemy _parent;

        [ConstructMethod]
        private void Construct(IKernel kernel)
        {
            Initialize(_treeData);
        }

        protected override void OnDispose()
        {
            onDead -= OnDeadHeandler;
        }

        #endregion
    }
}