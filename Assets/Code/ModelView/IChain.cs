using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVVMSnek
{
    public interface IChain
    {
        Transform LastLink { get; }

        IChain Handle( );
        IChain Handle(Vector3 position, Quaternion rotation);
        IChain SetNext(IChain nextHandler);
    }
}
