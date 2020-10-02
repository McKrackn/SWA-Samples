using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SWA.Draughts.Final.Model;

namespace SWA.Draughts.Final
{
    public class InitializableReadonlyCollection<T> : IEnumerable<T>
    {
        private List<T> _internalCollection = new List<T>();

        private bool _initializationFinished = false;

        public void Add(T item)
        {
            if (!this._initializationFinished)
            {
                _internalCollection.Add(item);
            }
            else
            {
                throw new InvalidOperationException("Initialization Phase finished... Operation not allowed");
            }
        }

        public void SetInitializationFinished()
        {
            _initializationFinished = true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this._internalCollection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this._internalCollection).GetEnumerator();
        }
    }
}
