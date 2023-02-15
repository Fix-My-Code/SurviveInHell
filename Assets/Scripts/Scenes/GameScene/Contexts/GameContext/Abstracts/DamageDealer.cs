using GameContext.Abstracts.Interfaces;
using System.Collections;
using Utilities.Behaviours;

namespace GameContext.Abstracts
{
    internal abstract class DamageDealer : KernelEntityBehaviour, IDamageDealer
    {
        private protected float AttackSpeed
        {
            get => _attackSpeed;
            set
            {
                _attackSpeed = value;
            }
        }
        private protected float Damage { get; set; }

        private float _attackSpeed;

        public abstract void Attack(IDamagable damagable);

        public abstract IEnumerator Reloading();

    }
}