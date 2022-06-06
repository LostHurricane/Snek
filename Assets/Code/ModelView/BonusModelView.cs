using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVVMSnek
{
    public class BonusModelView : IModelView
    {
        private IBonusView _bonusView;

        public void SetDependancies(IGameObject view)
        {
            if (view is IBonusView bonusView)
            {
                _bonusView = bonusView;
            }
            _bonusView.OnCollection += MoveBonus;
        }



        public void MoveBonus(IBonusView bonusView)
        {
            var x = Random.Range(-8, 8);
            var y = Random.Range(-4, 4);

            bonusView.GameObject.transform.position = new Vector3(x, y);
        }

        public void Cleanup()
        {
            _bonusView.OnCollection -= MoveBonus;

        }
    }
}
