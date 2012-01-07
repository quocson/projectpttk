namespace TetrisReturn
{
    partial class ExitConfirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExitConfirm));
            this.imageButton2 = new TetrisReturn.ImageButton();
            this.imageButton1 = new TetrisReturn.ImageButton();
            this.showInformation1 = new TetrisReturn.ShowInformation();
            this.SuspendLayout();
            // 
            // imageButton2
            // 
            this.imageButton2.BackColor = System.Drawing.Color.Transparent;
            this.imageButton2.CStroke = System.Drawing.Color.Black;
            this.imageButton2.CText = System.Drawing.Color.Red;
            this.imageButton2.ForeColor = System.Drawing.Color.Transparent;
            this.imageButton2.FText = new System.Drawing.Font("Arial", 15F);
            this.imageButton2.Image = ((System.Drawing.Bitmap)(resources.GetObject("imageButton2.Image")));
            this.imageButton2.IWidth = 2;
            this.imageButton2.Location = new System.Drawing.Point(330, 100);
            this.imageButton2.Name = "imageButton2";
            this.imageButton2.PText = new System.Drawing.Point(0, 0);
            this.imageButton2.Size = new System.Drawing.Size(230, 60);
            this.imageButton2.SText = null;
            this.imageButton2.TabIndex = 2;
            this.imageButton2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imageButton2_MouseDown);
            this.imageButton2.MouseEnter += new System.EventHandler(this.imageButton2_MouseEnter);
            this.imageButton2.MouseLeave += new System.EventHandler(this.imageButton2_MouseLeave);
            this.imageButton2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imageButton2_MouseUp);
            // 
            // imageButton1
            // 
            this.imageButton1.BackColor = System.Drawing.Color.Transparent;
            this.imageButton1.CStroke = System.Drawing.Color.Black;
            this.imageButton1.CText = System.Drawing.Color.Red;
            this.imageButton1.ForeColor = System.Drawing.Color.Transparent;
            this.imageButton1.FText = new System.Drawing.Font("Arial", 15F);
            this.imageButton1.Image = ((System.Drawing.Bitmap)(resources.GetObject("imageButton1.Image")));
            this.imageButton1.IWidth = 2;
            this.imageButton1.Location = new System.Drawing.Point(40, 100);
            this.imageButton1.Name = "imageButton1";
            this.imageButton1.PText = new System.Drawing.Point(0, 0);
            this.imageButton1.Size = new System.Drawing.Size(230, 60);
            this.imageButton1.SText = null;
            this.imageButton1.TabIndex = 1;
            this.imageButton1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imageButton1_MouseDown);
            this.imageButton1.MouseEnter += new System.EventHandler(this.imageButton1_MouseEnter);
            this.imageButton1.MouseLeave += new System.EventHandler(this.imageButton1_MouseLeave);
            this.imageButton1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imageButton1_MouseUp);
            // 
            // showInformation1
            // 
            this.showInformation1.BackColor = System.Drawing.Color.Transparent;
            this.showInformation1.CInfo = System.Drawing.Color.Red;
            this.showInformation1.CStroke = System.Drawing.Color.Black;
            this.showInformation1.CText = System.Drawing.Color.OrangeRed;
            this.showInformation1.FInfo = new System.Drawing.Font("Arial", 15F);
            this.showInformation1.FTitle = new System.Drawing.Font("Arial", 15F);
            this.showInformation1.ImgBack = null;
            this.showInformation1.IWidth = 2;
            this.showInformation1.Location = new System.Drawing.Point(0, 0);
            this.showInformation1.Name = "showInformation1";
            this.showInformation1.SInfo = null;
            this.showInformation1.Size = new System.Drawing.Size(600, 200);
            this.showInformation1.STitle = null;
            this.showInformation1.TabIndex = 0;
            // 
            // ExitConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 200);
            this.Controls.Add(this.imageButton2);
            this.Controls.Add(this.imageButton1);
            this.Controls.Add(this.showInformation1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ExitConfirm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ExitConfirm";
            this.Load += new System.EventHandler(this.ExitConfirm_Load);
            this.Shown += new System.EventHandler(this.ExitConfirm_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private ShowInformation showInformation1;
        private ImageButton imageButton1;
        private ImageButton imageButton2;
    }
}