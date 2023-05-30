namespace Assignment1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawingCommandGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ifStatementGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loopCommandGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.methodCOmmandGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extraCommandsGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.userInput = new System.Windows.Forms.TextBox();
            this.errorBox = new System.Windows.Forms.TextBox();
            this.outputWindow = new System.Windows.Forms.Panel();
            this.typeRun = new System.Windows.Forms.TextBox();
            this.Clear = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.Run = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(46, 26);
            this.menuToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click_1);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawingCommandGuideToolStripMenuItem,
            this.ifStatementGuideToolStripMenuItem,
            this.loopCommandGuideToolStripMenuItem,
            this.methodCOmmandGuideToolStripMenuItem,
            this.extraCommandsGuideToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 26);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // drawingCommandGuideToolStripMenuItem
            // 
            this.drawingCommandGuideToolStripMenuItem.Name = "drawingCommandGuideToolStripMenuItem";
            this.drawingCommandGuideToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.drawingCommandGuideToolStripMenuItem.Text = "Drawing Command Guide";
            this.drawingCommandGuideToolStripMenuItem.Click += new System.EventHandler(this.drawingCommandGuideToolStripMenuItem_Click);
            // 
            // ifStatementGuideToolStripMenuItem
            // 
            this.ifStatementGuideToolStripMenuItem.Name = "ifStatementGuideToolStripMenuItem";
            this.ifStatementGuideToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.ifStatementGuideToolStripMenuItem.Text = "If Statement Guide";
            this.ifStatementGuideToolStripMenuItem.Click += new System.EventHandler(this.ifStatementGuideToolStripMenuItem_Click);
            // 
            // loopCommandGuideToolStripMenuItem
            // 
            this.loopCommandGuideToolStripMenuItem.Name = "loopCommandGuideToolStripMenuItem";
            this.loopCommandGuideToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.loopCommandGuideToolStripMenuItem.Text = "Loop Command Guide";
            this.loopCommandGuideToolStripMenuItem.Click += new System.EventHandler(this.loopCommandGuideToolStripMenuItem_Click);
            // 
            // methodCOmmandGuideToolStripMenuItem
            // 
            this.methodCOmmandGuideToolStripMenuItem.Name = "methodCOmmandGuideToolStripMenuItem";
            this.methodCOmmandGuideToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.methodCOmmandGuideToolStripMenuItem.Text = "Method Command Guide";
            this.methodCOmmandGuideToolStripMenuItem.Click += new System.EventHandler(this.methodCOmmandGuideToolStripMenuItem_Click);
            // 
            // extraCommandsGuideToolStripMenuItem
            // 
            this.extraCommandsGuideToolStripMenuItem.Name = "extraCommandsGuideToolStripMenuItem";
            this.extraCommandsGuideToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.extraCommandsGuideToolStripMenuItem.Text = "Other Commands";
            this.extraCommandsGuideToolStripMenuItem.Click += new System.EventHandler(this.extraCommandsGuideToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // userInput
            // 
            this.userInput.BackColor = System.Drawing.SystemColors.InfoText;
            this.userInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInput.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.userInput.Location = new System.Drawing.Point(12, 42);
            this.userInput.Multiline = true;
            this.userInput.Name = "userInput";
            this.userInput.Size = new System.Drawing.Size(295, 466);
            this.userInput.TabIndex = 2;
            // 
            // errorBox
            // 
            this.errorBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.errorBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorBox.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.errorBox.Location = new System.Drawing.Point(12, 584);
            this.errorBox.Multiline = true;
            this.errorBox.Name = "errorBox";
            this.errorBox.Size = new System.Drawing.Size(1061, 129);
            this.errorBox.TabIndex = 3;
            // 
            // outputWindow
            // 
            this.outputWindow.BackColor = System.Drawing.SystemColors.ControlLight;
            this.outputWindow.Location = new System.Drawing.Point(313, 42);
            this.outputWindow.Name = "outputWindow";
            this.outputWindow.Size = new System.Drawing.Size(865, 466);
            this.outputWindow.TabIndex = 4;
            // 
            // typeRun
            // 
            this.typeRun.BackColor = System.Drawing.SystemColors.InfoText;
            this.typeRun.ForeColor = System.Drawing.SystemColors.Window;
            this.typeRun.Location = new System.Drawing.Point(12, 523);
            this.typeRun.Multiline = true;
            this.typeRun.Name = "typeRun";
            this.typeRun.Size = new System.Drawing.Size(188, 47);
            this.typeRun.TabIndex = 5;
            // 
            // Clear
            // 
            this.Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clear.Location = new System.Drawing.Point(596, 532);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 38);
            this.Clear.TabIndex = 7;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Reset
            // 
            this.Reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reset.Location = new System.Drawing.Point(677, 532);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(99, 38);
            this.Reset.TabIndex = 8;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // Run
            // 
            this.Run.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Run.Location = new System.Drawing.Point(208, 532);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(99, 38);
            this.Run.TabIndex = 9;
            this.Run.Text = "Run";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(1200, 725);
            this.Controls.Add(this.Run);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.typeRun);
            this.Controls.Add(this.outputWindow);
            this.Controls.Add(this.errorBox);
            this.Controls.Add(this.userInput);
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

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox userInput;
        private System.Windows.Forms.TextBox errorBox;
        private System.Windows.Forms.Panel outputWindow;
        private System.Windows.Forms.TextBox typeRun;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawingCommandGuideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ifStatementGuideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loopCommandGuideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem methodCOmmandGuideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extraCommandsGuideToolStripMenuItem;
    }
}

