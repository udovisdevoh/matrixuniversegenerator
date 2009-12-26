using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace anticulturematrix
{
    /// <summary>
    /// Markov matrix
    /// </summary>
    class MarkovMatrix
    {
        #region Fields
        /// <summary>
        /// Internal matrix
        /// </summary>
        private float[,] internalMatrix;

        /// <summary>
        /// Matrix size (width or height)
        /// </summary>
        private int matrixSize;
        #endregion

        #region Constructors
        /// <summary>
        /// Create markov matrix
        /// </summary>
        /// <param name="matrixSize">desired size (width or height)</param>
        public MarkovMatrix(int matrixSize)
        {
            this.matrixSize = matrixSize;
            internalMatrix = new float[matrixSize, matrixSize];
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Get row for atom type
        /// </summary>
        /// <param name="atom">atom</param>
        /// <returns>row for atom type</returns>
        public float[] GetRow(Atom atom)
        {
            float[] row = new float[matrixSize];
            for (int i = 0; i < matrixSize; i++)
                row[i] = internalMatrix[atom.Id, i];
            return row;
        }

        /// <summary>
        /// Maximum key in specified row
        /// </summary>
        /// <param name="rowId">rowId</param>
        /// <returns>Maximum key in specified row</returns>
        public int GetRowMax(int rowId)
        {
            int maxKey = -1;
            float maxValue = -1.0f;

            for (int j = 0; j < matrixSize; j++)
            {
                if (maxKey == -1 || internalMatrix[rowId, j] > maxValue)
                {
                    maxKey = j;
                    maxValue = internalMatrix[rowId, j];
                }
            }
            return maxKey;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Value at specified coordinates
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <returns>Value at specified coordinates</returns>
        public float this[int x, int y]
        {
            get { return internalMatrix[x, y]; }
            set { internalMatrix[x, y] = value; }
        }

        /// <summary>
        /// Matrix size (height or width)
        /// </summary>
        public int MatrixSize
        {
            get { return matrixSize; }
        }
        #endregion
    }
}
