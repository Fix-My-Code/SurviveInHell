using Buffs.Weapon.Interfaces;
using DI.Attributes.Register;
using Entities.Enemies;
using Entities.Interfaces;
using System.Collections;
using UnityEngine;

namespace Weapon
{
    [Register(typeof(IImproveHolyFire))]
    internal class HolyFire : CircleWeapon, IImproveHolyFire
    {
        [SerializeField]
        private SpriteRenderer sprite;

        [SerializeField]
        private LayerMask layer;

        private float _radius;

        public float Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
                sprite.transform.localScale = new Vector2(_radius, _radius) * 2;
            }
        }

        internal void Attack()
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, Radius, layer);
            foreach (Collider2D hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.TryGetComponent<Enemy>(out var enemy))
                    enemy.GetComponentInChildren<IDamagable>().ApplyDamage(damage);
            }
        }

        private void OnEnable()
        {
            Radius = radius;
            StartCoroutine(Reloading());
        }

        private void OnDisable()
        {
            StopCoroutine(Reloading());
        }

        private IEnumerator Reloading()
        {
            while (true)
            {
                Attack();
                yield return new WaitForSeconds(attackSpeed);
            }
        }

    }
}