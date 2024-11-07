namespace baicuoiki2
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quảnLýPhiếuXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýKháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTC = new System.Windows.Forms.Panel();
            this.quảnLýPhiếuXuấtToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýPhiếuXuấtToolStripMenuItem,
            this.quảnLýKháchHàngToolStripMenuItem,
            this.quảnLýPhiếuXuấtToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quảnLýPhiếuXuấtToolStripMenuItem
            // 
            this.quảnLýPhiếuXuấtToolStripMenuItem.Name = "quảnLýPhiếuXuấtToolStripMenuItem";
            this.quảnLýPhiếuXuấtToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.quảnLýPhiếuXuấtToolStripMenuItem.Text = "Quản lý Phiếu Xuất";
            this.quảnLýPhiếuXuấtToolStripMenuItem.Click += new System.EventHandler(this.quảnLýPhiếuXuấtToolStripMenuItem_Click);
            // 
            // quảnLýKháchHàngToolStripMenuItem
            // 
            this.quảnLýKháchHàngToolStripMenuItem.Name = "quảnLýKháchHàngToolStripMenuItem";
            this.quảnLýKháchHàngToolStripMenuItem.Size = new System.Drawing.Size(157, 24);
            this.quảnLýKháchHàngToolStripMenuItem.Text = "Quản lý Khách Hàng";
            this.quảnLýKháchHàngToolStripMenuItem.Click += new System.EventHandler(this.quảnLýKháchHàngToolStripMenuItem_Click);
            // 
            // panelTC
            // 
            this.panelTC.Location = new System.Drawing.Point(0, 53);
            this.panelTC.Name = "panelTC";
            this.panelTC.Size = new System.Drawing.Size(800, 397);
            this.panelTC.TabIndex = 2;
            this.panelTC.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTC_Paint);
            // 
            // quảnLýPhiếuXuấtToolStripMenuItem1
            // 
            this.quảnLýPhiếuXuấtToolStripMenuItem1.Name = "quảnLýPhiếuXuấtToolStripMenuItem1";
            this.quảnLýPhiếuXuấtToolStripMenuItem1.Size = new System.Drawing.Size(146, 24);
            this.quảnLýPhiếuXuấtToolStripMenuItem1.Text = "Quản lý phiếu xuất";
            this.quảnLýPhiếuXuấtToolStripMenuItem1.Click += new System.EventHandler(this.quảnLýPhiếuXuấtToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelTC);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýPhiếuXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýKháchHàngToolStripMenuItem;
        private System.Windows.Forms.Panel panelTC; // Khai báo panelTC tại đây
        private System.Windows.Forms.ToolStripMenuItem quảnLýPhiếuXuấtToolStripMenuItem1;
    }
}
