namespace GameContext.Abstracts.Interfaces
{
    interface IRegenerationSpeedBuff : IBuff
    {
        public void IncreaseRegenerationSpeed(int value);
        public void DecreaseRegenerationSpeed(int value);
    }
}