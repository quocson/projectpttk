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
            this.imageButton1 = new TetrisReturn.ImageButton();
            this.SuspendLayout();
            // 
            // imageButton1
            // 
            this.imageButton1.ForeColor = System.Drawing.Color.Transparent;
            this.imageButton1.IDisabled = null;
            this.imageButton1.IEnabled = null;
            this.imageButton1.IHover = null;
            this.imageButton1.IOnclick = null;
            this.imageButton1.Location = new System.Drawing.Point(90, 12);
            this.imageButton1.Name = "imageButton1";
            this.imageButton1.Size = new System.Drawing.Size(200, 159);
            this.imageButton1.SText = null;
            this.imageButton1.StrokeColor = System.Drawing.Color.Black;
            this.imageButton1.StrokeWidth = 2;
            this.imageButton1.TabIndex = 0;
            this.imageButton1.TColor = System.Drawing.Color.White;
            this.imageButton1.TFont = new System.Drawing.Font("Arial", 5F);
            this.imageButton1.TPos = new System.Drawing.Point(100, 79);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 176);
            this.Controls.Add(this.imageButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Tetris Return";
            this.ResumeLayout(false);

        }

        #endregion

        private ImageButton imageButton1;



    }
}

