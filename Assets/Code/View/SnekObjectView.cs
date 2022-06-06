using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVVMSnek
{
    public class SnekObjectView : MonoBehaviour, ISnekView
    {
        [SerializeField]
        private GameObject _gameObject;
        public GameObject GameObject { get => _gameObject; set => _gameObject = value; }

        [SerializeField]
        private Transform _transform;
        public Transform Transform { get => _transform; set => _transform = value; }

        private IModelView _modelView;
        public Action<IDie> OnContactWithWall { get; set; }
        public Action<IBonusView> OnContactWithBonus { get ; set ; }

        public void Initialize(IModelView modelView)
        {
            _modelView = modelView;
            modelView.SetDependancies(this);
        }

        private void OnDestroy()
        {
            if (_modelView is ICleanup cleanup)
            {
                cleanup.Cleanup();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<IBonusView>(out var bv))
            {
                OnContactWithBonus.Invoke(bv);
            }

            else OnContactWithWall.Invoke(this);
        }
    }
}