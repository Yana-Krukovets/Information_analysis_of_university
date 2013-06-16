using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Information_analysis_of_university.Models;
using Information_analysis_of_university.Objects;
using DatabaseLevel;

namespace Information_analysis_of_university
{
    public partial class MasterQueryBuilding : Form
    {
        private ModelBase model;
        
        public MasterQueryBuilding()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var departmentRepository = new BaseDocumentRepository<Department>();
            var departments = departmentRepository.ToList().Select(t => new WorkingPlace(t));
            // если выбрана модель нагружености рабочих мест
            if (capacityWorkingPlaces.Checked == true)
            {
                int i = 40;
                model = new CapacityWorkingPlaces();
                var obj = new FormForObjects<CapacityWorkingPlaces>(model as CapacityWorkingPlaces);
                //добавление чекбоксов
                foreach (var item in departments)
                {
                    CheckBox check = new CheckBox();
                    check.Name = item.Name;
                    check.Text = item.Name;
                    check.Width = 300;
                    check.Left = 20;
                    check.Top = 20 + i;
                    i += 20;
                    obj.Controls.Add(check);
                }
                CheckBox check1 = new CheckBox();
                check1.Name = "countDoc";
                check1.Text = "Количество обрабатываемых документов";
                check1.Width = 300;
                check1.Left = 20;
                check1.Top = 30 + i;
                obj.Controls.Add(check1);
                CheckBox check2 = new CheckBox();
                check2.Name = "countTasks";
                check2.Text = "Количество выполняемых задач";
                check2.Width = 300;
                check2.Left = 20;
                check2.Top = check1.Top + 20;
                obj.Controls.Add(check2);
                obj.Show(this);
            }
           // если выбрана модель потоков данных
            if (dataStreamsModel.Checked == true)
            {
                var documentRepository = new BaseDocumentRepository<Document>();
                int i = 40;
                model = new DataStreamsModel();
                var obj = new FormForObjects<DataStreamsModel>(model as DataStreamsModel);
                //выбор чекбоксов
                foreach (var item in departments)
                {
                    //создание и опеределение координат чекбоксов
                    CheckBox check = new CheckBox();
                    check.Name = item.Name;
                    check.Text = item.Name;
                    check.Width = 300;
                    check.Left = 20;
                    check.Top = 20 + i;
                    i += 20;
                    obj.Controls.Add(check);
                    var documents = documentRepository.Query(t => t.FK_DepartmentIdDestination == item.Id).ToList();
                    foreach (var item1 in documents)
                    {
                        CheckBox check1 = new CheckBox();
                        check1.Name = item1.Name;
                        check1.Text = item1.Name;
                        check1.Width = 300;
                        check1.Left = 40;
                        check1.Top = 20 + i;
                        i += 20;
                        obj.Controls.Add(check1);
                        CheckBox check2 = new CheckBox();
                        check2.Name = item1.DocFunction;
                        check2.Text = item1.DocFunction;
                        check2.Width = 300;
                        check2.Left = 60;
                        check2.Top = 20 + i;
                        i += 20;
                        obj.Controls.Add(check2);
                    }
                    
                }
                
                obj.Show();
                
            }
            //модель жизненного цикла документа
            if (lifeCycleModel.Checked == true)
            {
                int i = 40;
                model = new DocumentLifeCycleModel();
                var obj = new FormForObjects<DocumentLifeCycleModel>(model as DocumentLifeCycleModel);
                var documentRepository = new BaseDocumentRepository<Document>();

                //ишем все документы:
                //1) внешние, которые либо входяшие, либо входящие-исходяшие
                //2) внутренные исходящие
                //для того, чтобы найти их начало жизненного цикла
                var documentsList = documentRepository.ToList().Where(
                    x =>
                    (((x.Type == (byte)DocumentType.Input || x.Type == (byte)DocumentType.InputOutput) /*&& x.IsExternal == 2*/) ||
                    x.Type == (byte)DocumentType.Output) && x.DocumentId > 1000);
                foreach (var item in documentsList)
                {
                    CheckBox check = new CheckBox();
                    check.Name = item.Name;
                    check.Text = item.Name;
                    check.Width = 300;
                    check.Left = 20;
                    check.Top = 20 + i;
                    i += 20;
                    obj.Controls.Add(check);
                }
                // открытие нового окна
                obj.Show();

            }
            if (responsibilityModel.Checked == true)
            {
                int i = 40;
                model = new ResponsibilityDistributionModel();
                var obj = new FormForObjects<ResponsibilityDistributionModel>(model as ResponsibilityDistributionModel);
                var postDocumentRepository = new BaseDocumentRepository<Post>();

                var posts = postDocumentRepository.ToList().Select(
                    x => new WorkplaceResponsibilityObject(x));
                foreach (var item in posts)
                {
                    CheckBox check = new CheckBox();
                    check.Name = item.Name;
                    check.Text = item.Name;
                    check.Width = 300;
                    check.Left = 20;
                    check.Top = 20 + i;
                    i += 20;
                    obj.Controls.Add(check);
                }
                // открытие нового окна
                obj.Show();
            }
            //модель вариантов использования
            if (useCaseModel.Checked == true)
            {
                int i = 40;
                model = new UseCaseModel();
                var obj = new FormForObjects<UseCaseModel>(model as UseCaseModel);
                var workerRepository = new BaseDocumentRepository<Worker>();
                var workers = workerRepository.ToList().Select(x => new LittleMan(x));
                List<TaskForWorker> taskList;
                List<DocumentForWorker> Documents;
                // добавление чекбоксов
                foreach (var item in workers)
                {
                    CheckBox check = new CheckBox();
                    check.Name = item.Name;
                    check.Text = item.Name;
                    check.Width = 300;
                    check.Left = 20;
                    check.Top = 20 + i;
                    i += 20;
                    obj.Controls.Add(check);
                    taskList = new List<TaskForWorker>();
                    Documents = new List<DocumentForWorker>();
                    var taskDocumentRepository = new BaseDocumentRepository<Task>();
                    var tasks = taskDocumentRepository.Query(x => x.FK_PostId == item.PostId).ToList();
                    taskList = tasks.Select(x => new TaskForWorker(x)).ToList();
                    var documentRepository = new BaseDocumentRepository<Document>();
                    var documents = documentRepository.ToList();
                    for (int j = 0; j < tasks.Count; j++)
                    {
                        CheckBox check1 = new CheckBox();
                        check1.Name = tasks[j].Name;
                        check1.Text = tasks[j].Name;
                        check1.Width = 300;
                        check1.Left = 40;
                        check1.Top = 20 + i;
                        i += 20;
                        obj.Controls.Add(check1);
                        foreach (var doc in documents)
                        {
                            if (tasks[j].TaskId == doc.FK_TaskId)
                            {
                                CheckBox check2 = new CheckBox();
                                check2.Name = doc.Name;
                                check2.Text = doc.Name;
                                check2.Width = 300;
                                check2.Left = 60;
                                check2.Top = 20 + i;
                                i += 20;
                                obj.Controls.Add(check2);    
                            }
                        }
                    }        
                }
               // отрисовка модели
                obj.Show();
            }
            // если выбран модель рабочих процессов
            if (WorkProcassModel.Checked == true)
            {
                int i = 40;
                var taskDocumentRepository = new BaseDocumentRepository<Task>();
                var tasks = taskDocumentRepository.ToList().Select(x => new TaskObject(x));
                model = new WorkProcessModel();
                var obj = new FormForObjects<WorkProcessModel>(model as WorkProcessModel);
                // отображение всех возможных элементов модели в мастере запросов
                foreach (var item in tasks)
                {
                    CheckBox check1 = new CheckBox();
                    check1.Name = item.Name;
                    check1.Text = item.Name;
                    check1.Width = 300;
                    check1.Left = 40;
                    check1.Top = 20 + i;
                    i += 20;
                    obj.Controls.Add(check1);
                    var documentRepository = new BaseDocumentRepository<Document>();
                    var documents = documentRepository.Query(x => x.Task.TaskId == item.Id).ToList();
                    // добавление чекбоксов
                    foreach (var item1 in documents)
                    {
                        CheckBox check2 = new CheckBox();
                        check2.Name = item1.Name;
                        check2.Text = item1.Name;
                        check2.Width = 300;
                        check2.Left = 60;
                        check2.Top = 30 + i;
                        i += 30;
                        obj.Controls.Add(check2);
                    }
 
                }
                // открытие нового окна
                obj.Show();
            }
        }

        private void MasterQueryBuilding_FormClosing(object sender, FormClosingEventArgs e)
        {
           // сообщение закрытия окна
            var result = MessageBox.Show(
                "После закрытия формы информация будет утеряна. Вы уверены, что хотите закрыть данную форму?",
                "Закрытие формы", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
                e.Cancel = true;
        }

        private void MasterQueryBuilding_Load(object sender, EventArgs e)
        {        }
    }
}
