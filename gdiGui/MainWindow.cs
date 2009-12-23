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
        #region Fields
        private IContainer components = null;

        private PixelPanel pixelPanel;

        private Timer timer;
        #endregion

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        public event EventHandler OnTimerTick;
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
        #endregion

        #region Private Methods
        private void InitializeComponent()
        {
            this.pixelPanel = new PixelPanel(640, 480);
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pixelPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // pixelPanel
            // 
            this.pixelPanel.Location = new System.Drawing.Point(12, 12);
            this.pixelPanel.Name = "pixelPanel";
            this.pixelPanel.Size = new System.Drawing.Size(640, 480);
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
        #endregion
    }
}
