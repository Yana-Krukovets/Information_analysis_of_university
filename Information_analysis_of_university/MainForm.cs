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

namespace Information_analysis_of_university
{
    public partial class MainForm : Form
    {
        private ModelBase model;

        public MainForm()
        {
            InitializeComponent();

            model = new WorkProcessModel();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void DrowModelUseCase()
        {
            //достаем задачи
            //достаем документы для этих задач
            //отрисовка

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            var graphics = Graphics.FromImage(pictureBox1.Image);
            var model = new UseCaseModel();

            model.Draw(graphics);

        }

        private void DrowModel()
        {
            //достаем задачи
            //достаем документы для этих задач
            //отрисовка

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            var graphics = Graphics.FromImage(pictureBox1.Image);
            

            model.Draw(graphics);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrowModel();
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var obj = model.GetObject(e.X, e.Y);
            if(obj is TaskObject)
            {
                var taskPropertyForm = new PropertyForm<TaskObject>(obj as TaskObject);
                taskPropertyForm.Show(this);
            }
            else
            {
                if(obj is DocumentObject)
                {
                    var docPropertyForm = new PropertyForm<DocumentObject>(obj as DocumentObject);
                    docPropertyForm.Show(this);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DrowModelUseCase();
        }
    }
}
