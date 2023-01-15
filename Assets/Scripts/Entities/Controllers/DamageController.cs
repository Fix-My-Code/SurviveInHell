using DI.Attributes.Register;
using Entities.Interfaces;
using System;
using Utilities.Behaviours;

namespace Entities.Controllers
{

    internal class DamageController : KernelEntityBehaviour
    {
        public event Action<int> onTakeDamage;

        public void ApplyDamage(int damage)
        {
            onTakeDamage?.Invoke(damage);
        }
    }
}