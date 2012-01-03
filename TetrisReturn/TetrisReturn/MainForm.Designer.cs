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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.nextShape1 = new TetrisReturn.NextShape();
            this.showInformation4 = new TetrisReturn.ShowInformation();
            this.showInformation3 = new TetrisReturn.ShowInformation();
            this.showInformation2 = new TetrisReturn.ShowInformation();
            this.showInformation1 = new TetrisReturn.ShowInformation();
            this.imageButton7 = new TetrisReturn.ImageButton();
            this.imageButton6 = new TetrisReturn.ImageButton();
            this.imageButton5 = new TetrisReturn.ImageButton();
            this.imageButton4 = new TetrisReturn.ImageButton();
            this.imageButton3 = new TetrisReturn.ImageButton();
            this.imageButton2 = new TetrisReturn.ImageButton();
            this.imageButton1 = new TetrisReturn.ImageButton();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // nextShape1
            // 
            this.nextShape1.BackColor = System.Drawing.Color.Transparent;
            this.nextShape1.CStroke = System.Drawing.Color.Black;
            this.nextShape1.CText = System.Drawing.Color.DeepSkyBlue;
            this.nextShape1.FText = new System.Drawing.Font("Arial", 20F);
            this.nextShape1.ImgBack = null;
            this.nextShape1.IWidth = 2;
            this.nextShape1.Location = new System.Drawing.Point(900, 86);
            this.nextShape1.Name = "nextShape1";
            this.nextShape1.PText = new System.Drawing.Point(0, 0);
            this.nextShape1.ShapeNext = null;
            this.nextShape1.Size = new System.Drawing.Size(280, 220);
            this.nextShape1.SText = null;
            this.nextShape1.TabIndex = 11;
            // 
            // showInformation4
            // 
            this.showInformation4.BackColor = System.Drawing.Color.Transparent;
            this.showInformation4.CInfo = System.Drawing.Color.DarkOrange;
            this.showInformation4.CStroke = System.Drawing.Color.Black;
            this.showInformation4.CText = System.Drawing.Color.DeepSkyBlue;
            this.showInformation4.FInfo = new System.Drawing.Font("Arial", 15F);
            this.showInformation4.FTitle = new System.Drawing.Font("Arial", 15F);
            this.showInformation4.ImgBack = null;
            this.showInformation4.IWidth = 2;
            this.showInformation4.Location = new System.Drawing.Point(900, 327);
            this.showInformation4.Name = "showInformation4";
            this.showInformation4.SInfo = null;
            this.showInformation4.Size = new System.Drawing.Size(280, 80);
            this.showInformation4.STitle = null;
            this.showInformation4.TabIndex = 10;
            // 
            // showInformation3
            // 
            this.showInformation3.BackColor = System.Drawing.Color.Transparent;
            this.showInformation3.CInfo = System.Drawing.Color.DarkOrange;
            this.showInformation3.CStroke = System.Drawing.Color.Black;
            this.showInformation3.CText = System.Drawing.Color.DeepSkyBlue;
            this.showInformation3.FInfo = new System.Drawing.Font("Arial", 15F);
            this.showInformation3.FTitle = new System.Drawing.Font("Arial", 15F);
            this.showInformation3.ImgBack = null;
            this.showInformation3.IWidth = 2;
            this.showInformation3.Location = new System.Drawing.Point(900, 407);
            this.showInformation3.Name = "showInformation3";
            this.showInformation3.SInfo = null;
            this.showInformation3.Size = new System.Drawing.Size(280, 80);
            this.showInformation3.STitle = null;
            this.showInformation3.TabIndex = 9;
            // 
            // showInformation2
            // 
            this.showInformation2.BackColor = System.Drawing.Color.Transparent;
            this.showInformation2.CInfo = System.Drawing.Color.DarkOrange;
            this.showInformation2.CStroke = System.Drawing.Color.Black;
            this.showInformation2.CText = System.Drawing.Color.DeepSkyBlue;
            this.showInformation2.FInfo = new System.Drawing.Font("Arial", 15F);
            this.showInformation2.FTitle = new System.Drawing.Font("Arial", 15F);
            this.showInformation2.ImgBack = null;
            this.showInformation2.IWidth = 2;
            this.showInformation2.Location = new System.Drawing.Point(900, 487);
            this.showInformation2.Name = "showInformation2";
            this.showInformation2.SInfo = null;
            this.showInformation2.Size = new System.Drawing.Size(280, 80);
            this.showInformation2.STitle = null;
            this.showInformation2.TabIndex = 8;
            // 
            // showInformation1
            // 
            this.showInformation1.BackColor = System.Drawing.Color.Transparent;
            this.showInformation1.CInfo = System.Drawing.Color.DarkOrange;
            this.showInformation1.CStroke = System.Drawing.Color.Black;
            this.showInformation1.CText = System.Drawing.Color.DeepSkyBlue;
            this.showInformation1.FInfo = new System.Drawing.Font("Arial", 15F);
            this.showInformation1.FTitle = new System.Drawing.Font("Arial", 15F);
            this.showInformation1.ImgBack = null;
            this.showInformation1.IWidth = 2;
            this.showInformation1.Location = new System.Drawing.Point(900, 566);
            this.showInformation1.Name = "showInformation1";
            this.showInformation1.SInfo = null;
            this.showInformation1.Size = new System.Drawing.Size(280, 80);
            this.showInformation1.STitle = null;
            this.showInformation1.TabIndex = 7;
            // 
            // imageButton7
            // 
            this.imageButton7.BackColor = System.Drawing.Color.Transparent;
            this.imageButton7.CStroke = System.Drawing.Color.Black;
            this.imageButton7.CText = System.Drawing.Color.Red;
            this.imageButton7.ForeColor = System.Drawing.Color.Transparent;
            this.imageButton7.FText = new System.Drawing.Font("Arial", 15F);
            this.imageButton7.Image = ((System.Drawing.Bitmap)(resources.GetObject("imageButton7.Image")));
            this.imageButton7.IWidth = 2;
            this.imageButton7.Location = new System.Drawing.Point(100, 582);
            this.imageButton7.Name = "imageButton7";
            this.imageButton7.PText = new System.Drawing.Point(0, 0);
            this.imageButton7.Size = new System.Drawing.Size(230, 65);
            this.imageButton7.SText = null;
            this.imageButton7.TabIndex = 6;
            this.imageButton7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imageButton7_MouseDown);
            this.imageButton7.MouseEnter += new System.EventHandler(this.imageButton7_MouseEnter);
            this.imageButton7.MouseLeave += new System.EventHandler(this.imageButton7_MouseLeave);
            this.imageButton7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imageButton7_MouseUp);
            // 
            // imageButton6
            // 
            this.imageButton6.BackColor = System.Drawing.Color.Transparent;
            this.imageButton6.CStroke = System.Drawing.Color.Black;
            this.imageButton6.CText = System.Drawing.Color.Red;
            this.imageButton6.ForeColor = System.Drawing.Color.Transparent;
            this.imageButton6.FText = new System.Drawing.Font("Arial", 15F);
            this.imageButton6.Image = ((System.Drawing.Bitmap)(resources.GetObject("imageButton6.Image")));
            this.imageButton6.IWidth = 2;
            this.imageButton6.Location = new System.Drawing.Point(100, 496);
            this.imageButton6.Name = "imageButton6";
            this.imageButton6.PText = new System.Drawing.Point(0, 0);
            this.imageButton6.Size = new System.Drawing.Size(230, 65);
            this.imageButton6.SText = null;
            this.imageButton6.TabIndex = 5;
            this.imageButton6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imageButton6_MouseDown);
            this.imageButton6.MouseEnter += new System.EventHandler(this.imageButton6_MouseEnter);
            this.imageButton6.MouseLeave += new System.EventHandler(this.imageButton6_MouseLeave);
            this.imageButton6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imageButton6_MouseUp);
            // 
            // imageButton5
            // 
            this.imageButton5.BackColor = System.Drawing.Color.Transparent;
            this.imageButton5.CStroke = System.Drawing.Color.Black;
            this.imageButton5.CText = System.Drawing.Color.Red;
            this.imageButton5.ForeColor = System.Drawing.Color.Transparent;
            this.imageButton5.FText = new System.Drawing.Font("Arial", 15F);
            this.imageButton5.Image = ((System.Drawing.Bitmap)(resources.GetObject("imageButton5.Image")));
            this.imageButton5.IWidth = 2;
            this.imageButton5.Location = new System.Drawing.Point(100, 414);
            this.imageButton5.Name = "imageButton5";
            this.imageButton5.PText = new System.Drawing.Point(0, 0);
            this.imageButton5.Size = new System.Drawing.Size(230, 65);
            this.imageButton5.SText = null;
            this.imageButton5.TabIndex = 4;
            this.imageButton5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imageButton5_MouseDown);
            this.imageButton5.MouseEnter += new System.EventHandler(this.imageButton5_MouseEnter);
            this.imageButton5.MouseLeave += new System.EventHandler(this.imageButton5_MouseLeave);
            this.imageButton5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imageButton5_MouseUp);
            // 
            // imageButton4
            // 
            this.imageButton4.BackColor = System.Drawing.Color.Transparent;
            this.imageButton4.CStroke = System.Drawing.Color.Black;
            this.imageButton4.CText = System.Drawing.Color.Red;
            this.imageButton4.ForeColor = System.Drawing.Color.Transparent;
            this.imageButton4.FText = new System.Drawing.Font("Arial", 15F);
            this.imageButton4.Image = ((System.Drawing.Bitmap)(resources.GetObject("imageButton4.Image")));
            this.imageButton4.IWidth = 2;
            this.imageButton4.Location = new System.Drawing.Point(100, 331);
            this.imageButton4.Name = "imageButton4";
            this.imageButton4.PText = new System.Drawing.Point(0, 0);
            this.imageButton4.Size = new System.Drawing.Size(230, 65);
            this.imageButton4.SText = null;
            this.imageButton4.TabIndex = 3;
            this.imageButton4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imageButton4_MouseDown);
            this.imageButton4.MouseEnter += new System.EventHandler(this.imageButton4_MouseEnter);
            this.imageButton4.MouseLeave += new System.EventHandler(this.imageButton4_MouseLeave);
            this.imageButton4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imageButton4_MouseUp);
            // 
            // imageButton3
            // 
            this.imageButton3.BackColor = System.Drawing.Color.Transparent;
            this.imageButton3.CStroke = System.Drawing.Color.Black;
            this.imageButton3.CText = System.Drawing.Color.Red;
            this.imageButton3.ForeColor = System.Drawing.Color.Transparent;
            this.imageButton3.FText = new System.Drawing.Font("Arial", 15F);
            this.imageButton3.Image = ((System.Drawing.Bitmap)(resources.GetObject("imageButton3.Image")));
            this.imageButton3.IWidth = 2;
            this.imageButton3.Location = new System.Drawing.Point(100, 248);
            this.imageButton3.Name = "imageButton3";
            this.imageButton3.PText = new System.Drawing.Point(0, 0);
            this.imageButton3.Size = new System.Drawing.Size(230, 65);
            this.imageButton3.SText = null;
            this.imageButton3.TabIndex = 2;
            this.imageButton3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imageButton3_MouseDown);
            this.imageButton3.MouseEnter += new System.EventHandler(this.imageButton3_MouseEnter);
            this.imageButton3.MouseLeave += new System.EventHandler(this.imageButton3_MouseLeave);
            this.imageButton3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imageButton3_MouseUp);
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
            this.imageButton2.Location = new System.Drawing.Point(100, 163);
            this.imageButton2.Name = "imageButton2";
            this.imageButton2.PText = new System.Drawing.Point(0, 0);
            this.imageButton2.Size = new System.Drawing.Size(230, 65);
            this.imageButton2.SText = null;
            this.imageButton2.TabIndex = 1;
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
            this.imageButton1.Location = new System.Drawing.Point(100, 86);
            this.imageButton1.Name = "imageButton1";
            this.imageButton1.PText = new System.Drawing.Point(0, 0);
            this.imageButton1.Size = new System.Drawing.Size(230, 65);
            this.imageButton1.SText = null;
            this.imageButton1.TabIndex = 0;
            this.imageButton1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imageButton1_MouseDown);
            this.imageButton1.MouseEnter += new System.EventHandler(this.imageButton1_MouseEnter);
            this.imageButton1.MouseLeave += new System.EventHandler(this.imageButton1_MouseLeave);
            this.imageButton1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imageButton1_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.nextShape1);
            this.Controls.Add(this.showInformation4);
            this.Controls.Add(this.showInformation3);
            this.Controls.Add(this.showInformation2);
            this.Controls.Add(this.showInformation1);
            this.Controls.Add(this.imageButton7);
            this.Controls.Add(this.imageButton6);
            this.Controls.Add(this.imageButton5);
            this.Controls.Add(this.imageButton4);
            this.Controls.Add(this.imageButton3);
            this.Controls.Add(this.imageButton2);
            this.Controls.Add(this.imageButton1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tetris Return";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private ImageButton imageButton1;
        private ImageButton imageButton2;
        private ImageButton imageButton3;
        private ImageButton imageButton4;
        private ImageButton imageButton5;
        private ImageButton imageButton6;
        private ImageButton imageButton7;
        private ShowInformation showInformation1;
        private ShowInformation showInformation2;
        private ShowInformation showInformation3;
        private ShowInformation showInformation4;
        private NextShape nextShape1;
        private System.Windows.Forms.Timer timer;







    }
}

