using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace anticulturematrix
{
    class MarkovMatrixMutator
    {
        public MarkovMatrix Mutate(MarkovMatrix markovMatrix, AtomMatrix atomMatrix)
        {
            for (int i = 0; i < markovMatrix.MatrixSize; i++)
            {
                if (Probabilities.Random.Next(0, markovMatrix.MatrixSize) == 1)
                {
                    int j = markovMatrix.GetRowMax(i);
                    markovMatrix[i, j] = markovMatrix[j, i] = (float)Probabilities.Random.NextDouble();
                }
            }

            return markovMatrix;
        }
    }
}
