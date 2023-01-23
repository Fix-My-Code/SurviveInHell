namespace Utilities.TimeKeeper
{
    internal interface ITImerFactory
    {
        Timer Get(int value); //Seconds
    }
}