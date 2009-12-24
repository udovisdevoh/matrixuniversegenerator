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
    public class MainWindow : Form
    {
        #region Constants
        public const int surfaceWidth = 640;

        public const int surfaceHeight = 480;
        #endregion

        #region Fields
        private IContainer components = null;

        private PixelPanel pixelPanel;

        private Timer timer;
        #endregion

        #region Constructor
        public MainWindow()
        {
            pixelPanel = new PixelPanel(surfaceWidth, surfaceHeight);
            pixelPanel.MouseDown += this.MouseZoomInHandler;
            InitializeComponent();
        }
        #endregion

        #region Events
        public event EventHandler OnTimerTick;

        public new event EventHandler OnZoomIn;
        #endregion

        #region Public Methods
        public void ShowMatrix(AtomMatrix atomMatrix)
        {
            pixelPanel.ShowMatrix(atomMatrix);
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
        #endregion

        #region Private Methods
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pixelPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // pixelPanel
            // 
            this.pixelPanel.Location = new System.Drawing.Point(12, 12);
            this.pixelPanel.Name = "pixelPanel";
            this.pixelPanel.Size = new System.Drawing.Size(surfaceWidth, surfaceHeight);
            this.pixelPanel.TabIndex = 0;
            this.pixelPanel.TabStop = false;
            // 
            // timer
            // 
            this.timer.Interval = 40;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 504);
            this.Controls.Add(this.pixelPanel);
            this.Name = "MainWindow";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pixelPanel)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Overrides
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
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
