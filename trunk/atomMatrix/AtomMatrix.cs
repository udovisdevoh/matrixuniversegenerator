using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace anticulturematrix
{
    public class AtomMatrix
    {
        #region Fields
        private int width;

        private int height;

        private Atom[,] internalMatrix;
        #endregion

        #region Constructors
        public AtomMatrix(int width, int height)
        {
            this.width = width;
            this.height = height;

            internalMatrix = new Atom[width, height];
        }
        #endregion

        #region Properties
        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public Atom this[int x, int y]
        {
            get
            {
                if (x >= width || y >= height || x < 0 || y < 0)
                    return null;

                return internalMatrix[x, y];
            }
            set{ internalMatrix[x, y] = value; }
        }

        public int Count
        {
            get { return width * height; }
        }
        #endregion
    }
}
