using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Information_analysis_of_university.Objects;

namespace Information_analysis_of_university
{
    //класс формы построения QBE-запросов
    public partial class QbeQueryForm : Form
    {
        //объект модели модель 
        private MainForm mForm;
        //контейнер запросов
        public QbeQueryConteiner QbeItems;
        //список всех метрик, по которым возможен отбор
        private List<QbeMetric> Metrics;

        //внутренний класс метрик отбора
        class QbeMetric
        {
            //номер колонки в таблице
            public int ColumnNumber { get; set; }
            //наименование метрики
            public string Title { get; set; }
            //название колонки
            public string ColumnName { get; set; }
            //принимает участие в выборе (true) или нет (false)
            public bool IsVisible { get; set; }
        }

        public QbeQueryForm(MainForm form)
        {
            mForm = form;
            InitializeComponent();
            QbeItems = new QbeQueryConteiner();

            //привязка компонента-новигатора к компоненту DataGridView
            var bSource = new BindingSource();
            bSource.DataSource = QbeItems;
            bindingNavigator1.BindingSource = bSource;
            dGridQbeQuery.DataSource = bSource;

            //заполнение метрик по умолчанию
            DefaultMetrics();
        }

        //обновление списка используемых и неиспользуемых метрик
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

        //устанавливает набор используемых метррик по умолчанию
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

        //событие ажатия кнопки "Выполнить" или "Выполнить для всех моделей"
        //вызов функции выполнения запроса
        private void toolStripSplitExecute_ButtonClick(object sender, EventArgs e)
        {
            QbeItems.CurrentItemNumbers = Metrics.Where(x => x.IsVisible).ToDictionary(x => x.ColumnNumber, y => y.ColumnName);
            if (toolStripSplitExecute.Text == выполнитьДляВсехМоделейToolStripMenuItem.Text)
                mForm.ExecuteQbeQueryForAll(QbeItems);
            else
                mForm.ExecuteQbeQuery(QbeItems);
        }

        //добавление объектов моделей к запросу
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

        //добавление объекта "Документ"
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

        //добавление объекта "Задача"
        private void AddTask(TaskObject taskObject)
        {
            QbeItems.Add(new QbeQueryItem() { TaskName = taskObject.Name });
        }

        //добавление объекта "Рабочее место"
        private void AddWorkplace(BaseWorkplaceObject workplaceObject)
        {
            QbeItems.Add(new QbeQueryItem()
                             {
                                 PostName = workplaceObject.Name,
                                 DepartmentName = workplaceObject.DepartmentName,
                                 ResponsibleWorker = workplaceObject.ResponsibleWorker
                             });


        }

        //событие закрытия формы
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

        //добавление метрики к списку выбранных
        private void btAddToSelect_Click(object sender, EventArgs e)
        {
            var selectedItem = listboxAllMetrics.SelectedItem;
            ChangeMetric(selectedItem, true);
            UpdateListBox();
        }

        //переход к метрики к списку не выбранных
        private void btRemoveFromSelect_Click(object sender, EventArgs e)
        {
            var selectedItem = listboxSelectedMetrics.SelectedItem;
            ChangeMetric(selectedItem, false);
            UpdateListBox();
        }

        //добавить все метрики к списку выбранных
        private void btAddAllToSelect_Click(object sender, EventArgs e)
        {
            foreach (var item in listboxAllMetrics.Items)
            {
                ChangeMetric(item, true);
            }
            UpdateListBox();
        }

        //удаление всех ментирк из списка невыбранных
        private void btRemoveAllFromSelect_Click(object sender, EventArgs e)
        {
            foreach (var item in listboxSelectedMetrics.Items)
            {
                ChangeMetric(item, false);
            }
            UpdateListBox();
        }

        //изменение списков метррик и таблицы QBE-запроса
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

        //очистка елементов QBE-запроса
        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QbeItems.Clear();
        }


    }
}
