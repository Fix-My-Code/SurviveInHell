using Enums;
using GameContext.Abstracts.Interfaces;
using LogicSceneContext;
using ObjectContext.Enemies.Abstracts;
using System.Collections;
using System.Linq;
using UnityEngine;
using Utilities;

namespace ObjectContext.Enemies.DeathRattles
{
    internal class ExplosionDeathRattle : DeathRattle<IExplosionDeathRattle>, IDamageDealer
    {
        [SerializeField]
        private LayerMask layer;
        private int _damage;
        [SerializeField]
        private float _radius;
        private bool _explosionEnabled;

        private CircleGizmos circleGizmos => GetComponent<CircleGizmos>();

        private protected override void OnEnable()
        {
            if (!IsInitialize)
            {
                return;
            }
            CheckDeathRattleStatus();
        }

        private protected override void CheckDeathRattleStatus()
        {
            if (!_router.DeathRattleStatus(DeathRattleTypes.Explosion, out var deathRattleArgs))
            {
                return;
            }

            Activate(deathRattleArgs);
        }

        private protected override void Activate(DeathRattleArgs args)
        {
            _explosionEnabled = true;
            _damage = args.damage;
            _radius = args.radius;
            circleGizmos.viewRadius = _radius;
        }

        private protected override void Action()
        {
            
            if (!_explosionEnabled)
            {
                return;
            }

            GetComponentsInChildren<Collider2D>().ToList().ForEach(x => x.gameObject.SetActive(false));
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, _radius, layer);
            foreach (Collider2D hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.TryGetComponent<Enemy>(out var enemy))
                {
                    Attack(enemy.GetComponentInChildren<IDamagable>());
                }
            }
        }

        public void Attack(IDamagable damagable)
        {
            damagable.ApplyDamage(_damage); 
        }

        public IEnumerator Reloading()
        {
            throw new System.NotImplementedException();
        }

    }
}
