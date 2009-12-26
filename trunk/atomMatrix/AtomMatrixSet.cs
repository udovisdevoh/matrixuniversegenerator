using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace anticulturematrix
{
    /// <summary>
    /// Atom matrix set
    /// </summary>
    class AtomMatrixSet
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
        private AtomMatrix[,] internalMatrix;
        #endregion

        #region Constructors
        /// <summary>
        /// Create atom matrix set
        /// </summary>
        /// <param name="width">desired width</param>
        /// <param name="height">desired height</param>
        public AtomMatrixSet(int width, int height)
        {
            this.width = width;
            this.height = height;
            internalMatrix = new AtomMatrix[width, height];
        }
        #endregion

        #region Properties
        /// <summary>
        /// AtomMatrix in the set
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <returns>selected atom matrix</returns>
        public AtomMatrix this[int x, int y]
        {
            get
            {
                if (x >= width || y >= height || x < 0 || y < 0)
                    return null;

                return internalMatrix[x, y];
            }
            set { internalMatrix[x, y] = value; }
        }

        /// <summary>
        /// How many atom matrix in the set (width * height)
        /// </summary>
        public int Count
        {
            get { return width * height; }
        }
        #endregion
    }
}