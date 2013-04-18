namespace Information_analysis_of_university
{
    partial class MainForm
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
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("Модель потоков данных");
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("Модель вариантов использования");
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("Модель нагрузки рабочих мест");
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("Объектная модель");
            System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("Потоки данных", new System.Windows.Forms.TreeNode[] {
            treeNode45,
            treeNode46,
            treeNode47,
            treeNode48});
            System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode("Модель жизненного цикла");
            System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode("Модель распределения обязательств");
            System.Windows.Forms.TreeNode treeNode52 = new System.Windows.Forms.TreeNode("Модель рабочих процессов");
            System.Windows.Forms.TreeNode treeNode53 = new System.Windows.Forms.TreeNode("Oбъектная модель");
            System.Windows.Forms.TreeNode treeNode54 = new System.Windows.Forms.TreeNode("Документы", new System.Windows.Forms.TreeNode[] {
            treeNode50,
            treeNode51,
            treeNode52,
            treeNode53});
            System.Windows.Forms.TreeNode treeNode55 = new System.Windows.Forms.TreeNode("Node2");
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Reference = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBox1 = new System.Windows.Forms.GroupBox();
            this.treeMenu = new System.Windows.Forms.TreeView();
            this.groupModel = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupRequest = new System.Windows.Forms.GroupBox();
            this.panelReqest = new System.Windows.Forms.Panel();
            this.buttonMaster = new System.Windows.Forms.Button();
            this.buttonQBE = new System.Windows.Forms.Button();
            this.buttonSQL = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьМодельToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьМодельToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcModelsFrame = new System.Windows.Forms.TabControl();
            this.newTabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.menuBox1.SuspendLayout();
            this.groupModel.SuspendLayout();
            this.groupRequest.SuspendLayout();
            this.panelReqest.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tcModelsFrame.SuspendLayout();
            this.newTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem,
            this.HelpItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(903, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItem
            // 
            this.MenuItem.Name = "MenuItem";
            this.MenuItem.Size = new System.Drawing.Size(53, 20);
            this.MenuItem.Text = "Меню";
            // 
            // HelpItem
            // 
            this.HelpItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Reference,
            this.aboutProgram});
            this.HelpItem.Name = "HelpItem";
            this.HelpItem.Size = new System.Drawing.Size(68, 20);
            this.HelpItem.Text = "Помощь";
            // 
            // Reference
            // 
            this.Reference.Name = "Reference";
            this.Reference.Size = new System.Drawing.Size(149, 22);
            this.Reference.Text = "Справка";
            // 
            // aboutProgram
            // 
            this.aboutProgram.Name = "aboutProgram";
            this.aboutProgram.Size = new System.Drawing.Size(149, 22);
            this.aboutProgram.Text = "О программе";
            // 
            // menuBox1
            // 
            this.menuBox1.Controls.Add(this.treeMenu);
            this.menuBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuBox1.Location = new System.Drawing.Point(0, 24);
            this.menuBox1.Name = "menuBox1";
            this.menuBox1.Size = new System.Drawing.Size(252, 378);
            this.menuBox1.TabIndex = 3;
            this.menuBox1.TabStop = false;
            this.menuBox1.Text = "Меню";
            this.menuBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // treeMenu
            // 
            this.treeMenu.BackColor = System.Drawing.SystemColors.Menu;
            this.treeMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeMenu.Location = new System.Drawing.Point(3, 16);
            this.treeMenu.Name = "treeMenu";
            treeNode45.Name = "modelDataStreams";
            treeNode45.Text = "Модель потоков данных";
            treeNode46.Name = "use-caseModel";
            treeNode46.Text = "Модель вариантов использования";
            treeNode47.Name = "modelForJob";
            treeNode47.Text = "Модель нагрузки рабочих мест";
            treeNode48.Name = "objectModelFlows";
            treeNode48.Text = "Объектная модель";
            treeNode49.Name = "dataStreams";
            treeNode49.Text = "Потоки данных";
            treeNode50.Name = "life-cycleModel";
            treeNode50.Text = "Модель жизненного цикла";
            treeNode51.Name = "modelObligations";
            treeNode51.Text = "Модель распределения обязательств";
            treeNode52.Name = "workflowModel";
            treeNode52.Text = "Модель рабочих процессов";
            treeNode53.Name = "documentObjectModel";
            treeNode53.Text = "Oбъектная модель";
            treeNode54.Name = "Node1";
            treeNode54.Text = "Документы";
            treeNode55.Name = "Node2";
            treeNode55.Text = "Node2";
            this.treeMenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode49,
            treeNode54,
            treeNode55});
            this.treeMenu.Size = new System.Drawing.Size(243, 359);
            this.treeMenu.TabIndex = 0;
            this.treeMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // groupModel
            // 
            this.groupModel.Controls.Add(this.button1);
            this.groupModel.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupModel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupModel.Location = new System.Drawing.Point(252, 24);
            this.groupModel.Name = "groupModel";
            this.groupModel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupModel.Size = new System.Drawing.Size(651, 34);
            this.groupModel.TabIndex = 4;
            this.groupModel.TabStop = false;
            this.groupModel.Text = "Модели";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(89, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupRequest
            // 
            this.groupRequest.Controls.Add(this.panelReqest);
            this.groupRequest.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupRequest.Location = new System.Drawing.Point(252, 265);
            this.groupRequest.Name = "groupRequest";
            this.groupRequest.Size = new System.Drawing.Size(651, 137);
            this.groupRequest.TabIndex = 5;
            this.groupRequest.TabStop = false;
            this.groupRequest.Text = "Панель запросов";
            // 
            // panelReqest
            // 
            this.panelReqest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelReqest.Controls.Add(this.buttonMaster);
            this.panelReqest.Controls.Add(this.buttonQBE);
            this.panelReqest.Controls.Add(this.buttonSQL);
            this.panelReqest.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelReqest.Location = new System.Drawing.Point(3, 16);
            this.panelReqest.Name = "panelReqest";
            this.panelReqest.Size = new System.Drawing.Size(645, 45);
            this.panelReqest.TabIndex = 0;
            // 
            // buttonMaster
            // 
            this.buttonMaster.Location = new System.Drawing.Point(165, 3);
            this.buttonMaster.Name = "buttonMaster";
            this.buttonMaster.Size = new System.Drawing.Size(75, 35);
            this.buttonMaster.TabIndex = 2;
            this.buttonMaster.Text = "Матер";
            this.buttonMaster.UseVisualStyleBackColor = true;
            // 
            // buttonQBE
            // 
            this.buttonQBE.Location = new System.Drawing.Point(84, 3);
            this.buttonQBE.Name = "buttonQBE";
            this.buttonQBE.Size = new System.Drawing.Size(75, 35);
            this.buttonQBE.TabIndex = 1;
            this.buttonQBE.Text = "QBE";
            this.buttonQBE.UseVisualStyleBackColor = true;
            // 
            // buttonSQL
            // 
            this.buttonSQL.Location = new System.Drawing.Point(3, 3);
            this.buttonSQL.Name = "buttonSQL";
            this.buttonSQL.Size = new System.Drawing.Size(75, 35);
            this.buttonSQL.TabIndex = 0;
            this.buttonSQL.Text = "SQL";
            this.buttonSQL.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьМодельToolStripMenuItem,
            this.удалитьМодельToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(127, 48);
            // 
            // добавитьМодельToolStripMenuItem
            // 
            this.добавитьМодельToolStripMenuItem.Name = "добавитьМодельToolStripMenuItem";
            this.добавитьМодельToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.добавитьМодельToolStripMenuItem.Text = "Добавить";
            // 
            // удалитьМодельToolStripMenuItem
            // 
            this.удалитьМодельToolStripMenuItem.Name = "удалитьМодельToolStripMenuItem";
            this.удалитьМодельToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.удалитьМодельToolStripMenuItem.Text = "Удалить";
            // 
            // tcModelsFrame
            // 
            this.tcModelsFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcModelsFrame.Controls.Add(this.newTabPage1);
            this.tcModelsFrame.Location = new System.Drawing.Point(255, 59);
            this.tcModelsFrame.Name = "tcModelsFrame";
            this.tcModelsFrame.SelectedIndex = 0;
            this.tcModelsFrame.Size = new System.Drawing.Size(647, 206);
            this.tcModelsFrame.TabIndex = 6;
            // 
            // newTabPage1
            // 
            this.newTabPage1.Controls.Add(this.pictureBox1);
            this.newTabPage1.Location = new System.Drawing.Point(4, 22);
            this.newTabPage1.Name = "newTabPage1";
            this.newTabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.newTabPage1.Size = new System.Drawing.Size(639, 180);
            this.newTabPage1.TabIndex = 0;
            this.newTabPage1.Text = "new1";
            this.newTabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1000, 500);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(903, 402);
            this.Controls.Add(this.tcModelsFrame);
            this.Controls.Add(this.groupRequest);
            this.Controls.Add(this.groupModel);
            this.Controls.Add(this.menuBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Анализ информационного обеспечения университета";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuBox1.ResumeLayout(false);
            this.groupModel.ResumeLayout(false);
            this.groupRequest.ResumeLayout(false);
            this.panelReqest.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tcModelsFrame.ResumeLayout(false);
            this.newTabPage1.ResumeLayout(false);
            this.newTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpItem;
        private System.Windows.Forms.ToolStripMenuItem Reference;
        private System.Windows.Forms.ToolStripMenuItem aboutProgram;
        private System.Windows.Forms.GroupBox menuBox1;
        private System.Windows.Forms.GroupBox groupModel;
        private System.Windows.Forms.GroupBox groupRequest;
        private System.Windows.Forms.TreeView treeMenu;
        private System.Windows.Forms.Panel panelReqest;
        private System.Windows.Forms.Button buttonMaster;
        private System.Windows.Forms.Button buttonQBE;
        private System.Windows.Forms.Button buttonSQL;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавитьМодельToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьМодельToolStripMenuItem;
        private System.Windows.Forms.TabControl tcModelsFrame;
        private System.Windows.Forms.TabPage newTabPage1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

