namespace Information_analysis_of_university
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Модель потоков данных");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Модель вариантов использования");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Модель нагрузки рабочих мест");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Объектная модель");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Потоки данных", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Модель жизненного цикла");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Модель распределения обязательств");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Модель рабочих процессов");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Oбъектная модель");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Документы", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Node2");
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Reference = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBox1 = new System.Windows.Forms.GroupBox();
            this.groupModel = new System.Windows.Forms.GroupBox();
            this.groupRequest = new System.Windows.Forms.GroupBox();
            this.treeMenu = new System.Windows.Forms.TreeView();
            this.panelReqest = new System.Windows.Forms.Panel();
            this.buttonSQL = new System.Windows.Forms.Button();
            this.buttonQBE = new System.Windows.Forms.Button();
            this.buttonMaster = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.menuBox1.SuspendLayout();
            this.groupRequest.SuspendLayout();
            this.panelReqest.SuspendLayout();
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
            this.Reference.Size = new System.Drawing.Size(152, 22);
            this.Reference.Text = "Справка";
            // 
            // aboutProgram
            // 
            this.aboutProgram.Name = "aboutProgram";
            this.aboutProgram.Size = new System.Drawing.Size(152, 22);
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
            // groupModel
            // 
            this.groupModel.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupModel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupModel.Location = new System.Drawing.Point(252, 24);
            this.groupModel.Name = "groupModel";
            this.groupModel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupModel.Size = new System.Drawing.Size(651, 58);
            this.groupModel.TabIndex = 4;
            this.groupModel.TabStop = false;
            this.groupModel.Text = "Модели";
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
            // treeMenu
            // 
            this.treeMenu.BackColor = System.Drawing.SystemColors.Menu;
            this.treeMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeMenu.Location = new System.Drawing.Point(3, 16);
            this.treeMenu.Name = "treeMenu";
            treeNode1.Name = "modelDataStreams";
            treeNode1.Text = "Модель потоков данных";
            treeNode2.Name = "use-caseModel";
            treeNode2.Text = "Модель вариантов использования";
            treeNode3.Name = "modelForJob";
            treeNode3.Text = "Модель нагрузки рабочих мест";
            treeNode4.Name = "objectModelFlows";
            treeNode4.Text = "Объектная модель";
            treeNode5.Name = "dataStreams";
            treeNode5.Text = "Потоки данных";
            treeNode6.Name = "life-cycleModel";
            treeNode6.Text = "Модель жизненного цикла";
            treeNode7.Name = "modelObligations";
            treeNode7.Text = "Модель распределения обязательств";
            treeNode8.Name = "workflowModel";
            treeNode8.Text = "Модель рабочих процессов";
            treeNode9.Name = "documentObjectModel";
            treeNode9.Text = "Oбъектная модель";
            treeNode10.Name = "Node1";
            treeNode10.Text = "Документы";
            treeNode11.Name = "Node2";
            treeNode11.Text = "Node2";
            this.treeMenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode10,
            treeNode11});
            this.treeMenu.Size = new System.Drawing.Size(243, 359);
            this.treeMenu.TabIndex = 0;
            this.treeMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
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
            // buttonSQL
            // 
            this.buttonSQL.Location = new System.Drawing.Point(3, 3);
            this.buttonSQL.Name = "buttonSQL";
            this.buttonSQL.Size = new System.Drawing.Size(75, 35);
            this.buttonSQL.TabIndex = 0;
            this.buttonSQL.Text = "SQL";
            this.buttonSQL.UseVisualStyleBackColor = true;
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
            // buttonMaster
            // 
            this.buttonMaster.Location = new System.Drawing.Point(165, 3);
            this.buttonMaster.Name = "buttonMaster";
            this.buttonMaster.Size = new System.Drawing.Size(75, 35);
            this.buttonMaster.TabIndex = 2;
            this.buttonMaster.Text = "Матер";
            this.buttonMaster.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(903, 402);
            this.Controls.Add(this.groupRequest);
            this.Controls.Add(this.groupModel);
            this.Controls.Add(this.menuBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Анализ информационного обеспечения университета";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuBox1.ResumeLayout(false);
            this.groupRequest.ResumeLayout(false);
            this.panelReqest.ResumeLayout(false);
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
    }
}

