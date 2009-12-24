using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace anticulturematrix
{
    class AtomMatrixScaler
    {
        #region Public Methods
        public AtomMatrix Scale(AtomMatrix originalMatrix, Bounds bounds)
        {
            AtomMatrix scaledMatrix = new AtomMatrix(originalMatrix.Width, originalMatrix.Height);

            int scaledX, scaledY;

            for (int x = 0; x < originalMatrix.Width; x++)
            {
                for (int y = 0; y < originalMatrix.Height; y++)
                {
                    scaledX = bounds.Left + (x * bounds.Width / originalMatrix.Width);
                    scaledY = bounds.Top + (y * bounds.Height / originalMatrix.Height);

                    scaledMatrix[x, y] = originalMatrix[scaledX, scaledY];
                }
            }

            return scaledMatrix;
        }
        #endregion
    }
}