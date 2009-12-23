using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace anticulturematrix
{
    class MarkovMatrix
    {
        #region Fields
        private float[,] internalMatrix;

        private int matrixSize;
        #endregion

        #region Constructors
        public MarkovMatrix(int matrixSize)
        {
            this.matrixSize = matrixSize;
            internalMatrix = new float[matrixSize, matrixSize];
        }
        #endregion

        #region Public Methods
        public float[] GetRow(Atom atom)
        {
            float[] row = new float[matrixSize];
            for (int i = 0; i < matrixSize; i++)
                row[i] = internalMatrix[atom.Id, i];
            return row;
        }
        #endregion

        #region Properties
        public float this[int x, int y]
        {
            get { return internalMatrix[x, y]; }
            set { internalMatrix[x, y] = value; }
        }
        #endregion
    }
}
