using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace anticulturematrix
{
    /// <summary>
    /// Used for probabilities and random number generators
    /// </summary>
    static class Probabilities
    {
        #region Fields
        /// <summary>
        /// Random number generator
        /// </summary>
        private static Random random = new Random();
        #endregion

        #region Public Methods
        /// <summary>
        /// Get ponderated ranom key from row
        /// </summary>
        /// <param name="row">matrix row</param>
        /// <returns>ponderated ranom key from row</returns>
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

        /// <summary>
        /// Sum of matrix row values
        /// </summary>
        /// <param name="row">matrix row</param>
        /// <returns>Sum of matrix row values</returns>
        private static float Sum(float[] row)
        {
            float sum = 0.0f;
            foreach (float number in row)
                sum += number;
            return sum;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Random number generator
        /// </summary>
        public static Random Random
        {
            get { return random; }
        }
        #endregion
    }
}
