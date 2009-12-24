using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace anticulturematrix
{
    public class Bounds
    {
        #region Fields
        private int left = 0;

        private int right = 0;

        private int top = 0;

        private int bottom = 0;
        #endregion

        #region Properties
        public int Left
        {
            get { return left; }
            set { left = value; }
        }

        public int Right
        {
            get { return right; }
            set { right = value; }
        }

        public int Top
        {
            get { return top; }
            set { top = value; }
        }

        public int Bottom
        {
            get { return bottom; }
            set { bottom = value; }
        }
        #endregion
    }
}
