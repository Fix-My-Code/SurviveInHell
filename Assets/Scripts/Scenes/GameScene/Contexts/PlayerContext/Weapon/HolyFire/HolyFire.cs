using DI.Attributes.Register;
using GameContext.Abstracts.Interfaces;
using ObjectContext.Enemies;
using PlayerContext.BuffSystem.Weapon.Abstracts.Interfaces;
using PlayerContext.Weapon.Abstracts;
using System.Collections;
using UnityEngine;

namespace PlayerContext.Weapon.HolyFire
{
    [Register(typeof(IUpgradeHolyFire))]
    internal class HolyFire : SplashWeapon, IDamageDealer, IUpgradeHolyFire
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
                var target = hitCollider.gameObject.GetComponentInChildren<IDamagable>();
                if (target != null)
                {
                    Attack(target);
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