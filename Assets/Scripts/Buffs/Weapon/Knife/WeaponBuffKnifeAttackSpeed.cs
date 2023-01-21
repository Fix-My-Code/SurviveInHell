using Buffs.Weapon.Interfaces;

namespace Buffs.Weapon.Knife
{
    internal class WeaponBuffKnifeAttackSpeed : WeaponBuffAttackSpeed<IImproveKnifeThrower>
    {
        protected override void OnEnable()
        {
            value = -0.2f;
            base.OnEnable();
            descriptinos = $"Блятский баф скорости бросания ножей на {value}";
            descriptionsTx.text = descriptinos;
        }
    }
}