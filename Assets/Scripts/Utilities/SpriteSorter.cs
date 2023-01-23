using UnityEngine;
using System;

namespace Utilities
{
    public class SpriteSorter : MonoBehaviour
    {
        [SerializeField]
        [Range(-1.0f, 1.0f)]
        private float offset;

        private int _sortingOrderBase = 0;      

        private Renderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }

        private void LateUpdate()
        {
            _renderer.sortingOrder = _sortingOrderBase - (int)(transform.position.y + offset);
        }
    }
}