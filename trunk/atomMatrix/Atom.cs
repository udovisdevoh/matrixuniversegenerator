using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace anticulturematrix
{
    public class Atom
    {
        #region Fields
        private Color color;

        private int id;
        #endregion

        #region Static
        private static int idCounter = 0;
        #endregion

        #region Constructor
        public Atom(Color color)
        {
            this.color = color;
            this.id = idCounter;
            idCounter++;
        }
        #endregion

        #region Properties
        public Color Color
        {
            get { return color; }
        }

        public int Id
        {
            get { return id; }
        }
        #endregion
    }
}
