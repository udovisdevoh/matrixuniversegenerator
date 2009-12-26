using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace anticulturematrix
{
    /// <summary>
    /// Atom matrix mutator
    /// </summary>
    class AtomMatrixMutator
    {
        #region Public Methods
        /// <summary>
        /// Mutate an atom matrix
        /// </summary>
        /// <param name="atomMatrix">atom matrix to mutate</param>
        /// <param name="ratioToMutate">ratio of atom to mutate</param>
        /// <param name="availableAtomList">available atom list</param>
        /// <param name="markovMatrix">markov matrix to use</param>
        /// <param name="atomMatrixMarkovGenerator">markov matrix generator to use</param>
        public void Mutate(AtomMatrix atomMatrix, float ratioToMutate, AvailableAtomList availableAtomList, MarkovMatrix markovMatrix, AtomMatrixGenerator atomMatrixMarkovGenerator)
        {
            int totalCountToMutate = (int)(ratioToMutate * (float)(atomMatrix.Count));

            int x, y;
            for (int i = 0; i < totalCountToMutate; i++)
            {
                x = Probabilities.Random.Next(0, atomMatrix.Width);
                y = Probabilities.Random.Next(0, atomMatrix.Height);

                atomMatrix[x, y] = atomMatrixMarkovGenerator.GeneratePoint(x, y, atomMatrix, markovMatrix, availableAtomList);
            }
        }

        /// <summary>
        /// Mutate an atom matrix set
        /// </summary>
        /// <param name="atomMatrixSet">atom matrix set</param>
        /// <param name="ratioToMutate">ratio to mutate</param>
        /// <param name="availableAtomList">available atom list</param>
        /// <param name="markovMatrixSet">markov matrix set to use</param>
        /// <param name="atomMatrixGenerator">markov matrix generator to use</param>
        public void Mutate(AtomMatrixSet atomMatrixSet, float ratioToMutate, AvailableAtomList availableAtomList, MarkovMatrixSet markovMatrixSet, AtomMatrixGenerator atomMatrixGenerator)
        {
            for (int x = 0; x < atomMatrixSet.Width; x++)
                for (int y = 0; y < atomMatrixSet.Height; y++)
                   Mutate(atomMatrixSet[x, y], ratioToMutate,availableAtomList, markovMatrixSet[x, y], atomMatrixGenerator);
        }
        #endregion
    }
}