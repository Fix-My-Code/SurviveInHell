using Buffs.Weapon.Interfaces;

namespace Buffs.Weapon.Knife
{
    internal class WeaponBuffKnifeProjectileDamage : WeaponBuffDamage<IImproveKnifeThrower>
    {
        protected override void OnEnable()
        {
            value = 20;
            base.OnEnable();
            descriptinos = $"�������� ��� ����� ����� �� {value}";
            descriptionsTx.text = descriptinos;
        }
    }
}