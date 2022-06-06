using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVVMSnek
{
    public interface IModelView
    {
        void SetDependancies(IGameObject view);
    }
}