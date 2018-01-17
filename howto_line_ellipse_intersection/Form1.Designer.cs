namespace howto_line_ellipse_intersection
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
            this.chkSegmentOnly = new System.Windows.Forms.CheckBox();
            this.btnSelectEllipse = new System.Windows.Forms.Button();
            this.btnSelectLine = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkSegmentOnly
            // 
            this.chkSegmentOnly.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkSegmentOnly.AutoSize = true;
            this.chkSegmentOnly.Location = new System.Drawing.Point(217, 7);
            this.chkSegmentOnly.Name = "chkSegmentOnly";
            this.chkSegmentOnly.Size = new System.Drawing.Size(92, 17);
            this.chkSegmentOnly.TabIndex = 5;
            this.chkSegmentOnly.Text = "Segment Only";
            this.chkSegmentOnly.UseVisualStyleBackColor = true;
            this.chkSegmentOnly.CheckedChanged += new System.EventHandler(this.chkSegmentOnly_CheckedChanged);
            // 
            // btnSelectEllipse
            // 
            this.btnSelectEllipse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSelectEllipse.Location = new System.Drawing.Point(125, 3);
            this.btnSelectEllipse.Name = "btnSelectEllipse";
            this.btnSelectEllipse.Size = new System.Drawing.Size(86, 23);
            this.btnSelectEllipse.TabIndex = 4;
            this.btnSelectEllipse.Text = "Select Ellipse";
            this.btnSelectEllipse.UseVisualStyleBackColor = true;
            this.btnSelectEllipse.Click += new System.EventHandler(this.btnSelectEllipse_Click);
            // 
            // btnSelectLine
            // 
            this.btnSelectLine.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSelectLine.Location = new System.Drawing.Point(33, 3);
            this.btnSelectLine.Name = "btnSelectLine";
            this.btnSelectLine.Size = new System.Drawing.Size(86, 23);
            this.btnSelectLine.TabIndex = 3;
            this.btnSelectLine.Text = "Select Line";
            this.btnSelectLine.UseVisualStyleBackColor = true;
            this.btnSelectLine.Click += new System.EventHandler(this.btnSelectLine_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 221);
            this.Controls.Add(this.chkSegmentOnly);
            this.Controls.Add(this.btnSelectEllipse);
            this.Controls.Add(this.btnSelectLine);
            this.Name = "Form1";
            this.Text = "howto_line_ellipse_intersection";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSegmentOnly;
        private System.Windows.Forms.Button btnSelectEllipse;
        private System.Windows.Forms.Button btnSelectLine;
    }
}

