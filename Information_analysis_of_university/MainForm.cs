using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Information_analysis_of_university.Models;

namespace Information_analysis_of_university
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void DrowModel()
        {
            //достаем задачи
            //достаем документы для этих задач
            //отрисовка

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            var graphics = Graphics.FromImage(pictureBox1.Image);
            var model = new WorkProcessModel();

            model.Draw(graphics);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrowModel();
        }
    }
}
