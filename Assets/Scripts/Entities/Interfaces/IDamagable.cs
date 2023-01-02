using System;
using UnityEngine;

namespace Entities.Interfaces
{
    interface IDamagable
    {
        event Action<IDamageDealer> onColliderEnter;
    }
}
