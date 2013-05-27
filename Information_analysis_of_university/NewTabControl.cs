using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Information_analysis_of_university.Models;
using Information_analysis_of_university.Objects;

namespace Information_analysis_of_university
{
    public partial class NewTabControl : UserControl
    {
        public ModelBase model;
        private BaseObject currentObject;
        public QbeQueryForm qbeForm;

        public NewTabControl(ModelBase newModel, QbeQueryForm form)
        {
            model = newModel;
            qbeForm = form;
            InitializeComponent();
            DrowModel();
        }

        private void DrowModel()
        {
            //отрисовка
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            var graphics = Graphics.FromImage(pictureBox1.Image);
            model.Draw(graphics);
        }

        public void DrowModelSQL(ModelBase model, List<string> mas)
        {
            //отрисовка
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            var graphics = Graphics.FromImage(pictureBox1.Image);
            model.DrawSQL(graphics, mas);
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var obj = model.GetObject(e.X, e.Y);
            if (obj is TaskObject)
            {
                var taskPropertyForm = new PropertyForm<TaskObject>(obj as TaskObject);
                taskPropertyForm.Show(this);
            }
            //else
            //{
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
            //}
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            currentObject = model.GetObject(e.X, e.Y);
            //panel1.AutoScrollPosition.
            contextMenuStrip1.Show(this, e.X + panel1.AutoScrollPosition.X, e.Y + panel1.AutoScrollPosition.Y);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void addToQbeQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qbeForm.AddObjectInQbeQuery(currentObject);
        }

        public Graphics GetGraphics()
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            return Graphics.FromImage(pictureBox1.Image);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
