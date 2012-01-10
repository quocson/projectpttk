namespace TetrisReturn
{
    partial class HighScores
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.Rank = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Score = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Level = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Line = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Piece = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.showInformation1 = new TetrisReturn.ShowInformation();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.NavajoWhite;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Rank,
            this.Score,
            this.Level,
            this.Line,
            this.Piece});
            this.listView1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(139, 138);
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(515, 277);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Rank
            // 
            this.Rank.Text = "Rank";
            // 
            // Score
            // 
            this.Score.Text = "Score";
            this.Score.Width = 100;
            // 
            // Level
            // 
            this.Level.Text = "Level";
            this.Level.Width = 80;
            // 
            // Line
            // 
            this.Line.Text = "Line";
            this.Line.Width = 100;
            // 
            // Piece
            // 
            this.Piece.Text = "Piece";
            this.Piece.Width = 100;
            // 
            // showInformation1
            // 
            this.showInformation1.BackColor = System.Drawing.Color.Transparent;
            this.showInformation1.CInfo = System.Drawing.Color.White;
            this.showInformation1.CStroke = System.Drawing.Color.Black;
            this.showInformation1.CText = System.Drawing.Color.White;
            this.showInformation1.FInfo = new System.Drawing.Font("Arial", 15F);
            this.showInformation1.FTitle = new System.Drawing.Font("Arial", 15F);
            this.showInformation1.ImgBack = null;
            this.showInformation1.IWidth = 2;
            this.showInformation1.Location = new System.Drawing.Point(219, 12);
            this.showInformation1.Name = "showInformation1";
            this.showInformation1.SInfo = null;
            this.showInformation1.Size = new System.Drawing.Size(350, 80);
            this.showInformation1.STitle = null;
            this.showInformation1.TabIndex = 1;
            // 
            // HighScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.showInformation1);
            this.Controls.Add(this.listView1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HighScores";
            this.ShowInTaskbar = false;
            this.Text = "HighScores";
            this.Load += new System.EventHandler(this.HighScores_Load);
            this.Shown += new System.EventHandler(this.HighScores_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HighScores_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HighScores_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private ShowInformation showInformation1;
        private System.Windows.Forms.ColumnHeader Score;
        private System.Windows.Forms.ColumnHeader Level;
        private System.Windows.Forms.ColumnHeader Line;
        private System.Windows.Forms.ColumnHeader Piece;
        private System.Windows.Forms.ColumnHeader Rank;
    }
}