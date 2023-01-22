using Buffs.Weapon.Interfaces;

namespace Buffs.Weapon.Knife
{
    internal class WeaponBuffKnifeProjectile : WeaponBuffProjectile<IImproveKnifeThrower>
    {
        protected override void OnEnable()
        {
            value = 1;
            base.OnEnable();
            descriptinos = $"Блятский баф количества ножей на {value}";
            descriptionsTx.text = descriptinos;
        }
    }
}