using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Interfaces
{
    interface ILevelUpCallBack
    {
        public event Action<int> onLevelChanged;
    }
}