using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anemampojma
{
    public class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;
        private int _lastFilled;

        public GenericList() {
            _internalStorage = new X[4];
            _lastFilled = -1;
        }

        public GenericList(int initialSize) {
            if (initialSize > 0)
            {
                _internalStorage = new X[initialSize];
                _lastFilled = -1;
            }
            else {
                throw new ArgumentException();
            }

        }

        public int Count {
            get { return _lastFilled + 1; }
        }

        public void Add(X item)
        {
            if (_internalStorage.Length > _lastFilled)
            {
                X[] _newStorage = new X[2 * _internalStorage.Length];
                for (int i = 0; i < _internalStorage.Length; i++)
                {
                    _newStorage[i] = _internalStorage[i];
                }
                _lastFilled += 1;
                _newStorage[_lastFilled] = item;
            }
            else {
                _lastFilled += 1;
                _internalStorage[_lastFilled] = item;
            }
        }

        public void Clear()
        {
            for (int i = 0; i < _lastFilled; i++)
            {
                RemoveAt(i);
            }
            _lastFilled = -1;
        }

        public bool Contains(X item)
        {
            for (int i = 0; i < _lastFilled; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public X GetElement(int index)
        {
            if (index > _lastFilled || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return _internalStorage[index];
            }
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < _lastFilled; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Remove(X item)
        {
            for (int i = 0; i < _lastFilled; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return RemoveAt(i);
                }
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index > _lastFilled || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                for (int i = index; i < _lastFilled; i++)
                {
                    _internalStorage[i] = _internalStorage[i + 1];
                }
                _lastFilled -= 1;
                return true;
            }
        }

        public IEnumerator <X> GetEnumerator()
        {
            return new GenericListEnumerator <X> (this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
