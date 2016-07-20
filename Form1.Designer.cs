namespace WindowsFormsApplication1
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
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_Rotate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox_RotateValue = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_Zoom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox_ZoomValue = new System.Windows.Forms.ToolStripTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.toolStripMenuItem_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_New = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Complete = new System.Windows.Forms.ToolStripMenuItem();
            this.polygonPanel1 = new WindowsFormsApplication1.PolygonPanel();
            this.myPanel1 = new WindowsFormsApplication1.MyPanel();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(956, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Draw";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(822, 543);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(187, 14);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(823, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_New,
            this.toolStripMenuItem_Complete,
            this.toolStripMenuItem_Clear,
            this.toolStripSeparator1,
            this.toolStripMenuItem_Rotate,
            this.toolStripMenuItem_Zoom});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(127, 120);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripMenuItem_Rotate
            // 
            this.toolStripMenuItem_Rotate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox_RotateValue});
            this.toolStripMenuItem_Rotate.Name = "toolStripMenuItem_Rotate";
            this.toolStripMenuItem_Rotate.Size = new System.Drawing.Size(126, 22);
            this.toolStripMenuItem_Rotate.Text = "Rotate";
            // 
            // toolStripTextBox_RotateValue
            // 
            this.toolStripTextBox_RotateValue.Name = "toolStripTextBox_RotateValue";
            this.toolStripTextBox_RotateValue.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox_RotateValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox1_KeyDown);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(123, 6);
            // 
            // toolStripMenuItem_Zoom
            // 
            this.toolStripMenuItem_Zoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox_ZoomValue});
            this.toolStripMenuItem_Zoom.Name = "toolStripMenuItem_Zoom";
            this.toolStripMenuItem_Zoom.Size = new System.Drawing.Size(126, 22);
            this.toolStripMenuItem_Zoom.Text = "Zoom";
            // 
            // toolStripTextBox_ZoomValue
            // 
            this.toolStripTextBox_ZoomValue.Name = "toolStripTextBox_ZoomValue";
            this.toolStripTextBox_ZoomValue.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox_ZoomValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox2_KeyDown);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(889, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(51, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "New";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // toolStripMenuItem_Clear
            // 
            this.toolStripMenuItem_Clear.Name = "toolStripMenuItem_Clear";
            this.toolStripMenuItem_Clear.Size = new System.Drawing.Size(126, 22);
            this.toolStripMenuItem_Clear.Text = "Clear";
            this.toolStripMenuItem_Clear.Click += new System.EventHandler(this.toolStripMenuItem_Clear_Click);
            // 
            // toolStripMenuItem_New
            // 
            this.toolStripMenuItem_New.Name = "toolStripMenuItem_New";
            this.toolStripMenuItem_New.Size = new System.Drawing.Size(126, 22);
            this.toolStripMenuItem_New.Text = "New";
            this.toolStripMenuItem_New.Click += new System.EventHandler(this.toolStripMenuItem_New_Click);
            // 
            // toolStripMenuItem_Complete
            // 
            this.toolStripMenuItem_Complete.Name = "toolStripMenuItem_Complete";
            this.toolStripMenuItem_Complete.Size = new System.Drawing.Size(126, 22);
            this.toolStripMenuItem_Complete.Text = "Complete";
            this.toolStripMenuItem_Complete.Click += new System.EventHandler(this.toolStripMenuItem_Complete_Click);
            // 
            // polygonPanel1
            // 
            this.polygonPanel1.Location = new System.Drawing.Point(3, 3);
            this.polygonPanel1.Name = "polygonPanel1";
            this.polygonPanel1.Size = new System.Drawing.Size(1014, 534);
            this.polygonPanel1.TabIndex = 9;
            // 
            // myPanel1
            // 
            this.myPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myPanel1.BackColor = System.Drawing.Color.White;
            this.myPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.myPanel1.Location = new System.Drawing.Point(12, 543);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.Size = new System.Drawing.Size(804, 14);
            this.myPanel1.TabIndex = 7;
            this.myPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.myPanel1_Paint);
            this.myPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.myPanel1_MouseDown_1);
            this.myPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.myPanel1_MouseMove_1);
            this.myPanel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myPanel1_MouseUp_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 569);
            this.Controls.Add(this.polygonPanel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.myPanel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button2;
        private MyPanel myPanel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Rotate;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_RotateValue;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Zoom;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_ZoomValue;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_New;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Complete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Clear;
        private PolygonPanel polygonPanel1;
    }
}

