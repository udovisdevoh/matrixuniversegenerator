﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace anticulturematrix
{
    /// <summary>
    /// Atom matrix set
    /// </summary>
    public class AtomMatrixSet
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

        public int WidthPerMatrix
        {
            get
            {
                return internalMatrix[0, 0].Width;
            }
        }

        public int HeightPerMatrix
        {
            get
            {
                return internalMatrix[0, 0].Height;
            }
        }

        /// <summary>
        /// Total width (pixels)
        /// </summary>
        public int TotalWidth
        {
            get { return WidthPerMatrix * width; }
        }

        /// <summary>
        /// Total height (pixels)
        /// </summary>
        public int TotalHeight
        {
            get { return HeightPerMatrix * height; }
        }
        #endregion
    }
}