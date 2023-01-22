using Buffs.Weapon.Interfaces;

namespace Buffs.Weapon.Knife
{
    internal class WeaponBuffKnifeProjectile : WeaponBuffProjectile<IImproveKnifeThrower>
    {
        protected override void OnEnable()
        {
            value = 1;
            base.OnEnable();
            descriptinos = $"�������� ��� ���������� ����� �� {value}";
            descriptionsTx.text = descriptinos;
        }
    }
}