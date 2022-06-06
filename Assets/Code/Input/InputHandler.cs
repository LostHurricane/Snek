using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVVMSnek
{
    public class InputHandler 
    {
        public float Direction { get => DirectionInput(); }


        private const string HORIZONTAL = "Horizontal";
        private const string VERTICAL = "Vertical";

        private float _threshHold = 0.0f;



        private float DirectionInput()
        {
            var axisH = Input.GetAxis(HORIZONTAL);
            var axisV = Input.GetAxis(VERTICAL);

            if (axisH > _threshHold)
            {
                return 90f;
            }
            if (axisH < -_threshHold)
            {
                return -90f;
            }
            else return 0f;
        }
        
    }
}
