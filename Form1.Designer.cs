namespace PacMan_FinalProject
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnPlay = new System.Windows.Forms.Button();
            this.EddieTimer = new System.Windows.Forms.Timer(this.components);
            this.lblScore = new System.Windows.Forms.Label();
            this.pbGameBoard = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PinkyTimer = new System.Windows.Forms.Timer(this.components);
            this.gbGameData = new System.Windows.Forms.GroupBox();
            this.lbllives = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.energyTimer = new System.Windows.Forms.Timer(this.components);
            this.StaggersGhostStart = new System.Windows.Forms.Timer(this.components);
            this.btnPause = new System.Windows.Forms.Button();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.BlinkyTimer = new System.Windows.Forms.Timer(this.components);
            this.InkyTimer = new System.Windows.Forms.Timer(this.components);
            this.ClydeTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbGameBoard)).BeginInit();
            this.gbGameData.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(489, 33);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(120, 70);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // EddieTimer
            // 
            this.EddieTimer.Interval = 250;
            this.EddieTimer.Tick += new System.EventHandler(this.EddieTimer_Tick);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblScore.Location = new System.Drawing.Point(75, 27);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(0, 13);
            this.lblScore.TabIndex = 2;
            // 
            // pbGameBoard
            // 
            this.pbGameBoard.Location = new System.Drawing.Point(39, 22);
            this.pbGameBoard.Name = "pbGameBoard";
            this.pbGameBoard.Size = new System.Drawing.Size(405, 570);
            this.pbGameBoard.TabIndex = 0;
            this.pbGameBoard.TabStop = false;
            this.pbGameBoard.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pbGameBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pbGameBoard_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Score:";
            // 
            // PinkyTimer
            // 
            this.PinkyTimer.Interval = 250;
            this.PinkyTimer.Tick += new System.EventHandler(this.PinkyTimer_Tick);
            // 
            // gbGameData
            // 
            this.gbGameData.Controls.Add(this.lbllives);
            this.gbGameData.Controls.Add(this.label2);
            this.gbGameData.Controls.Add(this.label1);
            this.gbGameData.Controls.Add(this.lblScore);
            this.gbGameData.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gbGameData.Location = new System.Drawing.Point(474, 309);
            this.gbGameData.Name = "gbGameData";
            this.gbGameData.Size = new System.Drawing.Size(160, 100);
            this.gbGameData.TabIndex = 4;
            this.gbGameData.TabStop = false;
            this.gbGameData.Text = "Game Data";
            // 
            // lbllives
            // 
            this.lbllives.AutoSize = true;
            this.lbllives.Location = new System.Drawing.Point(75, 64);
            this.lbllives.Name = "lbllives";
            this.lbllives.Size = new System.Drawing.Size(0, 13);
            this.lbllives.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lives";
            // 
            // energyTimer
            // 
            this.energyTimer.Interval = 10000;
            this.energyTimer.Tick += new System.EventHandler(this.energyTimer_Tick);
            // 
            // StaggersGhostStart
            // 
            this.StaggersGhostStart.Interval = 2000;
            this.StaggersGhostStart.Tick += new System.EventHandler(this.StaggersGhostStart_Tick);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(489, 127);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(120, 70);
            this.btnPause.TabIndex = 5;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(489, 216);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(120, 70);
            this.btnNewGame.TabIndex = 6;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // BlinkyTimer
            // 
            this.BlinkyTimer.Interval = 250;
            this.BlinkyTimer.Tick += new System.EventHandler(this.BlinkyTimer_Tick);
            // 
            // InkyTimer
            // 
            this.InkyTimer.Interval = 250;
            this.InkyTimer.Tick += new System.EventHandler(this.InkyTimer_Tick);
            // 
            // ClydeTimer
            // 
            this.ClydeTimer.Interval = 250;
            this.ClydeTimer.Tick += new System.EventHandler(this.ClydeTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(657, 624);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.gbGameData);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.pbGameBoard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Pac-Man";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbGameBoard)).EndInit();
            this.gbGameData.ResumeLayout(false);
            this.gbGameData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Timer EddieTimer;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.PictureBox pbGameBoard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer PinkyTimer;
        private System.Windows.Forms.GroupBox gbGameData;
        private System.Windows.Forms.Label lbllives;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer energyTimer;
        private System.Windows.Forms.Timer StaggersGhostStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Timer BlinkyTimer;
        private System.Windows.Forms.Timer InkyTimer;
        private System.Windows.Forms.Timer ClydeTimer;
    }
}

