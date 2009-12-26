using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace anticulturematrix
{
    class MarkovMatrixMutator
    {
        public MarkovMatrix Mutate(MarkovMatrix originalMatrix, float mutationRate)
        {
            MarkovMatrix mutatedMatrix = new MarkovMatrix(originalMatrix.MatrixSize);
            float randomFloat;

            for (int i = 0; i < originalMatrix.MatrixSize; i++)
            {
                for (int j = 0; j < originalMatrix.MatrixSize; j++)
                {
                    randomFloat = (float)Probabilities.Random.NextDouble();

                    if (randomFloat <= (mutationRate / 2.0f))
                    {
                        mutatedMatrix[i, j] = (float)Probabilities.Random.NextDouble();
                        mutatedMatrix[j, i] = mutatedMatrix[i, j];
                    }
                    else
                    {
                        mutatedMatrix[i, j] = originalMatrix[i, j];
                    }
                }
            }
                    

            return mutatedMatrix;
        }
    }
}
