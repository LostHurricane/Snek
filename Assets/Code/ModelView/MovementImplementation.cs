using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVVMSnek
{
    public class MovementImplementation
    {
        private Transform _transform;
        private float _stepLengh;

        public MovementImplementation(Transform transform, float step)
        {
            _transform = transform;
            _stepLengh = step;
        }

        public void Execute ()
        {
            _transform.position += _transform.up * _stepLengh;
        }

        public void ChangeDirection(float directon)
        {
            _transform.Rotate(Vector3.forward, directon);
        }

    }
}
