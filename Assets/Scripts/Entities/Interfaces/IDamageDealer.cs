using System.Collections;
using UnityEngine;

namespace Entities.Interfaces
{
    interface IDamageDealer
    {
        void Attack(IDamagable damagable);
        IEnumerator Reloading();
    }
}
