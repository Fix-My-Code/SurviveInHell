using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageDealer
{
    [SerializeField]
    private GameObject _target;
    public float Damage { 
        get => 15;
        set { }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, 2 * Time.deltaTime);
    }
}
