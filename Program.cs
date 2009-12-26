using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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

            markovMatrixSet = new MarkovMatrixSet(colCount, rowCount);
            markovMatrixSet.CenterMatrix = markovMatrixGenerator.Build(availableAtomList);

            for (int x = 0; x < markovMatrixSet.Width; x++)
                for (int y = 0; y < markovMatrixSet.Height; y++)
                    if (markovMatrixSet[x,y] != markovMatrixSet.CenterMatrix)
                        markovMatrixSet[x,y] = markovMatrixMutator.Mutate(markovMatrixSet.CenterMatrix, 0.1f);

            atomMatrixSet = new AtomMatrixSet(colCount, rowCount);
            for (int x = 0; x < markovMatrixSet.Width; x++)
                for (int y = 0; y < markovMatrixSet.Height; y++)
                    atomMatrixSet[x, y] = atomMatrixGenerator.Build(48, 36, availableAtomList, markovMatrixSet[x,y]);           

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
            /*
            MouseEventArgs mouseEventArgs = (MouseEventArgs)e;

            Bounds bounds = mainWindow.GetBoundsFromClick(mouseEventArgs.X, mouseEventArgs.Y, currentAtomMatrix.Width, currentAtomMatrix.Height);

            currentAtomMatrix = atomMatrixScaler.Scale(currentAtomMatrix, bounds);
            
            atomMatrixMutator.Mutate(currentAtomMatrix, 1.0f, availableAtomList, currentMarkovMatrix, atomMatrixGenerator);
            */
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