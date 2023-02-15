using DI.Attributes.Construct;
using DI.Kernels;
using GameContext;
using ObjectContext.Abstracts;

namespace ObjectContext.Currency
{
    internal class Soul : BasePickUpItem
    {
        public override void Action()
        {
            _soulCounter.AddSoul();
            Dispawn();
        }
        
        [ConstructField(typeof(GameKernel))]
        private ISoulCounter _soulCounter;
    }
}