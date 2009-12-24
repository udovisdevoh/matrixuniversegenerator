using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace anticulturematrix
{
    /// <summary>
    /// Atom matrix generator
    /// </summary>
    class AtomMatrixGenerator
    {
        #region Public Methods
        /// <summary>
        /// Build atom matrix
        /// </summary>
        /// <param name="width">desired width</param>
        /// <param name="height">desired height</param>
        /// <param name="availableAtomList">available atom list</param>
        /// <param name="markovMatrix">markov matrix</param>
        /// <returns>new atom matrix</returns>
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

        /// <summary>
        /// Generate point
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <param name="atomMatrix">atom matrix</param>
        /// <param name="markovMatrix">markov matrix to use</param>
        /// <param name="availableAtomList">available atom list</param>
        /// <returns></returns>
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
        /// <summary>
        /// Multiply probabilities of 4 rows
        /// </summary>
        /// <param name="defaultNullValue">default null value</param>
        /// <param name="size">size of the rows</param>
        /// <param name="row1">row 1</param>
        /// <param name="row2">row 2</param>
        /// <param name="row3">row 3</param>
        /// <param name="row4">row 4</param>
        /// <returns>Product of two rows</returns>
        private float[] RowMultiply(float defaultNullValue, int size, float[] row1, float[] row2, float[] row3, float[] row4)
        {
            row2 = RowMultiply(defaultNullValue, size, row2, row3, row4);
            return RowMultiply(defaultNullValue, size, row1, row2);
        }

        /// <summary>
        /// Multiply probabilities of 3 rows
        /// </summary>
        /// <param name="defaultNullValue">default null value</param>
        /// <param name="size">size of the rows</param>
        /// <param name="row1">row 1</param>
        /// <param name="row2">row 2</param>
        /// <param name="row3">row 3</param>
        /// <returns>Product of two rows</returns>
        private float[] RowMultiply(float defaultNullValue, int size, float[] row1, float[] row2, float[] row3)
        {
            row2 = RowMultiply(defaultNullValue, size, row2, row3);
            return RowMultiply(defaultNullValue, size, row1, row2);
        }

        /// <summary>
        /// Multiply probabilities of 2 rows
        /// </summary>
        /// <param name="defaultNullValue">default null value</param>
        /// <param name="size">size of the rows</param>
        /// <param name="row1">row 1</param>
        /// <param name="row2">row 2</param>
        /// <returns>Product of two rows</returns>
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
