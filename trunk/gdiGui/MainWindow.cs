using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace anticulturematrix
{
    public partial class MainWindow : Form
    {
        #region Constants
        public const int surfaceWidth = 640;

        public const int surfaceHeight = 480;
        #endregion

        #region Events
        public event EventHandler OnTimerTick;

        public new event EventHandler OnZoomIn;
        #endregion

        #region Public Methods
        public void ShowMatrix(AtomMatrix atomMatrix)
        {
            pictureBox.ShowMatrix(atomMatrix);
        }

        public void StartTimer()
        {
            timer.Start();
        }

        public Bounds GetBoundsFromClick(int x, int y, int width, int height)
        {
            x = (x * width) / surfaceWidth;
            y = (y * height) / surfaceHeight;

            int left = x - (width / 4);
            int right = x + (width / 4);
            int top = y - (height / 4);
            int bottom = y + (height / 4);

            if (left < 0)
            {
                right = (width / 2);
                left = 0;
            }
            else if (right >= width)
            {
                left = (width / 2);
                right = width - 1;
            }

            if (top < 0)
            {
                bottom = height / 2;
                top = 0;
            }
            else if (bottom >= height)
            {
                top = height / 2;
                bottom = height - 1;
            }

            Bounds bounds = new Bounds();
            bounds.Left = left;
            bounds.Right = right;
            bounds.Top = top;
            bounds.Bottom = bottom;

            return bounds;
        }

        public void ShowMatrixSet(AtomMatrixSet atomMatrixSet)
        {
            pictureBox.ShowMatrixSet(atomMatrixSet);
        }

        public Point SelectedMatrixPoint(int clickX, int clickY, AtomMatrixSet atomMatrixSet)
        {
            clickX *= atomMatrixSet.TotalWidth;
            clickX /= surfaceWidth;
            clickX /= atomMatrixSet.WidthPerMatrix;

            clickY *= atomMatrixSet.TotalHeight;
            clickY /= surfaceHeight;
            clickY /= atomMatrixSet.HeightPerMatrix;

            return new Point(clickX, clickY);
        }
        #endregion

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
            pictureBox.MouseDown += this.MouseZoomInHandler;
        }
        #endregion

        #region Handlers
        private void timer_Tick(object sender, EventArgs e)
        {
            if (OnTimerTick != null) OnTimerTick(sender, e);
        }

        private void MouseZoomInHandler(object sender, MouseEventArgs e)
        {
            if (OnZoomIn != null) OnZoomIn(sender, e);
        }
        #endregion
    }
}
