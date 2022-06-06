using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVVMSnek
{
    [CreateAssetMenu(fileName = "Data", menuName = "Configs/Data", order = 0)]
    public class Data : ScriptableObject
    {
        public float GameSpeed;
        public float MovementStep;

        public GameObject SnekHeadView;
        public GameObject SnekTaleView;
        public GameObject BonusView;


    }
}
