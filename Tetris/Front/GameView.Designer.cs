namespace Front
{
    partial class GameView
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
            this.game = new System.Windows.Forms.Panel();
            this.startPause = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.lines = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // game
            // 
            this.game.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.game.Location = new System.Drawing.Point(10, 12);
            this.game.Name = "game";
            this.game.Size = new System.Drawing.Size(300, 600);
            this.game.TabIndex = 0;
            this.game.Paint += new System.Windows.Forms.PaintEventHandler(this.game_Paint);
            // 
            // startPause
            // 
            this.startPause.Location = new System.Drawing.Point(316, 12);
            this.startPause.Name = "startPause";
            this.startPause.Size = new System.Drawing.Size(75, 23);
            this.startPause.TabIndex = 1;
            this.startPause.Text = "Start";
            this.startPause.UseVisualStyleBackColor = true;
            this.startPause.Click += new System.EventHandler(this.startPause_Click);
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(316, 41);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(75, 23);
            this.reset.TabIndex = 2;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // lines
            // 
            this.lines.AutoSize = true;
            this.lines.Location = new System.Drawing.Point(344, 83);
            this.lines.Name = "lines";
            this.lines.Size = new System.Drawing.Size(13, 13);
            this.lines.TabIndex = 3;
            this.lines.Text = "0";
            // 
            // GameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 633);
            this.Controls.Add(this.lines);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.startPause);
            this.Controls.Add(this.game);
            this.DoubleBuffered = true;
            this.Name = "GameView";
            this.Text = "Tetris";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameView_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel game;
        private System.Windows.Forms.Button startPause;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Label lines;
    }
}

