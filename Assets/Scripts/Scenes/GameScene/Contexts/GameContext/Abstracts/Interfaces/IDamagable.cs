namespace GameContext.Abstracts.Interfaces
{
    interface IDamagable
    {
        public float MaxHealth { get; set; }
        public float CurrentHealth { get; set; }
        public void ApplyDamage(int damage);
    }
}