using DI.Attributes.Register;
using GameContext.Abstracts.Interfaces;
using ObjectContext.Enemies;
using PlayerContext.BuffSystem.Weapon.Abstracts.Interfaces;
using PlayerContext.Weapon.Abstracts;
using System.Collections;
using UnityEngine;

namespace PlayerContext.Weapon.HolyFire
{
    [Register(typeof(IUpgradeDivineSmite))]
    internal class DivineSmite : SplashWeapon, IDamageDealer, IUpgradeDivineSmite
    {
        [SerializeField, Range(0, 40f)]
        private float findRadius;

        [SerializeField, Range(0, 3f)]
        private float renderTime;

        [SerializeField]
        private SpriteRenderer spriteRenderer;

        [SerializeField]
        private bool drawGuzmos;

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
                FindPoint();
                yield return new WaitForSeconds(attackSpeed);
            }
        }

        private void FindPoint()
        {
            var attackPoint = (Vector2)transform.position + Random.insideUnitCircle * findRadius;

            StartCoroutine(ShowRenderer(attackPoint));

            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(attackPoint, Radius, layer);
            foreach (Collider2D hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.TryGetComponent<Enemy>(out var enemy))
                {
                    Attack(enemy.GetComponentInChildren<IDamagable>());
                }
            }
        }

        public IEnumerator ShowRenderer(Vector2 point)
        {
            spriteRenderer.transform.position = point;

            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(renderTime);
            spriteRenderer.enabled = false;
        }

        public virtual void Attack(IDamagable damagable)
        {
            damagable.ApplyDamage(damage);
        }


        private void SpriteRendererUpdate()
        {
            spriteRenderer.transform.localScale = new Vector2(Radius, Radius) * 2;
        }

        private void OnDrawGizmos()
        {
            if(!drawGuzmos)
            {
                return;
            }

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, findRadius);
        }

        private void OnEnable()
        {
            spriteRenderer.transform.SetParent(null);

            SpriteRendererUpdate();
            StartCoroutine(Reloading());
        }

        private void OnDisable()
        {
            StopCoroutine(Reloading());
        }
    }
}