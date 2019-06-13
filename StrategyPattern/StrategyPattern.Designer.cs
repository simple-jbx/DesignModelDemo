namespace DesignModelDemo
{
    partial class StrategyPattern
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StrategyPattern));
            this.panel3 = new DesignModelDemo.UCPanel();
            this.panel5 = new DesignModelDemo.UCPanel();
            this.panel4 = new DesignModelDemo.UCPanel();
            this.panel6 = new DesignModelDemo.UCPanel();
            this.panel1 = new DesignModelDemo.UCPanel();
            this.ucPanel2 = new DesignModelDemo.UCPanel();
            this.ucPanel3 = new DesignModelDemo.UCPanel();
            this.ucPanel1 = new DesignModelDemo.UCPanel();
            this.panel2 = new DesignModelDemo.UCPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Location = new System.Drawing.Point(654, 236);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(45, 147);
            this.panel3.TabIndex = 1;
            this.panel3.Visible = false;
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel5.Location = new System.Drawing.Point(0, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(45, 45);
            this.panel5.TabIndex = 1;
            this.panel5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel6_MouseClick);
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel4.Location = new System.Drawing.Point(0, 51);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(45, 45);
            this.panel4.TabIndex = 1;
            this.panel4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel6_MouseClick);
            // 
            // panel6
            // 
            this.panel6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel6.BackgroundImage")));
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel6.Location = new System.Drawing.Point(0, 99);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(45, 45);
            this.panel6.TabIndex = 1;
            this.panel6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel6_MouseClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.ucPanel2);
            this.panel1.Controls.Add(this.ucPanel3);
            this.panel1.Controls.Add(this.ucPanel1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(1, 389);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 62);
            this.panel1.TabIndex = 0;
            // 
            // ucPanel2
            // 
            this.ucPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ucPanel2.BackgroundImage")));
            this.ucPanel2.Location = new System.Drawing.Point(337, 9);
            this.ucPanel2.Name = "ucPanel2";
            this.ucPanel2.Size = new System.Drawing.Size(45, 45);
            this.ucPanel2.TabIndex = 2;
            // 
            // ucPanel3
            // 
            this.ucPanel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ucPanel3.BackgroundImage")));
            this.ucPanel3.Location = new System.Drawing.Point(408, 9);
            this.ucPanel3.Name = "ucPanel3";
            this.ucPanel3.Size = new System.Drawing.Size(45, 45);
            this.ucPanel3.TabIndex = 2;
            this.ucPanel3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ucPanel3_MouseClick);
            // 
            // ucPanel1
            // 
            this.ucPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ucPanel1.BackgroundImage")));
            this.ucPanel1.Location = new System.Drawing.Point(266, 9);
            this.ucPanel1.Name = "ucPanel1";
            this.ucPanel1.Size = new System.Drawing.Size(45, 45);
            this.ucPanel1.TabIndex = 1;
            this.ucPanel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ucPanel1_MouseClick);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Location = new System.Drawing.Point(653, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(45, 45);
            this.panel2.TabIndex = 0;
            this.panel2.Click += new System.EventHandler(this.panel2_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(799, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(1, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(799, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StrategyPattern
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "StrategyPattern";
            this.Text = "strategy";
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private UCPanel panel1;
        private UCPanel panel2;
        private UCPanel panel3;
        private UCPanel panel5;
        private UCPanel panel4;
        private UCPanel panel6;
        private UCPanel ucPanel2;
        private UCPanel ucPanel3;
        private UCPanel ucPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

