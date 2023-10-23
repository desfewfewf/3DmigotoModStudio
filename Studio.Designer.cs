namespace _3DmigotoModStudio
{
    partial class Studio
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tryExtractibvbFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standardFormattingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewElementList = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.generateVertexShaderCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateIndexBufferSkipModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateIndexBufferSkipModByFirstIndexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.moveIndexBufferRelatedFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.openFileDialogJson = new System.Windows.Forms.OpenFileDialog();
            this.ElementOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SemanticName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtractSemanticName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SemanticIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutputSemanticIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Format = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InputSlot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InputSlotClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InstanceDataStepRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ByteWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtractVertexBufferSlot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtractTopology = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.tabConfig.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewElementList)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBox1);
            this.tabPage3.Controls.Add(this.menuStrip2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(792, 424);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Shader Editor";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 27);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(786, 394);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.Gray;
            this.menuStrip2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.editToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.runToolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(3, 3);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(786, 24);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.BackColor = System.Drawing.Color.Gray;
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(38, 20);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // runToolStripMenuItem1
            // 
            this.runToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tryExtractibvbFileToolStripMenuItem,
            this.standardFormattingToolStripMenuItem});
            this.runToolStripMenuItem1.Name = "runToolStripMenuItem1";
            this.runToolStripMenuItem1.Size = new System.Drawing.Size(41, 20);
            this.runToolStripMenuItem1.Text = "Run";
            // 
            // tryExtractibvbFileToolStripMenuItem
            // 
            this.tryExtractibvbFileToolStripMenuItem.Name = "tryExtractibvbFileToolStripMenuItem";
            this.tryExtractibvbFileToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.tryExtractibvbFileToolStripMenuItem.Text = "Try Extract .ib and .vb File";
            // 
            // standardFormattingToolStripMenuItem
            // 
            this.standardFormattingToolStripMenuItem.Name = "standardFormattingToolStripMenuItem";
            this.standardFormattingToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.standardFormattingToolStripMenuItem.Text = "Standard Formatting";
            // 
            // tabConfig
            // 
            this.tabConfig.AccessibleName = "";
            this.tabConfig.Controls.Add(this.tabControl2);
            this.tabConfig.Controls.Add(this.menuStrip1);
            this.tabConfig.Location = new System.Drawing.Point(4, 22);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfig.Size = new System.Drawing.Size(787, 475);
            this.tabConfig.TabIndex = 0;
            this.tabConfig.Text = "Mod Making";
            this.tabConfig.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 27);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(781, 445);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridViewElementList);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(773, 419);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "D3D11 Elements";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewElementList
            // 
            this.dataGridViewElementList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewElementList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ElementOrder,
            this.SemanticName,
            this.ExtractSemanticName,
            this.SemanticIndex,
            this.OutputSemanticIndex,
            this.Format,
            this.InputSlot,
            this.InputSlotClass,
            this.InstanceDataStepRate,
            this.ByteWidth,
            this.ExtractVertexBufferSlot,
            this.ExtractTopology,
            this.Category});
            this.dataGridViewElementList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewElementList.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewElementList.Name = "dataGridViewElementList";
            this.dataGridViewElementList.Size = new System.Drawing.Size(767, 413);
            this.dataGridViewElementList.TabIndex = 0;
            this.dataGridViewElementList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewElementList_CellContentClick);
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(778, 368);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Config";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.richTextBox3);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(778, 368);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Run Output";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // richTextBox3
            // 
            this.richTextBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox3.Location = new System.Drawing.Point(3, 3);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(772, 362);
            this.richTextBox3.TabIndex = 0;
            this.richTextBox3.Text = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(778, 368);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Output ini File";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Location = new System.Drawing.Point(3, 3);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(772, 362);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Gray;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem,
            this.runToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(781, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.cleanToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            // 
            // cleanToolStripMenuItem
            // 
            this.cleanToolStripMenuItem.Name = "cleanToolStripMenuItem";
            this.cleanToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.cleanToolStripMenuItem.Text = "Clean";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractModelToolStripMenuItem,
            this.generateModToolStripMenuItem,
            this.toolStripSeparator1,
            this.generateVertexShaderCheckToolStripMenuItem,
            this.generateIndexBufferSkipModToolStripMenuItem,
            this.generateIndexBufferSkipModByFirstIndexToolStripMenuItem,
            this.toolStripSeparator2,
            this.moveIndexBufferRelatedFilesToolStripMenuItem});
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.runToolStripMenuItem.Text = "Run";
            // 
            // extractModelToolStripMenuItem
            // 
            this.extractModelToolStripMenuItem.Name = "extractModelToolStripMenuItem";
            this.extractModelToolStripMenuItem.Size = new System.Drawing.Size(333, 22);
            this.extractModelToolStripMenuItem.Text = "Extract Model";
            // 
            // generateModToolStripMenuItem
            // 
            this.generateModToolStripMenuItem.Name = "generateModToolStripMenuItem";
            this.generateModToolStripMenuItem.Size = new System.Drawing.Size(333, 22);
            this.generateModToolStripMenuItem.Text = "Generate Mod";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(330, 6);
            // 
            // generateVertexShaderCheckToolStripMenuItem
            // 
            this.generateVertexShaderCheckToolStripMenuItem.Name = "generateVertexShaderCheckToolStripMenuItem";
            this.generateVertexShaderCheckToolStripMenuItem.Size = new System.Drawing.Size(333, 22);
            this.generateVertexShaderCheckToolStripMenuItem.Text = "Generate Vertex Shader Check";
            // 
            // generateIndexBufferSkipModToolStripMenuItem
            // 
            this.generateIndexBufferSkipModToolStripMenuItem.Name = "generateIndexBufferSkipModToolStripMenuItem";
            this.generateIndexBufferSkipModToolStripMenuItem.Size = new System.Drawing.Size(333, 22);
            this.generateIndexBufferSkipModToolStripMenuItem.Text = "Generate Index Buffer Skip Mod";
            // 
            // generateIndexBufferSkipModByFirstIndexToolStripMenuItem
            // 
            this.generateIndexBufferSkipModByFirstIndexToolStripMenuItem.Name = "generateIndexBufferSkipModByFirstIndexToolStripMenuItem";
            this.generateIndexBufferSkipModByFirstIndexToolStripMenuItem.Size = new System.Drawing.Size(333, 22);
            this.generateIndexBufferSkipModByFirstIndexToolStripMenuItem.Text = "Generate Index Buffer Skip Mod By FirstIndex";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(330, 6);
            // 
            // moveIndexBufferRelatedFilesToolStripMenuItem
            // 
            this.moveIndexBufferRelatedFilesToolStripMenuItem.Name = "moveIndexBufferRelatedFilesToolStripMenuItem";
            this.moveIndexBufferRelatedFilesToolStripMenuItem.Size = new System.Drawing.Size(333, 22);
            this.moveIndexBufferRelatedFilesToolStripMenuItem.Text = "Move Index Buffer Related Files";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabConfig);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(795, 501);
            this.tabControl1.TabIndex = 1;
            // 
            // openFileDialogJson
            // 
            this.openFileDialogJson.Filter = "Json Configs|*.json";
            // 
            // ElementOrder
            // 
            this.ElementOrder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ElementOrder.HeaderText = "ElementOrder";
            this.ElementOrder.Name = "ElementOrder";
            this.ElementOrder.Width = 96;
            // 
            // SemanticName
            // 
            this.SemanticName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SemanticName.HeaderText = "SemanticName";
            this.SemanticName.Name = "SemanticName";
            this.SemanticName.Width = 104;
            // 
            // ExtractSemanticName
            // 
            this.ExtractSemanticName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ExtractSemanticName.HeaderText = "ExtractSemanticName";
            this.ExtractSemanticName.Name = "ExtractSemanticName";
            this.ExtractSemanticName.Width = 137;
            // 
            // SemanticIndex
            // 
            this.SemanticIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SemanticIndex.HeaderText = "SemanticIndex";
            this.SemanticIndex.Name = "SemanticIndex";
            this.SemanticIndex.Width = 102;
            // 
            // OutputSemanticIndex
            // 
            this.OutputSemanticIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.OutputSemanticIndex.HeaderText = "OutputSemanticIndex";
            this.OutputSemanticIndex.Name = "OutputSemanticIndex";
            this.OutputSemanticIndex.Width = 134;
            // 
            // Format
            // 
            this.Format.HeaderText = "Format";
            this.Format.Name = "Format";
            this.Format.Width = 150;
            // 
            // InputSlot
            // 
            this.InputSlot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.InputSlot.HeaderText = "InputSlot";
            this.InputSlot.Name = "InputSlot";
            this.InputSlot.Width = 74;
            // 
            // InputSlotClass
            // 
            this.InputSlotClass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.InputSlotClass.HeaderText = "InputSlotClass";
            this.InputSlotClass.Name = "InputSlotClass";
            this.InputSlotClass.Width = 99;
            // 
            // InstanceDataStepRate
            // 
            this.InstanceDataStepRate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.InstanceDataStepRate.HeaderText = "InstanceDataStepRate";
            this.InstanceDataStepRate.Name = "InstanceDataStepRate";
            this.InstanceDataStepRate.Width = 141;
            // 
            // ByteWidth
            // 
            this.ByteWidth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ByteWidth.HeaderText = "ByteWidth";
            this.ByteWidth.Name = "ByteWidth";
            this.ByteWidth.Width = 81;
            // 
            // ExtractVertexBufferSlot
            // 
            this.ExtractVertexBufferSlot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ExtractVertexBufferSlot.HeaderText = "ExtractVertexBufferSlot";
            this.ExtractVertexBufferSlot.Name = "ExtractVertexBufferSlot";
            this.ExtractVertexBufferSlot.Width = 141;
            // 
            // ExtractTopology
            // 
            this.ExtractTopology.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ExtractTopology.HeaderText = "ExtractTopology";
            this.ExtractTopology.Name = "ExtractTopology";
            this.ExtractTopology.Width = 109;
            // 
            // Category
            // 
            this.Category.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.Width = 74;
            // 
            // Studio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 501);
            this.Controls.Add(this.tabControl1);
            this.Name = "Studio";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.tabConfig.ResumeLayout(false);
            this.tabConfig.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewElementList)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage3;
        public System.Windows.Forms.TabPage tabConfig;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cleanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractModelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateModToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem generateVertexShaderCheckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateIndexBufferSkipModToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateIndexBufferSkipModByFirstIndexToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem moveIndexBufferRelatedFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tryExtractibvbFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standardFormattingToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.DataGridView dataGridViewElementList;
        private System.Windows.Forms.OpenFileDialog openFileDialogJson;
        private System.Windows.Forms.DataGridViewTextBoxColumn ElementOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn SemanticName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtractSemanticName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SemanticIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutputSemanticIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Format;
        private System.Windows.Forms.DataGridViewTextBoxColumn InputSlot;
        private System.Windows.Forms.DataGridViewTextBoxColumn InputSlotClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstanceDataStepRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ByteWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtractVertexBufferSlot;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtractTopology;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
    }
}

