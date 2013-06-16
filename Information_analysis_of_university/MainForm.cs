using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Information_analysis_of_university.Models;
using Information_analysis_of_university.Objects;

namespace Information_analysis_of_university
{
    //класс главного окна формы, реализация событий компонентов формы
    public partial class MainForm : Form
    {
        //объект модели
        private ModelBase model;
        //объект формы для построения QBE-запроса
        private QbeQueryForm qbeForm;

        public MainForm()
        {
            InitializeComponent();
            qbeForm = new QbeQueryForm(this);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        { }

        public void DrowModelSQL(ModelBase model, List<string> mas)
        {
            //отрисовка
            pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            var graphics = Graphics.FromImage(pictureBox2.Image);
            model.DrawSQL(graphics, mas);
        }

        //событие нажатия кнопки "Модель рабочих процессов"
        private void btWorkProcessModel_Click(object sender, EventArgs e)
        {
            var newTab = CreateNewTab(new WorkProcessModel());
            newTab.DrowModel();
        }

        //событие двойного щелчка по изображению модели
        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //находим объект, по которому был сдела щелчек
            var obj = model.GetObject(e.X, e.Y);
            if (obj is TaskObject)
            {
                var taskPropertyForm = new PropertyForm<TaskObject>(obj as TaskObject);
                taskPropertyForm.Show(this);
            }
            if (obj is DocumentObject)
            {
                var docPropertyForm = new PropertyForm<DocumentObject>(obj as DocumentObject);
                docPropertyForm.Show(this);
            }
            if (obj is TaskForWorker)
            {
                var docPropertyForm = new PropertyForm<TaskForWorker>(obj as TaskForWorker);
                docPropertyForm.Show(this);
            }
            if (obj is LittleMan)
            {
                var docPropertyForm = new PropertyForm<LittleMan>(obj as LittleMan);
                docPropertyForm.Show(this);
            }
            if (obj is WorkingPlace)
            {
                var docPropertyForm = new PropertyForm<WorkingPlace>(obj as WorkingPlace);
                docPropertyForm.Show(this);
            }
            if (obj is DocumentForWorker)
            {
                var docPropertyForm = new PropertyForm<DocumentForWorker>(obj as DocumentForWorker);
                docPropertyForm.Show(this);
            }
            if (obj is WorkplaceLifeElement)
            {
                var docPropertyForm = new PropertyForm<WorkplaceLifeElement>(obj as WorkplaceLifeElement);
                docPropertyForm.Show(this);
            }
            if (obj is WorkplaceResponsibilityObject)
            {
                var docPropertyForm = new PropertyForm<WorkplaceResponsibilityObject>(obj as WorkplaceResponsibilityObject);
                docPropertyForm.Show(this);
            }
        }

        //событие нажатия кнопки "Модель вариантов использования"
        private void button2_Click(object sender, EventArgs e)
        {
            var newTab = CreateNewTab(new UseCaseModel());
            newTab.DrowModel();
        }

        //событие нажатия кнопки "Модель нагруженности рабочих мест"
        private void button3_Click(object sender, EventArgs e)
        {
            var newTab = CreateNewTab(new CapacityWorkingPlaces());
            newTab.DrowModel();
        }

        //создание новой вкладки
        //m - модель, которая будет отображаться в новой вкладке
        public NewTabControl CreateNewTab(ModelBase m)
        {
            var number = tcModelsFrame.TabPages.Count + 1;
            tcModelsFrame.TabPages.Add(new TabPage() { Name = "newTabPage" + number, Text = tabName() ?? "Модель" + number });

            tcModelsFrame.TabPages[number - 1].Location = new System.Drawing.Point(4, 22);
            tcModelsFrame.TabPages[number - 1].Padding = new System.Windows.Forms.Padding(3);
            tcModelsFrame.TabPages[number - 1].Size = tcModelsFrame.Size;
            tcModelsFrame.TabPages[number - 1].TabIndex = 0;
            tcModelsFrame.TabPages[number - 1].UseVisualStyleBackColor = true;

            var newTab = new NewTabControl(m, qbeForm);
            tcModelsFrame.TabPages[number - 1].Controls.Add(newTab);

            newTab.Size = new Size(tcModelsFrame.Size.Width - 8, tcModelsFrame.Size.Height - 26);
            newTab.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right;

            tcModelsFrame.SelectedTab = tcModelsFrame.TabPages[number - 1];
            return newTab;
        }

        //событие нажатия кнопки "Модель распределения обязательств"
        private void btBuildResponsibleModel_Click(object sender, EventArgs e)
        {
            var newTab = CreateNewTab(new ResponsibilityDistributionModel());
            newTab.DrowModel();
        }

        private void label1_Click(object sender, EventArgs e)
        { }

