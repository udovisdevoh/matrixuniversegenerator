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

        private AtomMatrixGenerator atomMatrixGenerator = new AtomMatrixGenerator();

        private MarkovMatrixGenerator markovMatrixGenerator = new MarkovMatrixGenerator();

        private AtomMatrixMutator atomMatrixMutator = new AtomMatrixMutator();

        private AtomMatrixScaler atomMatrixScaler = new AtomMatrixScaler();

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
                currentAtomMatrix = atomMatrixGenerator.Build(64, 48, availableAtomList, currentMarkovMatrix);
            else
                atomMatrixMutator.Mutate(currentAtomMatrix, 0.05f, availableAtomList, currentMarkovMatrix, atomMatrixGenerator);

            mainWindow.ShowMatrix(currentAtomMatrix);
        }

        public void ZoomInHandler(object sender, EventArgs e)
        {
            MouseEventArgs mouseEventArgs = (MouseEventArgs)e;
            if (currentAtomMatrix != null)
            {
                Bounds bounds = mainWindow.GetBoundsFromClick(mouseEventArgs.X, mouseEventArgs.Y, currentAtomMatrix.Width, currentAtomMatrix.Height);

                currentAtomMatrix = atomMatrixScaler.Scale(currentAtomMatrix, bounds);
                
                atomMatrixMutator.Mutate(currentAtomMatrix, 1.0f, availableAtomList, currentMarkovMatrix, atomMatrixGenerator);
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
