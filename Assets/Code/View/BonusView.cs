using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVVMSnek
{
    public class BonusView : MonoBehaviour, IBonusView
    {
        [SerializeField]
        private GameObject _gameObject;
        public GameObject GameObject { get => _gameObject; set => _gameObject = value; }

        private IModelView _modelView;
        
        public Action<IBonusView> OnCollection { get ; set ; }

        public void Initialize(IModelView modelView)
        {
            _modelView = modelView;
            modelView.SetDependancies(this);
        }

        public void Collect()
        {
            OnCollection.Invoke(this);
        }

        

    }
}
