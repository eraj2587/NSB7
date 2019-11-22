using System.Collections;
using System.Collections.Generic;
namespace NSB.Utilities.Common
{
    public class ConcurrentList<T> : IList<T>
    {
        private List<T> _list;
        private readonly object _lock = new object();
        public List<T> Clone()
        {
            List<T> newList = new List<T>();

            lock (_lock)
            {
                _list.ForEach(x => newList.Add(x));
            }

            return newList;
        }
        public ConcurrentList()
        {
            _list = new List<T>();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Clone().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Clone().GetEnumerator();
        }

        public void Add(T item)
        {
            lock (_lock)
            {
                _list.Add(item);
            }
        }

        public void Clear()
        {
            lock (_lock)
            {
                _list.Clear();
            }
        }

        public bool Contains(T item)
        {
            bool isPresent = false;
            lock (_lock)
            {
                isPresent = _list.Contains(item);
            }
            return isPresent;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            lock (_lock)
            {
                _list.CopyTo(array, arrayIndex);
            }
        }

        public bool Remove(T item)
        {
            bool isRemoved = false;
            lock (_lock)
            {
                isRemoved = _list.Remove(item);
            }
            return isRemoved;
        }

        public int Count
        {
            get
            {
                int count;

                lock (_lock)
                {
                    count = _list.Count;
                }

                return (count);
            }
        }
        public bool IsReadOnly { get { return false; } }
        public int IndexOf(T item)
        {

            lock (_lock)
            {
                return _list.IndexOf(item);
            }
        }

        public void Insert(int index, T item)
        {
            lock (_lock)
            {
                _list.Insert(index, item);
            }
        }

        public void RemoveAt(int index)
        {
            lock (_lock)
            {
                _list.RemoveAt(index);
            }
        }

        public T this[int index]
        {
            get
            {
                lock (_lock)
                {
                    return _list[index];
                }

            }
            set
            {
                lock (_lock)
                {
                    _list[index] = value;
                }
            }
        }
    }
}
