using UnityEngine;
using Utilities;
using Utilities.Emergence;

namespace GameContext.Chest
{
    internal class Chest : MonoBehaviour
    {
        [SerializeField]
        private ChestDataObject data;

        [SerializeField]
        private float itemDropSpeed;

        [SerializeField]
        private Transform spawnPoint;

        private bool _isOpen = false;
        public void Action()
        {
            if (_isOpen)
            {
                return;
            }
            SpawnInteractObject.Instance.SpawnRandomObject(data.objects[Randomizer.RandomIntValue(0,2)], spawnPoint);
            GetComponent<SpriteRenderer>().color = Color.black;
            _isOpen = true;
        }  
        
    }
}