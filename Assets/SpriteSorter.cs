using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpriteSorter : MonoBehaviour
{
    private int _sortingOrderBase = 0;

    [SerializeField]
    [Range(-1.0f,1.0f)]
    private float offset;

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
