using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVVMSnek
{
    public interface IGatherer: IGameObject
    {

        public Action <IBonusView> OnContactWithBonus { get; set; }

    }
}
