namespace TetrisReturn
{
    partial class ImageButton
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ImageButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "ImageButton";
            this.Size = new System.Drawing.Size(180, 60);
            this.EnabledChanged += new System.EventHandler(this.ImageButton_EnabledChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageButton_MouseDown);
            this.MouseEnter += new System.EventHandler(this.ImageButton_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ImageButton_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImageButton_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion


    }
}
