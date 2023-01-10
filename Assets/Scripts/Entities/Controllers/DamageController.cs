using DI.Attributes.Register;
using Entities.Interfaces;
using System;
using Utilities.Behaviours;

namespace Entities.Controllers
{
    [Register(typeof(IDamagable))]
    internal class DamageController : KernelEntityBehaviour, IDamagable
    {
        public event Action<int> onTakeDamage;

        public void ApplyDamage(int damage)
        {
            onTakeDamage?.Invoke(damage);
        }
    }
}