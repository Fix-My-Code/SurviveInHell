using UnityEngine;

namespace Entities.Enemy
{
    [CreateAssetMenu(menuName = "Create/Enemy Data")]
    public class EnemyDataObject : ScriptableObject
    {
        public int Damage;

        [Range(0.2f, 3)]
        public float AttackSpeed;
    }
}
