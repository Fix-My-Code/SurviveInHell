using System.Collections;
using UnityEngine;

namespace Entities.Interfaces
{
    interface IDamageDealer
    {
        void Attack();
        void OnCollisionEnter2D(Collision2D collision);
        void OnCollisionExit2D(Collision2D collision);
        IEnumerator Reloading();
    }
}
