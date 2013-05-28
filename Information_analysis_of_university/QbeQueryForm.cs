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
            public int ColumnNumber { get; set; }
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

            var col = dGridQbeQuery.Columns.GetEnumerator();
            int index = 0;
            while (col.MoveNext())
            {
                var item = col.Current;
                var colItem = item as DataGridViewColumn;
                if (colItem != null)
                    Metrics.Add(new QbeMetric() { Title = colItem.HeaderText, ColumnName = colItem.Name, IsVisible = colItem.Visible, ColumnNumber = index++ });
            }
            UpdateListBox();
        }

        private void toolStripSplitExecute_ButtonClick(object sender, EventArgs e)
        {
            //null :(
            //var mform = new MainForm();// this.Parent;
            QbeItems.CurrentItemNumbers = Metrics.Where(x => x.IsVisible).ToDictionary(x => x.ColumnNumber,y => y.ColumnName);
            mForm.ExecuteQbeQuery(QbeItems);
        }

       public void AddObjectInQbeQuery(BaseObject currentObject)
        {
            if (currentObject is BaseDocumentObject)
            {
                var documentObject = currentObject as BaseDocumentObject;
                AddDocument(documentObject);
            }
            if (currentObject is TaskObject)
            {
                AddTask(currentObject as TaskObject);
            }
            if (currentObject is BaseWorkplaceObject)
            {
                AddWorkplace(currentObject as BaseWorkplaceObject);
            }
        }

       private void AddDocument(BaseDocumentObject document)
       {
           QbeItems.Add(new QbeQueryItem()
           {
               DocumentName = document.Name,
               DocumentType = document.DocTypeTitle,
               DocumentFunction = document.Function,
               //IsElectronic = document.IsElectronic,
               Frequency = document.Frequence,
               IsExternal = !document.IsInner,
               IsProgram = document.IsProgram,
               ProgramName = document.ProgramName
               //ExternalSource = 
               //ExternalDistination = 
           });
       }

        private void AddTask(TaskObject taskObject)
        {
            QbeItems.Add(new QbeQueryItem() { TaskName = taskObject.Name });
        }

        private void AddWorkplace(BaseWorkplaceObject workplaceObject)
        {
            QbeItems.Add(new QbeQueryItem()
                             {
                                 PostName = workplaceObject.Name,
                                 DepartmentName = workplaceObject.DepartmentName,
                                 ResponsibleWorker = workplaceObject.ResponsibleWorker
                             });
            
            
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

        private void QbeQueryForm_Load(object sender, EventArgs e)
        {

        }


    }
}
