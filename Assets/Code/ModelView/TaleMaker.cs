using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVVMSnek
{
    public class TaleMaker
    {
        private ChainFactory _chainFactory;
        private ChainLink _chainLink;


        public TaleMaker (ChainFactory chainFactory, Transform firstLink)
        {
            _chainFactory = chainFactory;
            _chainLink = new ChainLink(firstLink);
            AddLink(null);
        }

        public void Handle()
        {
            _chainLink.Handle();
        }

        public void AddLink (IBonusView _)
        {
            var link = _chainFactory.Produce(_chainLink.LastLink.position, _chainLink.LastLink.rotation);
            _chainLink.SetNext(new ChainLink(link.transform));
        }

    }
}
