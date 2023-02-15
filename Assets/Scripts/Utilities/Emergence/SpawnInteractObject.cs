using Enums;
using ObjectContext.Foods.Apples;
using ObjectContext.Gems;
using UnityEngine;
using Utilities.ObjectPooller;

namespace Utilities.Emergence
{
    internal class SpawnInteractObject : Singleton<SpawnInteractObject>
    {
        [SerializeField]
        private PoolObject gemPoolData;

        [SerializeField]
        private PoolObject soulPoolData;
        #region Food

        [SerializeField]
        private PoolObject applePoolData;

        [SerializeField]
        private PoolObject milkPoolData;

        [SerializeField]
        private PoolObject chickenLegPoolData;

        [SerializeField]
        private PoolObject cheesePoolData;

        #endregion

        public void SpawnGem(GemTypes gemType, Transform transform)
        {
            var item = Spawner.Instance.SpawnObject(gemPoolData, transform);

            if (item.TryGetComponent<Gem>(out var gem))
            {
                gem.SetGemType(gemType);
            }
        }

        #region SpawnFood

        public void SpawnApple(AppleTypes appleType, Transform transform)
        {
            var item = Spawner.Instance.SpawnObject(applePoolData, transform);

            if (item.TryGetComponent<Apple>(out var apple))
            {
                apple.SetAppleType(appleType);
            }
        }

        public void SpawnMilk(Transform transform)
        {
            Spawner.Instance.SpawnObject(milkPoolData, transform);
        }

        public void SpawnChickenLeg(Transform transform)
        {
            Spawner.Instance.SpawnObject(chickenLegPoolData, transform);
        }

        public void SpawnCheese(Transform transform)
        {
            Spawner.Instance.SpawnObject(cheesePoolData, transform);
        }

        #endregion

        public void SpawnSoul(Transform transform)
        {
            Spawner.Instance.SpawnObject(soulPoolData, transform);
        }
        public GameObject SpawnRandomObject(PoolObject pool, Transform transform)
        {
            return Spawner.Instance.SpawnObject(pool, transform);
        }

        private void OnEnable()
        {
            Spawner.Instance.PreparationPool(gemPoolData);
            Spawner.Instance.PreparationPool(applePoolData);
            Spawner.Instance.PreparationPool(milkPoolData);
            Spawner.Instance.PreparationPool(chickenLegPoolData);
            Spawner.Instance.PreparationPool(cheesePoolData);
            Spawner.Instance.PreparationPool(soulPoolData);
        }
    }
}