        //событие нажатия кнопки "Модель потоков данных"
        private void button4_Click(object sender, EventArgs e)
        {
            var newTab = CreateNewTab(new DataStreamsModel());
            newTab.DrowModel();
        }

        private void btBuildLifeCycleModel_Click(object sender, EventArgs e)
        {
            var newTab = CreateNewTab(new DocumentLifeCycleModel());
            newTab.DrowModel();
        }

        private void buttonSQL_Click(object sender, EventArgs e)
        {
            //SQL-модифицированный запрос
            var requestSQL = new RequestSQL<CapacityWorkingPlaces>(model as CapacityWorkingPlaces);
            requestSQL.Show(this);
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        { }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        { }

        private void buttonMaster_Click(object sender, EventArgs e)
        {
            //Мастер запросов
            var requestMaster = new MasterQueryBuilding();
            requestMaster.Show(this);
        }

        //событие закрытия главной формы
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show(
                "После закрытия формы информация будет утеряна. Вы уверены, что хотите закрыть данную форму?",
                "Закрытие формы", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
                e.Cancel = true;
        }

        //событие нажатия кнопки "QBE"
        //отображение формы для построения QBE-запросов
        private void buttonQBE_Click(object sender, EventArgs e)
        {
            try
            {
                qbeForm.Show(this);
            }
            catch (Exception)
            {
                qbeForm = new QbeQueryForm(this);
                qbeForm.Show(this);
            }

        }

        //выполнение QBE-запроса
        //query - контейнер, содержащий составленные QBE-запросы
        public void ExecuteQbeQuery(QbeQueryConteiner query)
        {
            var currentTab = tcModelsFrame.SelectedTab;

            var control = currentTab.Controls[0] as NewTabControl;
            if (control != null)
            {
                //определяем модель, для которой нужно выполнить запрос
                var newModel = GetNewModel(control.model);

                CreateNewTab(newModel);
                control = tcModelsFrame.TabPages[tcModelsFrame.TabPages.Count - 1].Controls[0] as NewTabControl;
                
                if (control != null) control.model.DrawQbe(control.GetGraphics(), query);
            }
        }

        //выполнение QBE-запроса для всех моделей
        public void ExecuteQbeQueryForAll(QbeQueryConteiner query)
        {
            //подготовка области вывода
            var number = tcModelsFrame.TabPages.Count + 1;
            tcModelsFrame.TabPages.Add(new TabPage() { Name = "newTabPage" + number, Text = tabName() ?? "Модель" + number });
            tcModelsFrame.TabPages[number - 1].Location = new System.Drawing.Point(4, 22);
            tcModelsFrame.TabPages[number - 1].Padding = new System.Windows.Forms.Padding(3);
            tcModelsFrame.TabPages[number - 1].Size = tcModelsFrame.Size;
            tcModelsFrame.TabPages[number - 1].TabIndex = 0;
            tcModelsFrame.TabPages[number - 1].UseVisualStyleBackColor = true;

            for (int i = 0; i < 3; i++)
            {
                //создание моделей
                ModelBase newModel = null;
                switch (i)
                {
                    case 0:
                        newModel = new WorkProcessModel();
                        break;
                    case 1:
                        newModel = new ResponsibilityDistributionModel();
                        break;
                    case 2:
                        newModel = new DocumentLifeCycleModel();
                        break;

                }

                var newTab = new NewTabControl(newModel, qbeForm);

                newTab.Size = new Size((tcModelsFrame.Size.Width - 8) / 2, (tcModelsFrame.Size.Height - 26) / 2);
                newTab.Location = new Point(newTab.Size.Width * (i % 2), newTab.Size.Height * (i % 3 == 2 ? 1 : 0));
                tcModelsFrame.TabPages[number - 1].Controls.Add(newTab);

                var control = tcModelsFrame.TabPages[number - 1].Controls[i] as NewTabControl;
                //выполние запроса
                if (control != null) control.model.DrawQbe(control.GetGraphics(), query);
            }
            tcModelsFrame.SelectedTab = tcModelsFrame.TabPages[number - 1];

        }

        private ModelBase GetNewModel(ModelBase modelBase)
        {
            ModelBase newModel = null;
            if (modelBase is WorkProcessModel)
                newModel = new WorkProcessModel();
            if (modelBase is ResponsibilityDistributionModel)
                newModel = new ResponsibilityDistributionModel();
            if (modelBase is DataStreamsModel)
                newModel = new DataStreamsModel();
            if (modelBase is DocumentLifeCycleModel)
                newModel = new DocumentLifeCycleModel();
            if (modelBase is UseCaseModel)
                newModel = new UseCaseModel();
            if (modelBase is CapacityWorkingPlaces)
                newModel = new CapacityWorkingPlaces();
            return newModel;
        }

        private void tcModelsFrame_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point location = new Point(0, 0);

                //берется размер не текущей вкладки, а тот который указан для всех... но вкладки в зависимости от названия меняют свой размер
                Size itemSize = tcModelsFrame.ItemSize;
                int curTabNumber;

                for (curTabNumber = 0;
                     e.X < location.X || e.X > location.X + itemSize.Width || e.Y < location.Y || e.Y > location.Y + itemSize.Height;
                     curTabNumber++, location.X += itemSize.Width)
                {
                    if (tcModelsFrame.TabPages.Count <= curTabNumber)
                    {
                        curTabNumber = 0;
                        break;
                    }
                }

                tcModelsFrame.SelectedTab = tcModelsFrame.TabPages[curTabNumber];
                contextMenuStrip1.Show(tcModelsFrame, e.X, e.Y);
            }
        }


