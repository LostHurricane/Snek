using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVVMSnek
{
    public class ChainFactory
    {
        private GameObject _prototype;

        public ChainFactory (GameObject prototype)
        {
            _prototype = prototype;
        }

        public GameObject Produce (Vector3 position, Quaternion rotation)
        {
            return Object.Instantiate(_prototype, position, rotation);

        }
    }
}
