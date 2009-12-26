using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace anticulturematrix
{
    /// <summary>
    /// Atom matrix
    /// </summary>
    public class AtomMatrix
    {
        #region Fields
        /// <summary>
        /// Width
        /// </summary>
        private int width;

        /// <summary>
        /// Height
        /// </summary>
        private int height;

        /// <summary>
        /// Internal matrix
        /// </summary>
        private Atom[,] internalMatrix;
        #endregion

        #region Constructors
        /// <summary>
        /// Create atom matrix
        /// </summary>
        /// <param name="width">desired width</param>
        /// <param name="height">desired height</param>
        public AtomMatrix(int width, int height)
        {
            this.width = width;
            this.height = height;

            internalMatrix = new Atom[width, height];
        }
        #endregion

        #region Properties
        /// <summary>
        /// Width
        /// </summary>
        public int Width
        {
            get { return width; }
        }

        /// <summary>
        /// Height
        /// </summary>
        public int Height
        {
            get { return height; }
        }

        /// <summary>
        /// Atom in the matrix
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <returns>atom</returns>
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

        /// <summary>
        /// How many atom in the matrix (width * height)
        /// </summary>
        public int Count
        {
            get { return width * height; }
        }
        #endregion
    }
}
