using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anemampojma
{
    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
        private int _lastFilled;

        public IntegerList()
        {
            _internalStorage = new int[4];
            _lastFilled = -1;
        }

        public IntegerList(int initialSize)
        {
            if (initialSize > 0)
            {
                _internalStorage = new int[initialSize];
                _lastFilled = -1;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void Add(int item)
        {
            if (_lastFilled < _internalStorage.Length)
            {
                int[] _newStorage = new int[2 * _internalStorage.Length];
                for (int i = 0; i < _internalStorage.Length; i++)
                {
                    _newStorage[i] = _internalStorage[i];
                }
                _lastFilled += 1;
                _newStorage[_lastFilled] = item;

            }
            else
            {
                _lastFilled += 1;
                _internalStorage[_lastFilled] = item;
            }

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


        public bool Remove(int item)
        {
            for (int i = 0; i < _lastFilled; i++)
            {
                if (item == _internalStorage[i])
                {
                    return RemoveAt(i);
                }
            }
            return false;
        }

        public int GetElement(int index)
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

        public int Count
        {
            get { return _lastFilled + 1; }
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < _lastFilled; i++)
            {
                if (item == _internalStorage[i])
                {
                    return i;
                }
            }
            return -1;
        }

        public void Clear()
        {
            for (int i = 0; i < _lastFilled; i++)
            {
                RemoveAt(i);
            }
            _lastFilled = -1;

        }

        public bool Contains(int item)
        {
            for (int i = 0; i < _lastFilled; i++)
            {
                if (item == _internalStorage[i])
                {
                    return true;
                }
            }
            return false;
        }

    }

}
