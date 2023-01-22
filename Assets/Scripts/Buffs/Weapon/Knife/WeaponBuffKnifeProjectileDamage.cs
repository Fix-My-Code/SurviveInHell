using Buffs.Weapon.Interfaces;

namespace Buffs.Weapon.Knife
{
    internal class WeaponBuffKnifeProjectileDamage : WeaponBuffDamage<IImproveKnifeThrower>
    {
        protected override void OnEnable()
        {
            value = 20;
            base.OnEnable();
            descriptinos = $"Блятский баф урона ножей на {value}";
            descriptionsTx.text = descriptinos;
        }
    }
}