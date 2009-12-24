using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace anticulturematrix
{
    class Program
    {
        #region Fields
        private MainWindow mainWindow;

        private AvailableAtomList availableAtomList = new AvailableAtomList();

        private AtomMatrixRandomGenerator atomMatrixRandomGenerator = new AtomMatrixRandomGenerator();

        private AtomMatrixMarkovGenerator atomMatrixMarkovGenerator = new AtomMatrixMarkovGenerator();

        private MatrixMutatorRandom matrixMutatorRandom = new MatrixMutatorRandom();

        private MarkovMatrixGenerator markovMatrixGenerator = new MarkovMatrixGenerator();

        private MatrixMutatorMarkov matrixMutatorMarkov = new MatrixMutatorMarkov();

        private AtomMatrixScaler atomMatrixScaler = new AtomMatrixScaler();

        private MarkovMatrixSampler markovMatrixSampler = new MarkovMatrixSampler();

        private MarkovMatrixMutator markovMatrixMutator = new MarkovMatrixMutator();

        private AtomMatrix currentAtomMatrix;

        private MarkovMatrix currentMarkovMatrix;
        #endregion

        #region Constructor
        public Program()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainWindow = new MainWindow();
            currentMarkovMatrix = markovMatrixGenerator.Build(availableAtomList);

            mainWindow.OnTimerTick += TimerTickHandler;
            mainWindow.OnZoomIn += ZoomInHandler;
        }
        #endregion

        #region Handlers
        public void TimerTickHandler(object sender, EventArgs e)
        {
            if (currentAtomMatrix == null)
                currentAtomMatrix = atomMatrixMarkovGenerator.Build(32, 24, availableAtomList, currentMarkovMatrix);
            else
                matrixMutatorMarkov.Mutate(currentAtomMatrix, 0.05f, availableAtomList, currentMarkovMatrix, atomMatrixMarkovGenerator);

            mainWindow.ShowMatrix(currentAtomMatrix);
        }

        public void ZoomInHandler(object sender, EventArgs e)
        {
            MouseEventArgs mouseEventArgs = (MouseEventArgs)e;
            if (currentAtomMatrix != null)
            {
                Bounds bounds = mainWindow.GetBoundsFromClick(mouseEventArgs.X, mouseEventArgs.Y, currentAtomMatrix.Width, currentAtomMatrix.Height);
                
                currentMarkovMatrix = markovMatrixSampler.Sample(currentAtomMatrix, bounds, availableAtomList);
                //currentMarkovMatrix = markovMatrixMutator.Mutate(currentMarkovMatrix);

                currentAtomMatrix = atomMatrixScaler.Scale(currentAtomMatrix, bounds);
                matrixMutatorMarkov.Mutate(currentAtomMatrix, 0.5f, availableAtomList, currentMarkovMatrix, atomMatrixMarkovGenerator);
            }
        }
        #endregion

        #region Private Methods
        private void Start()
        {
            mainWindow.StartTimer();
            Application.Run(mainWindow);
        }
        #endregion

        #region Main
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Program program = new Program();
            program.Start();
        }
        #endregion
    }
}
