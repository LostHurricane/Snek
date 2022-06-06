using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVVMSnek
{
    public class ChainLink : IChain
    {
        public Transform LastLink { get => GetNextLink(); }

        private Transform _linkTransform;
        private Vector3 _lastPosition;
        private Quaternion _lastRotation;

        private IChain _nextLink;

        public ChainLink (Transform transform)
        {
            _linkTransform = transform;
            _lastPosition = _linkTransform.position;
            _lastRotation = _linkTransform.rotation;

        }

        public IChain Handle()
        {
            if (_nextLink != null)
            {
                _nextLink.Handle(_lastPosition, _lastRotation);
            }
            _lastPosition = _linkTransform.position;
            _lastRotation = _linkTransform.rotation;

            return _nextLink;
        }


        public IChain Handle(Vector3 position, Quaternion rotation)
        {
            _linkTransform.position = position;
            _linkTransform.rotation = rotation;
            return Handle();
        }

        public IChain SetNext(IChain nextHandler)
        {
            if (_nextLink != null)
            {
                _nextLink.SetNext(nextHandler);
            }
            else
            {
                _nextLink = nextHandler;
            }
            return nextHandler;
        }

        private Transform GetNextLink()
        {
            if (_nextLink != null)
            {
                return _nextLink.LastLink;
            }
            else
            {
                return _linkTransform;
            }
        }

    }
}
