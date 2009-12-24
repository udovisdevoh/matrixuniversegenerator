using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace anticulturematrix
{
    class MarkovMatrixSampler
    {
        #region Public Methods
        public MarkovMatrix Sample(AtomMatrix atomMatrix, Bounds bounds, AvailableAtomList availableAtomList)
        {
            float elementScalar = 2.0f / (float)(bounds.Width * bounds.Height);
            MarkovMatrix markovMatrix = new MarkovMatrix(availableAtomList.Count);

            for (int x = bounds.Left; x <= bounds.Right; x++)
            {
                for (int y = bounds.Top; y <= bounds.Bottom; y++)
                {
                    if (x - 1 >= bounds.Left)
                        AddStats(markovMatrix, atomMatrix[x - 1, y], atomMatrix[x, y], elementScalar);
                    if (x + 1 <= bounds.Right)
                        AddStats(markovMatrix, atomMatrix[x, y], atomMatrix[x + 1, y], elementScalar);
                    if (y - 1 >= bounds.Top)
                        AddStats(markovMatrix, atomMatrix[x, y - 1], atomMatrix[x, y], elementScalar);
                    if (y + 1 <= bounds.Bottom)
                        AddStats(markovMatrix, atomMatrix[x, y], atomMatrix[x, y + 1], elementScalar);

                }
            }

            for (int i = 0; i < availableAtomList.Count; i++)
            {
                for (int j = 0; j < availableAtomList.Count; j++)
                {
                    if (markovMatrix[i, j] <= 0.0001f || markovMatrix[j, i] <= 0.0001f)
                    {
                        markovMatrix[i, j] = (float)Probabilities.Random.NextDouble();
                        markovMatrix[j, i] = markovMatrix[i, j];
                    }
                }
            }



            return markovMatrix;
        }

        private void AddStats(MarkovMatrix markovMatrix, Atom atom1, Atom atom2, float scalarToAdd)
        {
            markovMatrix[atom1.Id, atom2.Id] += scalarToAdd;
            markovMatrix[atom2.Id, atom1.Id] += scalarToAdd;
        }
        #endregion
    }
}
