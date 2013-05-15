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

        private List<QbeMetric> Metrics;

        class QbeMetric
        {
            public string Title { get; set; }
            public string ColumnName { get; set; }
            public bool IsVisible { get; set; }
        }
        //private List<string> SelectedMetrics;

        public QbeQueryForm(MainForm form)
        {
            mForm = form;
            InitializeComponent();
            QbeItems = new QbeQueryConteiner();
            dGridQbeQuery.DataSource = QbeItems;

            DefaultMetrics();
            UpdateListBox();

            //bindingNavigator1.DataBindings = dGridQbeQuery.DataBindings;
        }

        private void UpdateListBox()
        {
            listboxAllMetrics.Items.Clear();
            listboxSelectedMetrics.Items.Clear();

            var list = Metrics.Where(x => x.IsVisible == false).Select(x => (object)x.Title);
            foreach (var item in list)
            {
                listboxAllMetrics.Items.Add(item);
            }
            list = Metrics.Where(x => x.IsVisible).Select(x => (object)x.Title);
            foreach (var item in list)
            {
                listboxSelectedMetrics.Items.Add(item);
            }
        }

        private void DefaultMetrics()
        {
            Metrics = new List<QbeMetric>();
            Metrics.Add(new QbeMetric() { Title = "Название документа", IsVisible = true, ColumnName = "DocumentName"});
            Metrics.Add(new QbeMetric() { Title = "Частота заполнения", IsVisible = true, ColumnName = "Frequency" });
            Metrics.Add(new QbeMetric() { Title = "Электронный", IsVisible = true, ColumnName = "isElectronic" });
            Metrics.Add(new QbeMetric() { Title = "Внешний", IsVisible = true, ColumnName = "IsExternal" });
            Metrics.Add(new QbeMetric() { Title = "Внешний источник", IsVisible = false, ColumnName = "ExternalSource" });
            Metrics.Add(new QbeMetric() { Title = "Внешний приемник", IsVisible = false, ColumnName = "ExternalDestination" });
            Metrics.Add(new QbeMetric() { Title = "Тип документа", IsVisible = true, ColumnName = "documentType" });
            Metrics.Add(new QbeMetric() { Title = "Назначение документа", IsVisible = false, ColumnName = "DocumentFunction" });
            Metrics.Add(new QbeMetric() { Title = "Ответственный", IsVisible = true, ColumnName = "responsible" });
            Metrics.Add(new QbeMetric() { Title = "Подразделение", IsVisible = true, ColumnName = "department" });
            Metrics.Add(new QbeMetric() { Title = "Должность", IsVisible = true, ColumnName = "post" });
            Metrics.Add(new QbeMetric() { Title = "Задача", IsVisible = true, ColumnName = "taskName" });
            Metrics.Add(new QbeMetric() { Title = "Заполняется программой", IsVisible = true, ColumnName = "isProgram" });
            Metrics.Add(new QbeMetric() { Title = "Название программы", IsVisible = true, ColumnName = "programName" });

            //Metrics = new List<Dictionary<string, bool>> { , };
        }

        private void toolStripSplitExecute_ButtonClick(object sender, EventArgs e)
        {
            //null :(
            //var mform = new MainForm();// this.Parent;
            mForm.ExecuteQbeOery(QbeItems);
        }

        public void AddDocument(DocumentObject document)
        {
            QbeItems.Add(new QbeQueryItem() { Id = document.Id, DocumentName = document.Name, DocumentType = document.DocTypeTitle });
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

        private void btAddToSelect_Click(object sender, EventArgs e)
        {
            var selectedItem = listboxAllMetrics.SelectedItem;
            ChangeMetric(selectedItem, true);
            //dGridQbeQuery.Columns
            UpdateListBox();
        }

        private void btRemoveFromSelect_Click(object sender, EventArgs e)
        {
            var selectedItem = listboxSelectedMetrics.SelectedItem;
            ChangeMetric(selectedItem, false);
            //dGridQbeQuery.Columns
            UpdateListBox();
        }

        private void btAddAllToSelect_Click(object sender, EventArgs e)
        {
            foreach (var item in listboxAllMetrics.Items)
            {
                ChangeMetric(item, true);
            }
            UpdateListBox();
        }

        private void btRemoveAllFromSelect_Click(object sender, EventArgs e)
        {
            foreach (var item in listboxSelectedMetrics.Items)
            {
                ChangeMetric(item, false);
            }
            UpdateListBox();
        }

        private void ChangeMetric(object item, bool IsVisible)
        {
            if (item != null)
            {
                var metric = Metrics.FirstOrDefault(x => x.Title == item.ToString());

                dGridQbeQuery.Columns[metric.ColumnName].Visible = IsVisible;

                metric.IsVisible = IsVisible;
            }
        }

        
    }
}
