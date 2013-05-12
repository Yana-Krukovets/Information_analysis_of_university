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
            if (capacityWorkingPlaces.Checked == true)
            {
                int i = 10;
                var obj = new FormForObjects();
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
                obj.Show();
            }
            if (dataStreamsModel.Checked == true)
            {
                var documentRepository = new BaseDocumentRepository<Document>();
                int i = 10;
                var obj = new FormForObjects();
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
            if (lifeCycleModel.Checked == true)
            {
            }
            if (responsibilityModel.Checked == true)
            {
            }
            if (useCaseModel.Checked == true)
            {
            }
            if (WorkProcassModel.Checked == true)
            {
            }
        }
    }
}
