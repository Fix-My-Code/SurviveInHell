using DI.Attributes.Register;
using Entities.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.HealthControllers
{
    [Register(typeof(IHealthView))]
    [Register(typeof(IEditHealth))]
    internal class HealthController : AdvancedHealthController, IHealthView
    {

    }
}
