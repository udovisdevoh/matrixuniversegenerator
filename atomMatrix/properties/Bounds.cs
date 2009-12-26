using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace anticulturematrix
{
    /// <summary>
    /// Represents a selection bounds
    /// </summary>
    public class Bounds
    {
        #region Fields
        /// <summary>
        /// Left bound
        /// </summary>
        private int left = 0;

        /// <summary>
        /// Right bound
        /// </summary>
        private int right = 0;

        /// <summary>
        /// Top bound
        /// </summary>
        private int top = 0;

        /// <summary>
        /// Bottom bound
        /// </summary>
        private int bottom = 0;
        #endregion

        #region Properties
        /// <summary>
        /// Left bound
        /// </summary>
        public int Left
        {
            get { return left; }
            set { left = value; }
        }

        /// <summary>
        /// Right bound
        /// </summary>
        public int Right
        {
            get { return right; }
            set { right = value; }
        }

        /// <summary>
        /// Top bound
        /// </summary>
        public int Top
        {
            get { return top; }
            set { top = value; }
        }

        /// <summary>
        /// Bottom bound
        /// </summary>
        public int Bottom
        {
            get { return bottom; }
            set { bottom = value; }
        }

        /// <summary>
        /// Width
        /// </summary>
        public int Width
        {
            get { return right - left + 1; }
        }

        /// <summary>
        /// Height
        /// </summary>
        public int Height
        {
            get { return bottom - top + 1; }
        }
        #endregion
    }
}
