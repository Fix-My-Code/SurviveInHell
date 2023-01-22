using Buffs.Weapon.Interfaces;

namespace Buffs.Weapon.Knife
{
    internal class WeaponBuffKnifeAttackSpeed : WeaponBuffAttackSpeed<IImproveKnifeThrower>
    {
        protected override void OnEnable()
        {
            value = -0.2f;
            base.OnEnable();
            descriptinos = $"�������� ��� �������� �������� ����� �� {value}";
            descriptionsTx.text = descriptinos;
        }
    }
}