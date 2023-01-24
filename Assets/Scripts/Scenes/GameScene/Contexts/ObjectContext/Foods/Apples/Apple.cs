using DI.Attributes.Construct;
using DI.Kernels;
using Enums;
using ObjectContext.Abstracts;
using PlayerContext.Abstract.Interfaces;
using UnityEngine;

namespace ObjectContext.Foods.Apples
{
    [RequireComponent(typeof(Collider2D))]
    internal class Apple : BasePickUpItem
    {
        [SerializeField]
        private AppleTypes type;

        [SerializeField]
        private SpriteRenderer spriteRenderer;

        private int GetHealth()
        {
            return (int)type;
        }

        public void SetAppleType(AppleTypes appleType)
        {
            type = appleType;
            SetColorApple();
        }

        private void SetColorApple()
        {
            switch (type)
            {
                case AppleTypes.RedApple:
                    
                    break;
                case AppleTypes.GreenApple:
                    spriteRenderer.color = Color.green;
                    break;
                case AppleTypes.PurpleApple:
                    spriteRenderer.color = Color.magenta;
                    break;
                case AppleTypes.GoldenApple:
                    spriteRenderer.color = Color.yellow;
                    break;
            }
        }

        public override void Action()
        {
            _healable.Heal(GetHealth() / 100f);
        }

        private void OnEnable()
        {
            SetColorApple();
        }

        [ConstructField(typeof(PlayerKernel))]
        private IHealable _healable;
    }
}