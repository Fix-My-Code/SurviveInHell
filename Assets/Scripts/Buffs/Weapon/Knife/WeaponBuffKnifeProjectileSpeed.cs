using Buffs.Weapon.Interfaces;

namespace Buffs.Weapon.Knife
{
    internal class WeaponBuffKnifeProjectileSpeed : WeaponBuffProjectileSpeed<IImproveKnifeThrower>
    {
        protected override void OnEnable()
        {
            value = 200;
            base.OnEnable();
            descriptinos = $"Блятский баф скорости ножей на {value}";
            descriptionsTx.text = descriptinos;
        }
    }
}