namespace WindowsFormsApplication1
{
    partial class PolygonPanel
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
            this.components = new System.ComponentModel.Container();
            this.myPanel1 = new WindowsFormsApplication1.MyPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_New = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Complete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_Rotate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox_RotateValue = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem_Zoom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox_ZoomValue = new System.Windows.Forms.ToolStripTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_Cut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_CutCompete = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // myPanel1
            // 
            this.myPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myPanel1.BackColor = System.Drawing.Color.White;
            this.myPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.myPanel1.Location = new System.Drawing.Point(3, 3);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.Size = new System.Drawing.Size(614, 490);
            this.myPanel1.TabIndex = 8;
            this.myPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.myPanel1_Paint);
            this.myPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.myPanel1_MouseDown_1);
            this.myPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.myPanel1_MouseMove_1);
            this.myPanel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myPanel1_MouseUp_1);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_New,
            this.toolStripMenuItem_Complete,
            this.toolStripMenuItem_Clear,
            this.toolStripSeparator1,
            this.toolStripMenuItem_Rotate,
            this.toolStripMenuItem_Zoom,
            this.toolStripSeparator2,
            this.toolStripMenuItem_Cut,
            this.toolStripMenuItem_CutCompete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 192);
            // 
            // toolStripMenuItem_New
            // 
            this.toolStripMenuItem_New.Name = "toolStripMenuItem_New";
            this.toolStripMenuItem_New.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_New.Text = "New";
            this.toolStripMenuItem_New.Click += new System.EventHandler(this.toolStripMenuItem_New_Click);
            // 
            // toolStripMenuItem_Complete
            // 
            this.toolStripMenuItem_Complete.Name = "toolStripMenuItem_Complete";
            this.toolStripMenuItem_Complete.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_Complete.Text = "Complete";
            this.toolStripMenuItem_Complete.Click += new System.EventHandler(this.toolStripMenuItem_Complete_Click);
            // 
            // toolStripMenuItem_Clear
            // 
            this.toolStripMenuItem_Clear.Name = "toolStripMenuItem_Clear";
            this.toolStripMenuItem_Clear.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_Clear.Text = "Clear";
            this.toolStripMenuItem_Clear.Click += new System.EventHandler(this.toolStripMenuItem_Clear_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem_Rotate
            // 
            this.toolStripMenuItem_Rotate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox_RotateValue});
            this.toolStripMenuItem_Rotate.Name = "toolStripMenuItem_Rotate";
            this.toolStripMenuItem_Rotate.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_Rotate.Text = "Rotate";
            // 
            // toolStripTextBox_RotateValue
            // 
            this.toolStripTextBox_RotateValue.Name = "toolStripTextBox_RotateValue";
            this.toolStripTextBox_RotateValue.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox_RotateValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox1_KeyDown);
            // 
            // toolStripMenuItem_Zoom
            // 
            this.toolStripMenuItem_Zoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox_ZoomValue});
            this.toolStripMenuItem_Zoom.Name = "toolStripMenuItem_Zoom";
            this.toolStripMenuItem_Zoom.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_Zoom.Text = "Zoom";
            // 
            // toolStripTextBox_ZoomValue
            // 
            this.toolStripTextBox_ZoomValue.Name = "toolStripTextBox_ZoomValue";
            this.toolStripTextBox_ZoomValue.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox_ZoomValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox2_KeyDown);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(623, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(209, 490);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem_Cut
            // 
            this.toolStripMenuItem_Cut.Name = "toolStripMenuItem_Cut";
            this.toolStripMenuItem_Cut.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_Cut.Text = "Cut";
            this.toolStripMenuItem_Cut.Click += new System.EventHandler(this.toolStripMenuItem_Cut_Click);
            // 
            // toolStripMenuItem_CutCompete
            // 
            this.toolStripMenuItem_CutCompete.Name = "toolStripMenuItem_CutCompete";
            this.toolStripMenuItem_CutCompete.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_CutCompete.Text = "Cut Compete";
            this.toolStripMenuItem_CutCompete.Click += new System.EventHandler(this.toolStripMenuItem_CutCompete_Click);
            // 
            // PolygonPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.myPanel1);
            this.Name = "PolygonPanel";
            this.Size = new System.Drawing.Size(835, 496);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MyPanel myPanel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_New;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Complete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Clear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Rotate;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_RotateValue;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Zoom;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_ZoomValue;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Cut;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_CutCompete;
    }
}
