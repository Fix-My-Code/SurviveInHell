using DI.Attributes.Register;
using ObjectContext.Abstracts;
using UnityEngine;
using Utilities.Behaviours;
using Utilities.ObjectPooller;

namespace PlayerContext.Controllers
{
    [RequireComponent(typeof(Collider2D))]
    [Register]
    internal class TriggerController : KernelEntityBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.TryGetComponent<BasePickUpItem>(out var pickUpItem))
            {
                pickUpItem.Action();
                pickUpItem.Dispawn();
                return;
            }
        }
    }
}