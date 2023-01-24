using DI.Attributes.Construct;
using DI.Kernels;
using Enums;
using ObjectContext.Abstracts;
using PlayerContext.Abstract.Interfaces;
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
        }

        private void OnEnable()
        {
            SetColorGem();
        }

        [ConstructField(typeof(PlayerKernel))]
        private IExperienced _experienced;
    }
}