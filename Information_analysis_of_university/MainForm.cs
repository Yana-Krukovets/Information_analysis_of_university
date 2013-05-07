﻿using System;
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
            model = new UseCaseModel();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {      }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {}

        private void DrowModel(ModelBase model)
        {
            //отрисовка
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            var graphics = Graphics.FromImage(pictureBox1.Image);
            model.Draw(graphics);
        }    

        private void button1_Click(object sender, EventArgs e)
        {
            CreateNewTab();
            model = new WorkProcessModel();
            DrowModel(model);
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
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            model = new UseCaseModel();
            DrowModel(model);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            model = new CapacityWorkingPlaces();
            DrowModel(model);
        }

        private void CreateNewTab()
        {
            var number = tcModelsFrame.TabPages.Count;
            tcModelsFrame.TabPages.Add(new TabPage() { Name = "newTabPage" + number, Text = "new" + number });
            //panel1 = new System.Windows.Forms.Panel();
            //pictureBox1 = new System.Windows.Forms.PictureBox();
        }

        /*    private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var drawObj = model.GetObject(e.X, e.Y);
            if (drawObj != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.Capture = true;
                    drawObj.BeginDrag(new Point(e.X, e.Y));
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var drawObj = model.GetObject(e.X, e.Y);
            if (drawObj != null)
            {
                if (drawObj.IsDragging())
                    drawObj.Drag(new Point(e.X, e.Y), this);
                //DrowModel(model);
              /*  pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                var graphics = Graphics.FromImage(pictureBox1.Image);
                drawObj.DrawObject(graphics, e.X, e.Y);
               
            }

        }

        private void pictureBox1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var drawObj = model.GetObject(e.X, e.Y);
            if (drawObj != null)
            {
                if (drawObj.IsDragging())
                    drawObj.EndDrag();
            }

        }
*/
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            model = new ResponsibilityDistributionModel();
            DrowModel(model);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            model = new DataStreamsModel();
            DrowModel(model);
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

    }
}