        //удаляет активную вкладку
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentPage = tcModelsFrame.SelectedTab;
            var control = currentPage.Controls[0] as NewTabControl;

            if (MessageBox.Show("Вы действительно хотите закрыть активную вкладку?", "Звкрытие вкладки", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                tcModelsFrame.TabPages.Remove(currentPage);
        }

        //переименование вкладки
        private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tcModelsFrame.SelectedTab.Text = tabName() ?? tcModelsFrame.SelectedTab.Text;
        }

        //запрашивает имя у пользователя
        private string tabName()
        {
            var newNameForm = new ChangeNameForm();
            newNameForm.ShowDialog(this);
            return newNameForm.NewName;
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        { }

        //сохранение моделей
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //функция для сохранения модели
            //выбераем текущую вкладку
            var currentPage = tcModelsFrame.SelectedTab;
            var control = currentPage.Controls[0] as NewTabControl;
            // вызов диалога сохранения
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Title = "Сохранить картинку как ...";
            savedialog.OverwritePrompt = true;
            savedialog.CheckPathExists = true;
            //форматы для сохранения
            savedialog.Filter =
                "Bitmap File(*.bmp)|*.bmp|" +
                "GIF File(*.gif)|*.gif|" +
                "JPEG File(*.jpg)|*.jpg|" +
                "TIF File(*.tif)|*.tif|" +
                "PNG File(*.png)|*.png";
            savedialog.ShowHelp = true;
            //  если нажали ок
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                //сохраняем введенное имя файла
                string fileName = savedialog.FileName;
                string strFilExtn =
                    fileName.Remove(0, fileName.Length - 3);
                //выбор формата для сохранения
                switch (strFilExtn)
                {
                    case "bmp":
                        // сохранение в формате bmp
                        pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                        var graphics1 = Graphics.FromImage(pictureBox1.Image);
                        control.model.Draw(graphics1);
                        pictureBox1.Image.Save(fileName);
                        break;
                    case "jpg":
                        // сохранение в формате jpg
                        pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                        var graphics = Graphics.FromImage(pictureBox1.Image);
                        control.model.Draw(graphics);
                        pictureBox1.Image.Save(fileName);
                        break;
                    case "gif":
                        // сохранение в формате gif
                        pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                        var graphics2 = Graphics.FromImage(pictureBox1.Image);
                        control.model.Draw(graphics2);
                        pictureBox1.Image.Save(fileName);
                        break;

                    case "png":
                        // сохранение в формате png
                        pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                        var graphics4 = Graphics.FromImage(pictureBox1.Image);
                        control.model.Draw(graphics4);
                        pictureBox1.Image.Save(fileName);
                        break;
                    default:
                        break;
                }
            }
        }

        // событие нажатия кнопки "Анализ"
        //вызывает функцию анализа документооборота
        private void analisButton_Click(object sender, EventArgs e)
        {
            var AnalisForm = new AnalisResultForm();
            AnalisForm.Show(this);

            //отображение ошибок существующих на моделях
            for (int i = 0; i < tcModelsFrame.TabPages.Count; i++)
            {
                var control = tcModelsFrame.TabPages[i].Controls[0] as NewTabControl;
                if (control != null) control.model.ViewErrors(control.GetGraphics(), AnalisForm.ResultConteiner);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        //вызов информации о программе
        private void aboutProgram_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Аналіз стану інформаційного забезпечення університету.Розробники: Круковець Я.М., Карпенко А.Д.кафедра КІТ, ДНУЗТ, 2013. Версія 1.0");
        }

        private void sQLмодифицырованныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var requestSQL = new RequestSQL<CapacityWorkingPlaces>(model as CapacityWorkingPlaces);
            requestSQL.Show(this);
        }

        private void qBEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                qbeForm.Show(this);
            }
            catch (Exception)
            {
                qbeForm = new QbeQueryForm(this);
                qbeForm.Show(this);
            }
        }

        private void мастерПостроенияЗапросовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var requestMaster = new MasterQueryBuilding();
            requestMaster.Show(this);
        }

        private void модельПотоковДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newTab = CreateNewTab(new DataStreamsModel());
            newTab.DrowModel();

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
