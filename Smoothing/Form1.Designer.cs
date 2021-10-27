
namespace Smoothing
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbSource = new System.Windows.Forms.PictureBox();
            this.pbTarget = new System.Windows.Forms.PictureBox();
            this.btProcess = new System.Windows.Forms.Button();
            this.btLoad = new System.Windows.Forms.Button();
            this.tbWindowSize = new System.Windows.Forms.TextBox();
            this.rbAverage = new System.Windows.Forms.RadioButton();
            this.rbMiddle = new System.Windows.Forms.RadioButton();
            this.rbGauss = new System.Windows.Forms.RadioButton();
            this.rbSobel = new System.Windows.Forms.RadioButton();
            this.tbSigma = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTarget)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSource
            // 
            this.pbSource.Location = new System.Drawing.Point(55, 35);
            this.pbSource.Name = "pbSource";
            this.pbSource.Size = new System.Drawing.Size(320, 320);
            this.pbSource.TabIndex = 0;
            this.pbSource.TabStop = false;
            // 
            // pbTarget
            // 
            this.pbTarget.Location = new System.Drawing.Point(488, 35);
            this.pbTarget.Name = "pbTarget";
            this.pbTarget.Size = new System.Drawing.Size(320, 320);
            this.pbTarget.TabIndex = 1;
            this.pbTarget.TabStop = false;
            // 
            // btProcess
            // 
            this.btProcess.Location = new System.Drawing.Point(398, 419);
            this.btProcess.Name = "btProcess";
            this.btProcess.Size = new System.Drawing.Size(94, 29);
            this.btProcess.TabIndex = 2;
            this.btProcess.Text = "Process";
            this.btProcess.UseVisualStyleBackColor = true;
            this.btProcess.Click += new System.EventHandler(this.btProcess_Click);
            // 
            // btLoad
            // 
            this.btLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btLoad.Location = new System.Drawing.Point(398, 375);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(94, 29);
            this.btLoad.TabIndex = 3;
            this.btLoad.Text = "Load";
            this.btLoad.UseVisualStyleBackColor = true;
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // tbWindowSize
            // 
            this.tbWindowSize.Location = new System.Drawing.Point(515, 377);
            this.tbWindowSize.Name = "tbWindowSize";
            this.tbWindowSize.Size = new System.Drawing.Size(125, 27);
            this.tbWindowSize.TabIndex = 4;
            // 
            // rbAverage
            // 
            this.rbAverage.AutoSize = true;
            this.rbAverage.Location = new System.Drawing.Point(99, 380);
            this.rbAverage.Name = "rbAverage";
            this.rbAverage.Size = new System.Drawing.Size(85, 24);
            this.rbAverage.TabIndex = 5;
            this.rbAverage.TabStop = true;
            this.rbAverage.Text = "Average";
            this.rbAverage.UseVisualStyleBackColor = true;
            // 
            // rbMiddle
            // 
            this.rbMiddle.AutoSize = true;
            this.rbMiddle.Location = new System.Drawing.Point(99, 410);
            this.rbMiddle.Name = "rbMiddle";
            this.rbMiddle.Size = new System.Drawing.Size(77, 24);
            this.rbMiddle.TabIndex = 6;
            this.rbMiddle.TabStop = true;
            this.rbMiddle.Text = "Middle";
            this.rbMiddle.UseVisualStyleBackColor = true;
            // 
            // rbGauss
            // 
            this.rbGauss.AutoSize = true;
            this.rbGauss.Location = new System.Drawing.Point(99, 440);
            this.rbGauss.Name = "rbGauss";
            this.rbGauss.Size = new System.Drawing.Size(68, 24);
            this.rbGauss.TabIndex = 7;
            this.rbGauss.TabStop = true;
            this.rbGauss.Text = "Gauss";
            this.rbGauss.UseVisualStyleBackColor = true;
            // 
            // rbSobel
            // 
            this.rbSobel.AutoSize = true;
            this.rbSobel.Location = new System.Drawing.Point(99, 470);
            this.rbSobel.Name = "rbSobel";
            this.rbSobel.Size = new System.Drawing.Size(68, 24);
            this.rbSobel.TabIndex = 8;
            this.rbSobel.TabStop = true;
            this.rbSobel.Text = "Sobel";
            this.rbSobel.UseVisualStyleBackColor = true;
            // 
            // tbSigma
            // 
            this.tbSigma.Location = new System.Drawing.Point(515, 419);
            this.tbSigma.Name = "tbSigma";
            this.tbSigma.Size = new System.Drawing.Size(125, 27);
            this.tbSigma.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 527);
            this.Controls.Add(this.tbSigma);
            this.Controls.Add(this.rbSobel);
            this.Controls.Add(this.rbGauss);
            this.Controls.Add(this.rbMiddle);
            this.Controls.Add(this.rbAverage);
            this.Controls.Add(this.tbWindowSize);
            this.Controls.Add(this.btLoad);
            this.Controls.Add(this.btProcess);
            this.Controls.Add(this.pbTarget);
            this.Controls.Add(this.pbSource);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTarget)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSource;
        private System.Windows.Forms.PictureBox pbTarget;
        private System.Windows.Forms.Button btProcess;
        private System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.TextBox tbWindowSize;
        private System.Windows.Forms.RadioButton rbAverage;
        private System.Windows.Forms.RadioButton rbMiddle;
        private System.Windows.Forms.RadioButton rbGauss;
        private System.Windows.Forms.RadioButton rbSobel;
        private System.Windows.Forms.TextBox tbSigma;
    }
}

