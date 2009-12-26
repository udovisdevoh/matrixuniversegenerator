using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace anticulturematrix
{
    /// <summary>
    /// Markov Matrix Set
    /// </summary>
    class MarkovMatrixSet
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
        private MarkovMatrix[,] internalMatrix;
        #endregion

        #region Constructors
        /// <summary>
        /// Create markov matrix set
        /// </summary>
        /// <param name="width">desired size</param>
        /// <param name="height">desired height</param>
        public MarkovMatrixSet(int width, int height)
        {
            this.width = width;
            this.height = height;
            internalMatrix = new MarkovMatrix[width, height];
        }
        #endregion

        #region Properties
        /// <summary>
        /// MarkovMatrix in the set
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <returns>selected markov matrix</returns>
        public MarkovMatrix this[int x, int y]
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
        /// How many markov matrix in the set (width * height)
        /// </summary>
        public int Count
        {
            get { return width * height; }
        }

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
        /// Matrix in the center
        /// </summary>
        public MarkovMatrix CenterMatrix
        {
            get
            {
                int x = width / 2;
                int y = height / 2;
                return this[x, y];
            }

            set
            {
                int x = width / 2;
                int y = height / 2;
                this[x, y] = value;
            }
        }
        #endregion
    }
}
