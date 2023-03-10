using System.Collections.Generic;
using UnityEngine;
using Utilities.ObjectPooller;

namespace GameContext.Chest
{
    [CreateAssetMenu(menuName = "Create/Data/Objects/Chest")]
    public class ChestDataObject : ScriptableObject
    {
        public List<PoolObject> objects;
    }
}