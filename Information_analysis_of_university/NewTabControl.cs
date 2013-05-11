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
        private ModelBase model;

        public NewTabControl(ModelBase newModel)
        {
            model = newModel;
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
            else
            {
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
            }
        }
    }
}
