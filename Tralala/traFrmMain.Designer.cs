namespace Tralala
{
    partial class traFrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(traFrmMain));
            this.rootSpliter = new System.Windows.Forms.SplitContainer();
            this.userSpliter = new System.Windows.Forms.SplitContainer();
            this.codes = new System.Windows.Forms.RichTextBox();
            this.logs = new System.Windows.Forms.RichTextBox();
            this.mouseMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmdCopyLog = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdClearLog = new System.Windows.Forms.ToolStripMenuItem();
            this.outputSpliter = new System.Windows.Forms.SplitContainer();
            this.tokens = new System.Windows.Forms.ListView();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAnalyse = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdLexical = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdSyntax = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.tips = new System.Windows.Forms.ToolStripStatusLabel();
            this.syntaxs = new System.Windows.Forms.ListView();
            this.cmdImportCode = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdExportLog = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdExit = new System.Windows.Forms.ToolStripMenuItem();
            this.opener = new System.Windows.Forms.OpenFileDialog();
            this.saver = new System.Windows.Forms.SaveFileDialog();
            this.cmdImportLit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdInputLit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.rootSpliter)).BeginInit();
            this.rootSpliter.Panel1.SuspendLayout();
            this.rootSpliter.Panel2.SuspendLayout();
            this.rootSpliter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userSpliter)).BeginInit();
            this.userSpliter.Panel1.SuspendLayout();
            this.userSpliter.Panel2.SuspendLayout();
            this.userSpliter.SuspendLayout();
            this.mouseMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outputSpliter)).BeginInit();
            this.outputSpliter.Panel1.SuspendLayout();
            this.outputSpliter.Panel2.SuspendLayout();
            this.outputSpliter.SuspendLayout();
            this.menu.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // rootSpliter
            // 
            this.rootSpliter.Dock = System.Windows.Forms.DockStyle.Top;
            this.rootSpliter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.rootSpliter.ForeColor = System.Drawing.SystemColors.Control;
            this.rootSpliter.Location = new System.Drawing.Point(0, 25);
            this.rootSpliter.Name = "rootSpliter";
            // 
            // rootSpliter.Panel1
            // 
            this.rootSpliter.Panel1.CausesValidation = false;
            this.rootSpliter.Panel1.Controls.Add(this.userSpliter);
            this.rootSpliter.Panel1.ForeColor = System.Drawing.SystemColors.Control;
            this.rootSpliter.Panel1MinSize = 300;
            // 
            // rootSpliter.Panel2
            // 
            this.rootSpliter.Panel2.Controls.Add(this.outputSpliter);
            this.rootSpliter.Panel2.ForeColor = System.Drawing.SystemColors.Control;
            this.rootSpliter.Panel2MinSize = 300;
            this.rootSpliter.Size = new System.Drawing.Size(944, 551);
            this.rootSpliter.SplitterDistance = 639;
            this.rootSpliter.TabIndex = 0;
            this.rootSpliter.TabStop = false;
            // 
            // userSpliter
            // 
            this.userSpliter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.userSpliter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userSpliter.Location = new System.Drawing.Point(0, 0);
            this.userSpliter.Name = "userSpliter";
            this.userSpliter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // userSpliter.Panel1
            // 
            this.userSpliter.Panel1.Controls.Add(this.logs);
            this.userSpliter.Panel1MinSize = 100;
            // 
            // userSpliter.Panel2
            // 
            this.userSpliter.Panel2.Controls.Add(this.codes);
            this.userSpliter.Panel2MinSize = 50;
            this.userSpliter.Size = new System.Drawing.Size(639, 551);
            this.userSpliter.SplitterDistance = 416;
            this.userSpliter.TabIndex = 0;
            this.userSpliter.TabStop = false;
            // 
            // codes
            // 
            this.codes.AcceptsTab = true;
            this.codes.BackColor = System.Drawing.Color.White;
            this.codes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codes.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.codes.Location = new System.Drawing.Point(0, 0);
            this.codes.Name = "codes";
            this.codes.Size = new System.Drawing.Size(635, 127);
            this.codes.TabIndex = 0;
            this.codes.Text = "";
            this.codes.WordWrap = false;
            this.codes.SelectionChanged += new System.EventHandler(this.codes_SelectionChanged);
            this.codes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codes_KeyPress);
            // 
            // logs
            // 
            this.logs.BackColor = System.Drawing.Color.White;
            this.logs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logs.ContextMenuStrip = this.mouseMenu;
            this.logs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logs.Location = new System.Drawing.Point(0, 0);
            this.logs.Name = "logs";
            this.logs.ReadOnly = true;
            this.logs.Size = new System.Drawing.Size(635, 412);
            this.logs.TabIndex = 0;
            this.logs.TabStop = false;
            this.logs.Text = "";
            this.logs.WordWrap = false;
            // 
            // mouseMenu
            // 
            this.mouseMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdCopyLog,
            this.cmdClearLog});
            this.mouseMenu.Name = "mouseMenu";
            this.mouseMenu.Size = new System.Drawing.Size(125, 48);
            // 
            // cmdCopyLog
            // 
            this.cmdCopyLog.Name = "cmdCopyLog";
            this.cmdCopyLog.Size = new System.Drawing.Size(124, 22);
            this.cmdCopyLog.Text = "复制日志";
            this.cmdCopyLog.Click += new System.EventHandler(this.cmdCopyLog_Click);
            // 
            // cmdClearLog
            // 
            this.cmdClearLog.Name = "cmdClearLog";
            this.cmdClearLog.Size = new System.Drawing.Size(124, 22);
            this.cmdClearLog.Text = "清空日志";
            this.cmdClearLog.Click += new System.EventHandler(this.cmdClearLog_Click);
            // 
            // outputSpliter
            // 
            this.outputSpliter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.outputSpliter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputSpliter.Location = new System.Drawing.Point(0, 0);
            this.outputSpliter.Name = "outputSpliter";
            this.outputSpliter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // outputSpliter.Panel1
            // 
            this.outputSpliter.Panel1.Controls.Add(this.tokens);
            this.outputSpliter.Panel1MinSize = 100;
            // 
            // outputSpliter.Panel2
            // 
            this.outputSpliter.Panel2.Controls.Add(this.syntaxs);
            this.outputSpliter.Panel2MinSize = 100;
            this.outputSpliter.Size = new System.Drawing.Size(301, 551);
            this.outputSpliter.SplitterDistance = 270;
            this.outputSpliter.TabIndex = 0;
            this.outputSpliter.TabStop = false;
            // 
            // tokens
            // 
            this.tokens.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tokens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tokens.FullRowSelect = true;
            this.tokens.Location = new System.Drawing.Point(0, 0);
            this.tokens.MultiSelect = false;
            this.tokens.Name = "tokens";
            this.tokens.Size = new System.Drawing.Size(297, 266);
            this.tokens.TabIndex = 0;
            this.tokens.TabStop = false;
            this.tokens.UseCompatibleStateImageBehavior = false;
            this.tokens.View = System.Windows.Forms.View.Details;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuAnalyse});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(944, 25);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdImportCode,
            this.cmdExportLog,
            this.cmdExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(58, 21);
            this.menuFile.Text = "文件(&F)";
            // 
            // menuAnalyse
            // 
            this.menuAnalyse.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdLexical,
            this.cmdSyntax});
            this.menuAnalyse.Name = "menuAnalyse";
            this.menuAnalyse.Size = new System.Drawing.Size(60, 21);
            this.menuAnalyse.Text = "分析(&A)";
            // 
            // cmdLexical
            // 
            this.cmdLexical.Name = "cmdLexical";
            this.cmdLexical.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
            this.cmdLexical.Size = new System.Drawing.Size(174, 22);
            this.cmdLexical.Text = "词法分析";
            this.cmdLexical.Click += new System.EventHandler(this.cmdLexical_Click);
            // 
            // cmdSyntax
            // 
            this.cmdSyntax.Name = "cmdSyntax";
            this.cmdSyntax.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.cmdSyntax.Size = new System.Drawing.Size(174, 22);
            this.cmdSyntax.Text = "语法分析";
            this.cmdSyntax.Click += new System.EventHandler(this.cmdSyntax_Click);
            // 
            // menuEdit
            // 
            this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdInputLit,
            this.cmdImportLit});
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(58, 21);
            this.menuEdit.Text = "文法(&L)";
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tips});
            this.statusBar.Location = new System.Drawing.Point(0, 579);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(944, 22);
            this.statusBar.TabIndex = 2;
            // 
            // tips
            // 
            this.tips.Name = "tips";
            this.tips.Size = new System.Drawing.Size(70, 17);
            this.tips.Text = "行 1    列 1";
            // 
            // syntaxs
            // 
            this.syntaxs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.syntaxs.FullRowSelect = true;
            this.syntaxs.LabelWrap = false;
            this.syntaxs.Location = new System.Drawing.Point(0, 0);
            this.syntaxs.MultiSelect = false;
            this.syntaxs.Name = "syntaxs";
            this.syntaxs.Size = new System.Drawing.Size(297, 273);
            this.syntaxs.TabIndex = 0;
            this.syntaxs.TabStop = false;
            this.syntaxs.UseCompatibleStateImageBehavior = false;
            this.syntaxs.View = System.Windows.Forms.View.Details;
            // 
            // cmdImportCode
            // 
            this.cmdImportCode.Name = "cmdImportCode";
            this.cmdImportCode.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.cmdImportCode.Size = new System.Drawing.Size(169, 22);
            this.cmdImportCode.Text = "导入代码";
            this.cmdImportCode.Click += new System.EventHandler(this.cmdImportCode_Click);
            // 
            // cmdExportLog
            // 
            this.cmdExportLog.Name = "cmdExportLog";
            this.cmdExportLog.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.cmdExportLog.Size = new System.Drawing.Size(169, 22);
            this.cmdExportLog.Text = "导出日志";
            this.cmdExportLog.Click += new System.EventHandler(this.cmdExportLog_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.cmdExit.Size = new System.Drawing.Size(169, 22);
            this.cmdExit.Text = "退出程序";
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // opener
            // 
            this.opener.Filter = "文本文件|*.txt";
            this.opener.InitialDirectory = "%Desktop%";
            // 
            // saver
            // 
            this.saver.DefaultExt = "txt";
            this.saver.Filter = "文本文件|*.txt";
            // 
            // cmdImportLit
            // 
            this.cmdImportLit.Name = "cmdImportLit";
            this.cmdImportLit.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.L)));
            this.cmdImportLit.Size = new System.Drawing.Size(213, 22);
            this.cmdImportLit.Text = "从文件导入";
            this.cmdImportLit.Click += new System.EventHandler(this.CmdImportLit_Click);
            // 
            // cmdInputLit
            // 
            this.cmdInputLit.Name = "cmdInputLit";
            this.cmdInputLit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.cmdInputLit.Size = new System.Drawing.Size(213, 22);
            this.cmdInputLit.Text = "编辑文法";
            this.cmdInputLit.Click += new System.EventHandler(this.CmdInputLit_Click);
            // 
            // traFrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 601);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.rootSpliter);
            this.Controls.Add(this.menu);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(600, 480);
            this.Name = "traFrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tra词法语法分析器";
            this.Resize += new System.EventHandler(this.traFrmMain_Resize);
            this.rootSpliter.Panel1.ResumeLayout(false);
            this.rootSpliter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rootSpliter)).EndInit();
            this.rootSpliter.ResumeLayout(false);
            this.userSpliter.Panel1.ResumeLayout(false);
            this.userSpliter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userSpliter)).EndInit();
            this.userSpliter.ResumeLayout(false);
            this.mouseMenu.ResumeLayout(false);
            this.outputSpliter.Panel1.ResumeLayout(false);
            this.outputSpliter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.outputSpliter)).EndInit();
            this.outputSpliter.ResumeLayout(false);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer rootSpliter;
        private System.Windows.Forms.SplitContainer userSpliter;
        private System.Windows.Forms.SplitContainer outputSpliter;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.RichTextBox codes;
        private System.Windows.Forms.ToolStripMenuItem menuAnalyse;
        private System.Windows.Forms.ToolStripMenuItem cmdLexical;
        private System.Windows.Forms.ListView tokens;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel tips;
        private System.Windows.Forms.RichTextBox logs;
        private System.Windows.Forms.ContextMenuStrip mouseMenu;
        private System.Windows.Forms.ToolStripMenuItem cmdCopyLog;
        private System.Windows.Forms.ToolStripMenuItem cmdClearLog;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem cmdSyntax;
        private System.Windows.Forms.ListView syntaxs;
        private System.Windows.Forms.ToolStripMenuItem cmdImportCode;
        private System.Windows.Forms.ToolStripMenuItem cmdExportLog;
        private System.Windows.Forms.ToolStripMenuItem cmdExit;
        private System.Windows.Forms.OpenFileDialog opener;
        private System.Windows.Forms.SaveFileDialog saver;
        private System.Windows.Forms.ToolStripMenuItem cmdImportLit;
        private System.Windows.Forms.ToolStripMenuItem cmdInputLit;
    }
}

