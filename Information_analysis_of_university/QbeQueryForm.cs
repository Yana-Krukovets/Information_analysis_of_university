using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Information_analysis_of_university.Objects;

namespace Information_analysis_of_university
{
    public partial class QbeQueryForm : Form
    {
        private MainForm mForm;
        public QbeQueryConteiner QbeItems;

        public QbeQueryForm(MainForm form)
        {
            mForm = form;
            InitializeComponent();
            QbeItems = new QbeQueryConteiner();
            dGridQbeQuery.DataSource = QbeItems;
            //bindingNavigator1.DataBindings = dGridQbeQuery.DataBindings;
        }

        private void toolStripSplitExecute_ButtonClick(object sender, EventArgs e)
        {
            //null :(
            //var mform = new MainForm();// this.Parent;
            mForm.ExecuteQbeOery(QbeItems);
        }

        public void AddDocument(DocumentObject document)
        {
            QbeItems.Add(new QbeQueryItem(){Id = document.Id, DocumentName = document.Name, DocumentType = document.DocTypeTitle});
            //var index = dGridQbeQuery.NewRowIndex;
            //dGridQbeQuery.Rows.Add();
            //dGridQbeQuery.Rows[index].Cells["Id"].Value = document.Id;
            //dGridQbeQuery.Rows[index].Cells["documentTitle"].Value = document.Name;
        }

        private void QbeQueryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show(
                "После закрытия формы информация будет утеряна. Вы уверены, что хотите закрыть данную форму?",
                "Закрытие формы", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
                e.Cancel = true;
        }

        private void выполнитьДляВсехМоделейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripSplitExecute.Text = выполнитьДляВсехМоделейToolStripMenuItem.Text;
        }

        private void выполнильToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripSplitExecute.Text = выполнильToolStripMenuItem.Text;
        }

        internal void AddTask(TaskObject taskObject)
        {
            QbeItems.Add(new QbeQueryItem() { TaskId = taskObject.Id, TaskName = taskObject.Name });
        }
    }
}
