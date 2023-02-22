using DI.Attributes.Construct;
using DI.Interfaces.KernelInterfaces;
using DI.Kernels;
using Enums;
using ObjectContext.Abstracts;
using PlayerContext.Abstract.Interfaces;
using PlayerContext.BuffSystem.GameBusters;
using System.Collections;
using UnityEngine;

namespace ObjectContext.Gems
{
    [RequireComponent(typeof(Collider2D))]
    internal class Gem : BasePickUpItem
    {
        [SerializeField]
        private GemTypes type;

        [SerializeField]
        private SpriteRenderer spriteRenderer;

        private int GetExperience()
        {
            return (int)type;
        }

        public void SetGemType(GemTypes gemType)
        {
            type = gemType;
            SetColorGem();
        }

        private void SetColorGem()
        {
            switch (type)
            {
                case GemTypes.BlueGem:
                    spriteRenderer.color = Color.blue;
                    break;
                case GemTypes.GreenGem:
                    spriteRenderer.color = Color.green;
                    break;
                case GemTypes.RedGem:
                    spriteRenderer.color = Color.red;
                    break;
                case GemTypes.PurpleGem:
                    spriteRenderer.color = Color.magenta;
                    break;
            }
        }

        public override void Action()
        {
            _experienced.AddExperience(GetExperience());
            Dispawn();
        }

        public void MoveTo(Transform transform, float speed = 2)
        {
            if (gameObject.activeSelf)
            {
                StartCoroutine(Move(transform, speed));
            }
        }

        private IEnumerator Move(Transform transform, float speed)
        {
            while(this.transform.position != transform.position)
            {
                Vector3 desiredVelocity = Vector3.zero;
                float distanceToPlayer = Vector3.Distance(this.transform.position, transform.position);
                desiredVelocity = (transform.position - this.transform.position).normalized * speed;
                this.transform.position += desiredVelocity * Time.deltaTime;
                yield return new WaitForFixedUpdate();
            }
        }

        private void OnEnable()
        {
            SetColorGem();
        }

        private void OnDisable()
        {
            StopCoroutine(nameof(Move));
        }

        private IExperienced _experienced;
        private IGemMagnet _gemMagent;

        [ConstructMethod(typeof(PlayerKernel))]
        private void Construct(IKernel kernel)
        {
            _experienced = kernel.GetInjection<IExperienced>();
            _gemMagent = kernel.GetInjection<IGemMagnet>();
            _gemMagent.onMagnetActive += MoveTo;
        }

        protected override void OnDispose()
        {
            _gemMagent.onMagnetActive -= MoveTo;
        }
    }
}