using Buffs.Weapon.Interfaces;
using DI.Attributes.Register;
using Entities.Enemies;
using Entities.Interfaces;
using System.Collections;
using UnityEngine;

namespace Weapon
{
    internal class HolyFire : MonoBehaviour, IDamageDealer
    {
        private SpriteRenderer spriteRenderer;
        private IHolyFireData holyFireData;

        public IEnumerator Reloading()
        {
            while (true)
            {
                FindEnemy();
                yield return new WaitForSeconds(holyFireData.GetAttackSpeed());
            }
        }

        public virtual void Attack(IDamagable damagable)
        {
            damagable.ApplyDamage(holyFireData.GetDamage());
        }

        internal void FindEnemy()
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, holyFireData.Radius, holyFireData.GetLayer());
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
            holyFireData = GetComponentInParent<HolyFireActivator>();
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            holyFireData.onRadiusChanged += SpriteRendererUpdate;
            SpriteRendererUpdate();
            StartCoroutine(Reloading());
        }

        private void SpriteRendererUpdate()
        {
            spriteRenderer.transform.localScale = new Vector2(holyFireData.Radius, holyFireData.Radius) * 2;
        }

        private void OnDisable()
        {
            StopCoroutine(Reloading());
            holyFireData.onRadiusChanged -= SpriteRendererUpdate;
        }

    }
}