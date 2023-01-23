using Buffs.Weapon.Interfaces;
using DI.Attributes.Register;
using Entities.Enemies;
using Entities.Interfaces;
using System.Collections;
using UnityEngine;

namespace Weapon
{
    [Register(typeof(IImproveHolyFire))]
    internal class HolyFire : SplashWeapon, IDamageDealer, IImproveHolyFire
    {
        private SpriteRenderer spriteRenderer;

        public override float Radius
        {
            get => base.Radius;
            set
            {
                SpriteRendererUpdate();
                base.Radius = value;
            }
        }

        public IEnumerator Reloading()
        {
            while (true)
            {
                FindEnemy();
                yield return new WaitForSeconds(attackSpeed);
            }
        }

        public virtual void Attack(IDamagable damagable)
        {
            damagable.ApplyDamage(damage);
        }

        internal void FindEnemy()
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, Radius, layer);
            foreach (Collider2D hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.TryGetComponent<Enemy>(out var enemy))
                {
                    Attack(enemy.GetComponentInChildren<IDamagable>());
                }
            }
        }

        private void OnEnable()
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            SpriteRendererUpdate();
            StartCoroutine(Reloading());
        }

        private void SpriteRendererUpdate()
        {
            spriteRenderer.transform.localScale = new Vector2(Radius, Radius) * 2;
        }

        private void OnDisable()
        {
            StopCoroutine(Reloading());
        }

    }
}