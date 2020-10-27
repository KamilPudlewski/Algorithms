namespace Convex_Hull
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.startButton = new System.Windows.Forms.Button();
            this.randomizePointsButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.pointsCounterTextBox = new System.Windows.Forms.TextBox();
            this.pointsCounterLabel = new System.Windows.Forms.Label();
            this.startButtonSteps = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(29, 97);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1053, 455);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(949, 15);
            this.startButton.Margin = new System.Windows.Forms.Padding(4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(133, 62);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // randomizePointsButton
            // 
            this.randomizePointsButton.Location = new System.Drawing.Point(29, 15);
            this.randomizePointsButton.Margin = new System.Windows.Forms.Padding(4);
            this.randomizePointsButton.Name = "randomizePointsButton";
            this.randomizePointsButton.Size = new System.Drawing.Size(133, 62);
            this.randomizePointsButton.TabIndex = 2;
            this.randomizePointsButton.Text = "Randomize Points";
            this.randomizePointsButton.UseVisualStyleBackColor = true;
            this.randomizePointsButton.Click += new System.EventHandler(this.randomizePointsButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(788, 16);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(133, 62);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // pointsCounterTextBox
            // 
            this.pointsCounterTextBox.Location = new System.Drawing.Point(189, 52);
            this.pointsCounterTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.pointsCounterTextBox.Name = "pointsCounterTextBox";
            this.pointsCounterTextBox.Size = new System.Drawing.Size(132, 22);
            this.pointsCounterTextBox.TabIndex = 4;
            this.pointsCounterTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pointsCounterTextBox.TextChanged += new System.EventHandler(this.pointsCounterTextBox_TextChanged);
            // 
            // pointsCounterLabel
            // 
            this.pointsCounterLabel.Location = new System.Drawing.Point(189, 16);
            this.pointsCounterLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pointsCounterLabel.Name = "pointsCounterLabel";
            this.pointsCounterLabel.Size = new System.Drawing.Size(133, 28);
            this.pointsCounterLabel.TabIndex = 5;
            this.pointsCounterLabel.Text = "Points counter:";
            this.pointsCounterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startButtonSteps
            // 
            this.startButtonSteps.Location = new System.Drawing.Point(363, 16);
            this.startButtonSteps.Name = "startButtonSteps";
            this.startButtonSteps.Size = new System.Drawing.Size(133, 62);
            this.startButtonSteps.TabIndex = 6;
            this.startButtonSteps.Text = "Start Step By Step";
            this.startButtonSteps.UseVisualStyleBackColor = true;
            this.startButtonSteps.Click += new System.EventHandler(this.startButtonSteps_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 567);
            this.Controls.Add(this.startButtonSteps);
            this.Controls.Add(this.pointsCounterLabel);
            this.Controls.Add(this.pointsCounterTextBox);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.randomizePointsButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.pictureBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Menu";
            this.Text = "Convex Hull";
            this.Load += new System.EventHandler(this.ConvexHull_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button randomizePointsButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.TextBox pointsCounterTextBox;
        private System.Windows.Forms.Label pointsCounterLabel;
        private System.Windows.Forms.Button startButtonSteps;
    }
}

