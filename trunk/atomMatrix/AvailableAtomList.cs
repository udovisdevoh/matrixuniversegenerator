using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace anticulturematrix
{
    class AvailableAtomList : IList<Atom>
    {
        #region Fields
        private List<Atom> internalList = new List<Atom>();

        private HashSet<Atom> internalSet = new HashSet<Atom>();
        #endregion

        #region Constructor
        public AvailableAtomList()
        {
            Add(new Atom(Color.Black));
            Add(new Atom(Color.White));
            Add(new Atom(Color.Red));
            Add(new Atom(Color.Green));
            Add(new Atom(Color.Blue));
            /*Add(new Atom(Color.Yellow));
            Add(new Atom(Color.Cyan));
            Add(new Atom(Color.Magenta));
            Add(new Atom(Color.Indigo));
            Add(new Atom(Color.Orange));*/
        }
        #endregion

        #region Public Methods
        public Atom GetRandomAtom()
        {
            if (internalList.Count < 1)
                throw new ArgumentException("Cannot return random value because the collection is empty");

            return internalList[Probabilities.Random.Next(0, internalList.Count)];
        }
        #endregion

        #region ICollection<Atom> Members
        public void Add(Atom item)
        {
            internalList.Add(item);
            internalSet.Add(item);
        }

        public void Clear()
        {
            internalList.Clear();
            internalSet.Clear();
        }

        public bool Contains(Atom item)
        {
            return internalSet.Contains(item);
        }

        public void CopyTo(Atom[] array, int arrayIndex)
        {
            internalList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return internalList.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Atom item)
        {
            return internalList.Remove(item) && internalSet.Remove(item);
        }
        #endregion

        #region IEnumerable<Atom> Members
        public IEnumerator<Atom> GetEnumerator()
        {
            return internalList.GetEnumerator();
        }
        #endregion

        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return internalList.GetEnumerator();
        }
        #endregion

        #region IList<Atom> Members
        public int IndexOf(Atom item)
        {
            return internalList.IndexOf(item);
        }

        public void Insert(int index, Atom item)
        {
            internalList.Insert(index, item);
            internalSet.Add(item);
        }

        public void RemoveAt(int index)
        {
            Atom item = internalList[index];
            internalList.RemoveAt(index);            
            if (!internalList.Contains(item))
                internalSet.Remove(item);
        }

        public Atom this[int index]
        {
            get
            {
                return internalList[index];
            }
            set
            {
                internalList[index] = value;
            }
        }
        #endregion
    }
}
