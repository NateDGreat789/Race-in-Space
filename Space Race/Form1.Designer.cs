namespace Space_Race
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
            this.gametimer = new System.Windows.Forms.Timer(this.components);
            this.titlelabel = new System.Windows.Forms.Label();
            this.subtitlelabel = new System.Windows.Forms.Label();
            this.p1label = new System.Windows.Forms.Label();
            this.p2label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gametimer
            // 
            this.gametimer.Enabled = true;
            this.gametimer.Interval = 20;
            this.gametimer.Tick += new System.EventHandler(this.gametimer_Tick);
            // 
            // titlelabel
            // 
            this.titlelabel.BackColor = System.Drawing.Color.Transparent;
            this.titlelabel.Font = new System.Drawing.Font("Eras Medium ITC", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titlelabel.ForeColor = System.Drawing.Color.White;
            this.titlelabel.Location = new System.Drawing.Point(159, 166);
            this.titlelabel.Name = "titlelabel";
            this.titlelabel.Size = new System.Drawing.Size(177, 23);
            this.titlelabel.TabIndex = 0;
            this.titlelabel.Text = "RACE IN SPACE";
            this.titlelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // subtitlelabel
            // 
            this.subtitlelabel.BackColor = System.Drawing.Color.Transparent;
            this.subtitlelabel.Font = new System.Drawing.Font("Eras Medium ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitlelabel.ForeColor = System.Drawing.Color.Aqua;
            this.subtitlelabel.Location = new System.Drawing.Point(89, 219);
            this.subtitlelabel.Name = "subtitlelabel";
            this.subtitlelabel.Size = new System.Drawing.Size(315, 23);
            this.subtitlelabel.TabIndex = 1;
            this.subtitlelabel.Text = "Press space to start or escape to exit";
            this.subtitlelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p1label
            // 
            this.p1label.BackColor = System.Drawing.Color.Transparent;
            this.p1label.Font = new System.Drawing.Font("Eras Medium ITC", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1label.ForeColor = System.Drawing.Color.White;
            this.p1label.Location = new System.Drawing.Point(80, 415);
            this.p1label.Name = "p1label";
            this.p1label.Size = new System.Drawing.Size(66, 86);
            this.p1label.TabIndex = 2;
            this.p1label.Text = "0";
            this.p1label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.p1label.Visible = false;
            // 
            // p2label
            // 
            this.p2label.BackColor = System.Drawing.Color.Transparent;
            this.p2label.Font = new System.Drawing.Font("Eras Medium ITC", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2label.ForeColor = System.Drawing.Color.White;
            this.p2label.Location = new System.Drawing.Point(363, 415);
            this.p2label.Name = "p2label";
            this.p2label.Size = new System.Drawing.Size(66, 86);
            this.p2label.TabIndex = 3;
            this.p2label.Text = "0";
            this.p2label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.p2label.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.p2label);
            this.Controls.Add(this.p1label);
            this.Controls.Add(this.subtitlelabel);
            this.Controls.Add(this.titlelabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gametimer;
        private System.Windows.Forms.Label titlelabel;
        private System.Windows.Forms.Label subtitlelabel;
        private System.Windows.Forms.Label p1label;
        private System.Windows.Forms.Label p2label;
    }
}

