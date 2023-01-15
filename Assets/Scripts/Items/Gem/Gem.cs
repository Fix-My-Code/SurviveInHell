using Enums;
using ObjectPooller;
using UnityEngine;

namespace Items.Gem
{
    [RequireComponent(typeof(Collider2D))]
    internal class Gem : MonoBehaviour
    {
        [SerializeField]
        private GemTypes type;

        [SerializeField]
        private SpriteRenderer spriteRenderer;

        [SerializeField]
        private PoolObject poolData;

        public PoolObject GetPoolData() 
        {
            return poolData;
        }

        public int GetExperience()
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

        private void OnEnable()
        {
            SetColorGem();
        }

        public void Dispawn()
        {
            Spawner.Instance.DispawnObject(gameObject, poolData);
        }
    }
}