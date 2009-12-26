using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace anticulturematrix
{
    /// <summary>
    /// Atom (colored pixel) in the matrix
    /// </summary>
    public class Atom
    {
        #region Fields
        /// <summary>
        /// Color
        /// </summary>
        private Color color;

        /// <summary>
        /// Type Id
        /// </summary>
        private int id;
        #endregion

        #region Static
        /// <summary>
        /// Id counter
        /// </summary>
        private static int idCounter = 0;
        #endregion

        #region Constructor
        /// <summary>
        /// Create an atom
        /// </summary>
        /// <param name="color">desired color</param>
        public Atom(Color color)
        {
            this.color = color;
            this.id = idCounter;
            idCounter++;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Color
        /// </summary>
        public Color Color
        {
            get { return color; }
        }

        /// <summary>
        /// Type id
        /// </summary>
        public int Id
        {
            get { return id; }
        }
        #endregion
    }
}
