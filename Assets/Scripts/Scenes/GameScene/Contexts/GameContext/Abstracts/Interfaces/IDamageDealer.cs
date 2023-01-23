using System.Collections;
using UnityEngine;

namespace Entities.Interfaces
{
    interface IDamageDealer
    {
        public void Attack(IDamagable damagable);
        public IEnumerator Reloading();
    }
}
