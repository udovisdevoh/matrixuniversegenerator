using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace anticulturematrix
{
    static class Probabilities
    {
        #region Fields
        private static Random random = new Random();
        #endregion

        #region Properties
        public static Random Random
        {
            get { return random; }
        }
        #endregion

        #region Public Methods
        public static int GetPonderatedRandomKey(float[] row)
        {
            float sum = Sum(row);

            float randomFloat = (float)(Random.NextDouble()) * sum;

            float floatCounter = 0.0f;
            int intCounter = 0;
            foreach (float floatNumber in row)
            {
                floatCounter += floatNumber;
                if (floatCounter >= randomFloat)
                {
                    return intCounter;
                }
                intCounter++;
            }

            throw new NotImplementedException();
        }

        private static float Sum(float[] row)
        {
            float sum = 0.0f;
            foreach (float number in row)
                sum += number;
            return sum;
        }
        #endregion
    }
}
