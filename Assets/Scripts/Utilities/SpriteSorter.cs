using UnityEngine;
using System;

namespace Utillities
{
    public class SpriteSorter : MonoBehaviour
    {
        [SerializeField]
        [Range(-10.0f, 10.0f)]
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