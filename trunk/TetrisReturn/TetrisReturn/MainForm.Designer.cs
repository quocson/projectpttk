namespace TetrisReturn
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.showInformation1 = new TetrisReturn.ShowInformation();
            this.SuspendLayout();
            // 
            // showInformation1
            // 
            this.showInformation1.CNumber = System.Drawing.Color.Empty;
            this.showInformation1.CStroke = System.Drawing.Color.Black;
            this.showInformation1.CText = System.Drawing.Color.White;
            this.showInformation1.Drawabled = false;
            this.showInformation1.FNumber = null;
            this.showInformation1.FText = null;
            this.showInformation1.ImgBack = null;
            this.showInformation1.IWidth = 2;
            this.showInformation1.Location = new System.Drawing.Point(67, 61);
            this.showInformation1.Name = "showInformation1";
            this.showInformation1.Number = 0;
            this.showInformation1.PNumber = new System.Drawing.Point(0, 0);
            this.showInformation1.PText = new System.Drawing.Point(0, 0);
            this.showInformation1.Size = new System.Drawing.Size(173, 165);
            this.showInformation1.SText = null;
            this.showInformation1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 310);
            this.Controls.Add(this.showInformation1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Tetris Return";
            this.ResumeLayout(false);

        }

        #endregion

        private ShowInformation showInformation1;





    }
}

