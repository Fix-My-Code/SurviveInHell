using System.Collections;

namespace GameContext.Abstracts.Interfaces
{
    interface IDamageDealer
    {
        public void Attack(IDamagable damagable);
        public IEnumerator Reloading();
    }
}