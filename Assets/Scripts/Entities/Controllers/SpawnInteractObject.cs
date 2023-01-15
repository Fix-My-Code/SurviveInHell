using Enums;
using Items.Apple;
using Items.Gem;
using ObjectPooller;
using UnityEngine;

namespace Entities.Controllers
{
    internal class SpawnInteractObject : Singleton<SpawnInteractObject>
    {
        [SerializeField]
        private PoolObject gemPoolData;

        [SerializeField]
        private PoolObject applePoolData;

        public void SpawnGem(GemTypes gemType, Transform transform)
        {
            var item = Spawner.Instance.SpawnObject(gemPoolData, transform);

            if (item.TryGetComponent<Gem>(out var gem))
            {
                gem.SetGemType(gemType);
            }
        }

        public void SpawnApple(AppleTypes appleType, Transform transform)
        {
            var item = Spawner.Instance.SpawnObject(gemPoolData, transform);

            if (item.TryGetComponent<Apple>(out var apple))
            {
                apple.SetAppleType(appleType);
            }
        }

        private void OnEnable()
        {
            Spawner.Instance.PreparationPool(gemPoolData);
            Spawner.Instance.PreparationPool(applePoolData);
        }
    }
}