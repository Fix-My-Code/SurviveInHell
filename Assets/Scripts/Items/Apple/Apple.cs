using Enums;
using ObjectPooller;
using UnityEngine;

namespace Items.Apple
{
    [RequireComponent(typeof(Collider2D))]
    internal class Apple : MonoBehaviour
    {
        [SerializeField]
        private AppleTypes type;

        [SerializeField]
        private SpriteRenderer spriteRenderer;

        [SerializeField]
        private PoolObject poolData;

        public PoolObject GetPoolData()
        {
            return poolData;
        }

        public int GetHealth()
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
                    spriteRenderer.color = Color.red;
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

        private void OnEnable()
        {
            SetColorApple();
        }

    }
}