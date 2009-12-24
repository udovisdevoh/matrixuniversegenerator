using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace anticulturematrix
{
    class AtomMatrixGenerator
    {
        #region Public Methods
        public AtomMatrix Build(int width, int height, AvailableAtomList availableAtomList, MarkovMatrix markovMatrix)
        {
            AtomMatrix atomMatrix = new AtomMatrix(width, height);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    atomMatrix[x, y] = GeneratePoint(x, y, atomMatrix, markovMatrix, availableAtomList);
                }
            }
            return atomMatrix;
        }

        public Atom GeneratePoint(int x, int y, AtomMatrix atomMatrix, MarkovMatrix markovMatrix, AvailableAtomList availableAtomList)
        {
            float[] row4 = null;
            float[] row6 = null;
            float[] row8 = null;
            float[] row2 = null;
            float[] currentRow = null;

            if (atomMatrix[x - 1, y] != null)
                row4 = markovMatrix.GetRow(atomMatrix[x - 1, y]);
            else
                row4 = null;

            if (atomMatrix[x, y - 1] != null)
                row8 = markovMatrix.GetRow(atomMatrix[x, y - 1]);
            else
                row8 = null;

            if (atomMatrix[x + 1, y] != null)
                row6 = markovMatrix.GetRow(atomMatrix[x + 1, y]);
            else
                row6 = null;

            if (atomMatrix[x, y + 1] != null)
                row2 = markovMatrix.GetRow(atomMatrix[x, y + 1]);
            else
                row2 = null;

            currentRow = RowMultiply(1.0f, availableAtomList.Count, row4, row6, row8, row2);
            return availableAtomList[Probabilities.GetPonderatedRandomKey(currentRow)];
        }
        #endregion

        #region Private Methods
        private float[] RowMultiply(float defaultNullValue, int size, float[] row1, float[] row2, float[] row3, float[] row4)
        {
            row2 = RowMultiply(defaultNullValue, size, row2, row3, row4);
            return RowMultiply(defaultNullValue, size, row1, row2);
        }

        private float[] RowMultiply(float defaultNullValue, int size, float[] row1, float[] row2, float[] row3)
        {
            row2 = RowMultiply(defaultNullValue, size, row2, row3);
            return RowMultiply(defaultNullValue, size, row1, row2);
        }

        private float[] RowMultiply(float defaultNullValue, int size, float[] row1, float[] row2)
        {
            float[] resultRow;

            if (row1 != null && row2 == null)
            {
                resultRow = row1;
            }
            else if (row1 == null && row2 != null)
            {
                resultRow = row2;
            }
            else if (row1 == null && row2 == null)
            {
                resultRow = new float[size];
                for (int i = 0; i < size; i++)
                    resultRow[i] = defaultNullValue;
            }
            else
            {
                resultRow = new float[size];
                for (int i = 0; i < size; i++)
                    resultRow[i] = row1[i] * row2[i];
            }

            return resultRow;
        }
        #endregion
    }
}
