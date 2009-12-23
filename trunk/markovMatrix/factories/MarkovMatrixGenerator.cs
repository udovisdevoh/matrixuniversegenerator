using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace anticulturematrix
{
    class MarkovMatrixGenerator
    {
        public MarkovMatrix Build(AvailableAtomList availableAtomList)
        {
            MarkovMatrix markovMatrix = new MarkovMatrix(availableAtomList.Count);

            for (int x = 0; x < availableAtomList.Count; x++)
            {
                for (int y = 0; y < availableAtomList.Count; y++)
                {
                    markovMatrix[x, y] = (float)(Probabilities.Random.NextDouble());
                    markovMatrix[y, x] = (float)(Probabilities.Random.NextDouble());
                }
            }

            return markovMatrix;
        }
    }
}
