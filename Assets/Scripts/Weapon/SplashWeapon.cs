using Buffs.Weapon.Interfaces;
using DI.Attributes.Register;
using System;
using UnityEngine;
using Utilities.Behaviours;

internal class SplashWeapon : KernelEntityBehaviour, IImpoveSplashWeapon
{
    public event Action onRadiusChanged;

    [SerializeField]
    private GameObject splashObject;

    [SerializeField]
    private protected int damage;

    [SerializeField]
    private protected LayerMask layer;

    [SerializeField]
    private protected float radius;

    [SerializeField]
    private protected float attackSpeed;

    public virtual float Radius
    {
        get { return radius; }
        set 
        { 
            radius = value;
            onRadiusChanged?.Invoke();
        }
    }

    public virtual void IncreaseRadius(float value)
    {
        radius += value;
    }

    public virtual void IncreaseDamage(int value)
    {
        damage += value;
    }

    public virtual void DecreaseDamage(int value)
    {
        damage -= value;
    }

    public virtual void IncreaseAttackSpeed(float value)
    {
        attackSpeed += value;
    }

    public virtual void DecreaseAttackSpeed(int value)
    {
        attackSpeed -= value;
    }

    public float GetAttackSpeed()
    {
        return attackSpeed;
    }

    public int GetDamage()
    {
        return damage;
    }

    public LayerMask GetLayer()
    {
        return layer;
    }

    public void SetActive(bool value)
    {
        splashObject.SetActive(value);
    }

    private void OnEnable()
    {
        Radius = radius;
    }
}
