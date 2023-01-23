namespace Utilities.TimeKeeper
{
    internal class TimerFactory : Singleton<TimerFactory>, ITImerFactory
    {
        public Timer Get(int seconds)
        {
            return new Timer(seconds);
        }
    }
}