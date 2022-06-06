using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVVMSnek
{
    public interface IDie: IGameObject
    {
        public Action<IDie> OnContactWithWall { get; set; }
    }
}
