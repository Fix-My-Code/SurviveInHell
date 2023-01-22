using Buffs.Weapon.Interfaces;

namespace Buffs.Weapon.Knife
{
    internal class WeaponBuffKnifeProjectileSpeed : WeaponBuffProjectileSpeed<IImproveKnifeThrower>
    {
        protected override void OnEnable()
        {
            value = 200;
            base.OnEnable();
            descriptinos = $"�������� ��� �������� ����� �� {value}";
            descriptionsTx.text = descriptinos;
        }
    }
}