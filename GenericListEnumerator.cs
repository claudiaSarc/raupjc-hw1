using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anemampojma
{

    class GenericListEnumerator<X> : IEnumerator<X>
    {
        private GenericList<X> genericList;
        private int _lastFilled;

        public GenericListEnumerator()
        {

        }

        public GenericListEnumerator(GenericList<X> genericList) {
            this.genericList = genericList;
            _lastFilled = -1;
        }

        public X Current {
            get { return genericList.GetElement(_lastFilled); }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext() {
            if (_lastFilled < genericList.Count) {
                _lastFilled += 1;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
