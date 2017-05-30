namespace Tralala
{
    partial class traFrmLiter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(traFrmLiter));
            this.input = new System.Windows.Forms.TextBox();
            this.cmdOk = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // input
            // 
            this.input.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.input.Dock = System.Windows.Forms.DockStyle.Top;
            this.input.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.input.Location = new System.Drawing.Point(0, 0);
            this.input.Multiline = true;
            this.input.Name = "input";
            this.input.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.input.Size = new System.Drawing.Size(381, 329);
            this.input.TabIndex = 0;
            this.input.WordWrap = false;
            // 
            // cmdOk
            // 
            this.cmdOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdOk.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmdOk.Location = new System.Drawing.Point(12, 335);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(357, 21);
            this.cmdOk.TabIndex = 1;
            this.cmdOk.Text = "写好了点这里";
            this.cmdOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // traFrmLiter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 364);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.input);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "traFrmLiter";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "自定义文法";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.traFrmLiter_FormClosing);
            this.Load += new System.EventHandler(this.traFrmLiter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox input;
        private System.Windows.Forms.Label cmdOk;
    }
}