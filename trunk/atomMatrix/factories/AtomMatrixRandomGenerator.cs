using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace anticulturematrix
{
    class AtomMatrixRandomGenerator
    {
        public AtomMatrix Build(int width, int height, AvailableAtomList availableAtomList)
        {
            AtomMatrix atomMatrix = new AtomMatrix(width,height);

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    atomMatrix[i, j] = availableAtomList.GetRandomAtom();

            return atomMatrix;
        }
    }
}
