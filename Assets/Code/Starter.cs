using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVVMSnek
{
    public class Starter : MonoBehaviour
    {
        [SerializeField]
        private Data _data;

        private SnekObjectView _snekObjectView;
        private PlayerModelView _playerModelView;

        private float _time = 0f;


        // Start is called before the first frame update
        void Start()
        {
            
            _snekObjectView = Instantiate(_data.SnekHeadView).GetComponent<SnekObjectView>();
            var bonusView = Instantiate(_data.BonusView).GetComponent<BonusView>();


            var factory = new ChainFactory(_data.SnekTaleView);
            var movement = new MovementImplementation(_snekObjectView.Transform, _data.MovementStep);
            _playerModelView = new PlayerModelView(factory, movement);
            
            _snekObjectView.Initialize(_playerModelView);

            bonusView.Initialize(new BonusModelView());


        }

        // Update is called once per frame
        void Update()
        {
            _time += Time.deltaTime;

            if (_time >= _data.GameSpeed)
            {
                _time = _time - _data.GameSpeed;
                _playerModelView.Execute();

                if (_playerModelView.IsImmortal)
                {
                    _playerModelView.IsImmortal = false;
                }
            }
            

        }
    }
}
