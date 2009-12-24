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
            int scaledWidth = bounds.Right - bounds.Left;
            int scaledHeight = bounds.Bottom - bounds.Top;

            AtomMatrix scaledMatrix = new AtomMatrix(originalMatrix.Width, originalMatrix.Height);

            int scaledX, scaledY;

            for (int x = 0; x < originalMatrix.Width; x++)
            {
                for (int y = 0; y < originalMatrix.Height; y++)
                {
                    scaledX = bounds.Left + (x * scaledWidth / originalMatrix.Width);
                    scaledY = bounds.Top + (y * scaledHeight / originalMatrix.Height);

                    scaledMatrix[x, y] = originalMatrix[scaledX, scaledY];
                }
            }

            return scaledMatrix;
        }
        #endregion
    }
}