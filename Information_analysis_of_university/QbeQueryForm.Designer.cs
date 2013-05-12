namespace Information_analysis_of_university
{
    partial class QbeQueryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QbeQueryForm));
            this.dGridQbeQuery = new System.Windows.Forms.DataGridView();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitExecute = new System.Windows.Forms.ToolStripSplitButton();
            this.выполнильToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выполнитьДляВсехМоделейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frequency = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.isElectronic = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isExternal = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.documentType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.responsible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.post = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isProgramDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.qbeQueryItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dGridQbeQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qbeQueryItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dGridQbeQuery
            // 
            this.dGridQbeQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dGridQbeQuery.AutoGenerateColumns = false;
            this.dGridQbeQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridQbeQuery.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.documentTitle,
            this.frequency,
            this.isElectronic,
            this.isExternal,
            this.documentType,
            this.responsible,
            this.departmentIdDataGridViewTextBoxColumn,
            this.department,
            this.postIdDataGridViewTextBoxColumn,
            this.post,
            this.taskIdDataGridViewTextBoxColumn,
            this.taskNameDataGridViewTextBoxColumn,
            this.isProgramDataGridViewCheckBoxColumn,
            this.programName});
            this.dGridQbeQuery.DataSource = this.qbeQueryItemBindingSource;
            this.dGridQbeQuery.Location = new System.Drawing.Point(0, 28);
            this.dGridQbeQuery.Name = "dGridQbeQuery";
            this.dGridQbeQuery.Size = new System.Drawing.Size(799, 165);
            this.dGridQbeQuery.TabIndex = 0;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.toolStripSeparator1,
            this.toolStripSplitExecute});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(799, 25);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSplitExecute
            // 
            this.toolStripSplitExecute.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выполнильToolStripMenuItem,
            this.выполнитьДляВсехМоделейToolStripMenuItem});
            this.toolStripSplitExecute.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitExecute.Image")));
            this.toolStripSplitExecute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitExecute.Name = "toolStripSplitExecute";
            this.toolStripSplitExecute.Size = new System.Drawing.Size(101, 22);
            this.toolStripSplitExecute.Text = "Выполнить";
            this.toolStripSplitExecute.ButtonClick += new System.EventHandler(this.toolStripSplitExecute_ButtonClick);
            // 
            // выполнильToolStripMenuItem
            // 
            this.выполнильToolStripMenuItem.Name = "выполнильToolStripMenuItem";
            this.выполнильToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.выполнильToolStripMenuItem.Text = "Выполниль";
            this.выполнильToolStripMenuItem.Click += new System.EventHandler(this.выполнильToolStripMenuItem_Click);
            // 
            // выполнитьДляВсехМоделейToolStripMenuItem
            // 
            this.выполнитьДляВсехМоделейToolStripMenuItem.Name = "выполнитьДляВсехМоделейToolStripMenuItem";
            this.выполнитьДляВсехМоделейToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.выполнитьДляВсехМоделейToolStripMenuItem.Text = "Выполнить для всех моделей";
            this.выполнитьДляВсехМоделейToolStripMenuItem.Click += new System.EventHandler(this.выполнитьДляВсехМоделейToolStripMenuItem_Click);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // documentTitle
            // 
            this.documentTitle.DataPropertyName = "DocumentName";
            this.documentTitle.HeaderText = "Название документа";
            this.documentTitle.Name = "documentTitle";
            // 
            // frequency
            // 
            this.frequency.DataPropertyName = "Frequency";
            this.frequency.HeaderText = "Частота заполнения";
            this.frequency.Name = "frequency";
            this.frequency.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.frequency.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // isElectronic
            // 
            this.isElectronic.DataPropertyName = "IsElectronic";
            this.isElectronic.HeaderText = "Електронный";
            this.isElectronic.Name = "isElectronic";
            // 
            // isExternal
            // 
            this.isExternal.DataPropertyName = "IsExternal";
            this.isExternal.HeaderText = "Внешний";
            this.isExternal.Name = "isExternal";
            // 
            // documentType
            // 
            this.documentType.DataPropertyName = "DocumentType";
            this.documentType.HeaderText = "Тип документа";
            this.documentType.Items.AddRange(new object[] {
            "Входящий-исходящий",
            "Входящий",
            "Исходящий"});
            this.documentType.Name = "documentType";
            // 
            // responsible
            // 
            this.responsible.DataPropertyName = "Responsible";
            this.responsible.HeaderText = "Ответстственный";
            this.responsible.Name = "responsible";
            // 
            // department
            // 
            this.department.DataPropertyName = "DepartmentName";
            this.department.HeaderText = "Подразделение";
            this.department.Name = "department";
            // 
            // post
            // 
            this.post.DataPropertyName = "PostName";
            this.post.HeaderText = "Должность";
            this.post.Name = "post";
            // 
            // programName
            // 
            this.programName.DataPropertyName = "ProgramName";
            this.programName.HeaderText = "Название программы";
            this.programName.Name = "programName";
            // 
            // departmentIdDataGridViewTextBoxColumn
            // 
            this.departmentIdDataGridViewTextBoxColumn.DataPropertyName = "DepartmentId";
            this.departmentIdDataGridViewTextBoxColumn.HeaderText = "DepartmentId";
            this.departmentIdDataGridViewTextBoxColumn.Name = "departmentIdDataGridViewTextBoxColumn";
            this.departmentIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // postIdDataGridViewTextBoxColumn
            // 
            this.postIdDataGridViewTextBoxColumn.DataPropertyName = "PostId";
            this.postIdDataGridViewTextBoxColumn.HeaderText = "PostId";
            this.postIdDataGridViewTextBoxColumn.Name = "postIdDataGridViewTextBoxColumn";
            this.postIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // taskIdDataGridViewTextBoxColumn
            // 
            this.taskIdDataGridViewTextBoxColumn.DataPropertyName = "TaskId";
            this.taskIdDataGridViewTextBoxColumn.HeaderText = "TaskId";
            this.taskIdDataGridViewTextBoxColumn.Name = "taskIdDataGridViewTextBoxColumn";
            this.taskIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // taskNameDataGridViewTextBoxColumn
            // 
            this.taskNameDataGridViewTextBoxColumn.DataPropertyName = "TaskName";
            this.taskNameDataGridViewTextBoxColumn.HeaderText = "Задача";
            this.taskNameDataGridViewTextBoxColumn.Name = "taskNameDataGridViewTextBoxColumn";
            // 
            // isProgramDataGridViewCheckBoxColumn
            // 
            this.isProgramDataGridViewCheckBoxColumn.DataPropertyName = "IsProgram";
            this.isProgramDataGridViewCheckBoxColumn.HeaderText = "Заполняется программой";
            this.isProgramDataGridViewCheckBoxColumn.Name = "isProgramDataGridViewCheckBoxColumn";
            // 
            // qbeQueryItemBindingSource
            // 
            this.qbeQueryItemBindingSource.DataSource = typeof(Information_analysis_of_university.QbeQueryItem);
            // 
            // QbeQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 195);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.dGridQbeQuery);
            this.HelpButton = true;
            this.Name = "QbeQueryForm";
            this.Text = "Панель построения QBE-запросов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QbeQueryForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dGridQbeQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qbeQueryItemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGridQbeQuery;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitExecute;
        private System.Windows.Forms.ToolStripMenuItem выполнильToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выполнитьДляВсехМоделейToolStripMenuItem;
        private System.Windows.Forms.BindingSource qbeQueryItemBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentTitle;
        private System.Windows.Forms.DataGridViewComboBoxColumn frequency;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isElectronic;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isExternal;
        private System.Windows.Forms.DataGridViewComboBoxColumn documentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsible;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn department;
        private System.Windows.Forms.DataGridViewTextBoxColumn postIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn post;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isProgramDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn programName;
    }
}