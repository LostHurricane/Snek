using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVVMSnek
{
    public class PlayerModelView : IModelView, ICleanup
    {
        public bool IsAlive { get; private set; }
        public bool IsImmortal { get; set; }

        private int _count;

        private InputHandler _inputHandler;
        private ISnekView _snekView;
        
        private TaleMaker _taleMaker;
        private ChainFactory _chainFactory;

        private MovementImplementation _movementImplementation;


        public PlayerModelView (ChainFactory chainFactory, MovementImplementation movementImplementation)
        {
            _inputHandler = new InputHandler();
            _movementImplementation = movementImplementation;
            _chainFactory = chainFactory;

            _count = 0;
            IsAlive = true;
            IsImmortal = true;
        }

        public void SetDependancies(IGameObject view)
        {
            if (view is ISnekView PlayerView)
            {
                _snekView = PlayerView;
            }
            _taleMaker = new TaleMaker(_chainFactory, _snekView.GameObject.transform);


            _snekView.OnContactWithWall += Endgame;
            _snekView.OnContactWithBonus += GatherBonus;
            _snekView.OnContactWithBonus += _taleMaker.AddLink;


        }

        public void Execute ()
        {

            if (IsAlive)
            {
                _movementImplementation.ChangeDirection(_inputHandler.Direction);
                _movementImplementation.Execute();
                _taleMaker.Handle();
            }
  
            
        }

        public void Cleanup()
        {
            _snekView.OnContactWithWall -= Endgame;
            _snekView.OnContactWithBonus -= GatherBonus;
            _snekView.OnContactWithBonus -= _taleMaker.AddLink;


        }

        private void Endgame (IDie view)
        {
            if(!IsImmortal)
            {
                IsAlive = false;
            }
        }

        private void GatherBonus (IBonusView bonusView)
        {
            _count++;
            bonusView.Collect();

        }



    }
}