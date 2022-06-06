using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVVMSnek
{
    public interface IBonusView : IGameObject
    {
        public Action<IBonusView> OnCollection { get; set; }

        public void Collect();
    }
}
