using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace anticulturematrix
{
    /// <summary>
    /// Main program's controller
    /// </summary>
    class Program
    {
        #region Constants
        private const int rowCount = 3;

        private const int colCount = 3;

        private const int singleMatrixWidth = 48;

        private const int singleMatrixHeight = 36;
        #endregion

        #region Fields
        private MainWindow mainWindow;

        private AtomMatrixSet atomMatrixSet;

        private MarkovMatrixSet markovMatrixSet;

        private AvailableAtomList availableAtomList = new AvailableAtomList();

        private AtomMatrixGenerator atomMatrixGenerator = new AtomMatrixGenerator();

        private MarkovMatrixGenerator markovMatrixGenerator = new MarkovMatrixGenerator();

        private AtomMatrixMutator atomMatrixMutator = new AtomMatrixMutator();

        private AtomMatrixScaler atomMatrixScaler = new AtomMatrixScaler();

        private MarkovMatrixMutator markovMatrixMutator = new MarkovMatrixMutator();
        #endregion

        #region Constructor
        public Program()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainWindow = new MainWindow();

            atomMatrixSet = new AtomMatrixSet(colCount, rowCount);

            markovMatrixSet = new MarkovMatrixSet(colCount, rowCount);
            markovMatrixSet.CenterMatrix = markovMatrixGenerator.Build(availableAtomList);

            markovMatrixMutator.RegenerateSideMarkovMatrixes(markovMatrixSet);
            atomMatrixSet = atomMatrixGenerator.BuildAtomMatrixSet(markovMatrixSet,singleMatrixWidth,singleMatrixHeight,availableAtomList);

            mainWindow.OnTimerTick += TimerTickHandler;
            mainWindow.OnZoomIn += ZoomInHandler;
        }
        #endregion

        #region Handlers
        public void TimerTickHandler(object sender, EventArgs e)
        {
            atomMatrixMutator.Mutate(atomMatrixSet, 0.05f, availableAtomList, markovMatrixSet, atomMatrixGenerator);
            mainWindow.ShowMatrixSet(atomMatrixSet);
        }

        public void ZoomInHandler(object sender, EventArgs e)
        {
            MouseEventArgs mouseEventArgs = (MouseEventArgs)e;

            Point point = mainWindow.SelectedMatrixPoint(mouseEventArgs.X, mouseEventArgs.Y, atomMatrixSet);

            markovMatrixSet.CenterMatrix = markovMatrixSet[point.X, point.Y];

            markovMatrixMutator.RegenerateSideMarkovMatrixes(markovMatrixSet);
            atomMatrixSet = atomMatrixGenerator.BuildAtomMatrixSet(markovMatrixSet, singleMatrixWidth, singleMatrixHeight, availableAtomList);

            //currentAtomMatrix = atomMatrixScaler.Scale(currentAtomMatrix, bounds);
            //atomMatrixMutator.Mutate(currentAtomMatrix, 1.0f, availableAtomList, currentMarkovMatrix, atomMatrixGenerator);
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