using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Spawner : Singleton<Spawner>
{
    [SerializeField]
    private GameObject gem;
    public void SpawnGem(Transform transform)
    {
        Instantiate(gem, transform, true);
    }
}
