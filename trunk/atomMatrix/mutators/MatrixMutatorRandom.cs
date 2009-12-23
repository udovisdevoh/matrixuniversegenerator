﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace anticulturematrix
{
    class MatrixMutatorRandom
    {
        public void Mutate(AtomMatrix atomMatrix, float ratioToMutate, AvailableAtomList availableAtomList)
        {
            int totalCountToMutate = (int)(ratioToMutate * (float)(atomMatrix.Count));

            int x, y;
            for (int i = 0; i < totalCountToMutate; i++)
            {
                x = Probabilities.Random.Next(0, atomMatrix.Width);
                y = Probabilities.Random.Next(0, atomMatrix.Height);

                atomMatrix[x, y] = availableAtomList.GetRandomAtom();
            }
        }
    }
}