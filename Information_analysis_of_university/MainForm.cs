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
            model = new UseCaseModel();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {      }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {}

        //private void DrowModel(ModelBase model)
        //{
        //    //отрисовка
        //    pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        //    var graphics = Graphics.FromImage(pictureBox1.Image);
        //    model.Draw(graphics);
        //}

        public void DrowModelSQL(ModelBase model, List<string> mas)
        {
            //отрисовка
            pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            var graphics = Graphics.FromImage(pictureBox2.Image);
            model.DrawSQL(graphics, mas);
        } 

        private void button1_Click(object sender, EventArgs e)
        {
            CreateNewTab(new WorkProcessModel());
           // model = new WorkProcessModel();
           // DrowModel(model);
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
                if (obj is WorkplaceLifeElement)
                {
                    var docPropertyForm = new PropertyForm<WorkplaceLifeElement>(obj as WorkplaceLifeElement);
                    docPropertyForm.Show(this);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateNewTab(new UseCaseModel());
            //model = new UseCaseModel();
            //DrowModel(model);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreateNewTab(new CapacityWorkingPlaces());
            //model = new CapacityWorkingPlaces();
            //DrowModel(model);
        }

        public void CreateNewTab(ModelBase m)
        {
            var number = tcModelsFrame.TabPages.Count + 1;
            tcModelsFrame.TabPages.Add(new TabPage() { Name = "newTabPage" + number, Text = "new" + number });
            tcModelsFrame.TabPages[number - 1].Location = new System.Drawing.Point(4, 22);
            //this.newTabPage1.Name = "newTabPage1";
            tcModelsFrame.TabPages[number - 1].Padding = new System.Windows.Forms.Padding(3);
            tcModelsFrame.TabPages[number - 1].Size = tcModelsFrame.Size;
            tcModelsFrame.TabPages[number - 1].TabIndex = 0;
            //this.newTabPage1.Text = "new1";
            tcModelsFrame.TabPages[number - 1].UseVisualStyleBackColor = true;
            var newTab = new NewTabControl(m);
            tcModelsFrame.TabPages[number - 1].Controls.Add(newTab);
            newTab.Size = new Size(tcModelsFrame.Size.Width - 8, tcModelsFrame.Size.Height - 26);
            newTab.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right;
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
            CreateNewTab(new ResponsibilityDistributionModel());
            //model = new ResponsibilityDistributionModel();
            //DrowModel(model);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            CreateNewTab(new DataStreamsModel());
            //model = new DataStreamsModel();
            //DrowModel(model);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CreateNewTab(new DocumentLifeCycleModel());
            //model = new DocumentLifeCycleModel();
            //DrowModel(model);
        }

        private void buttonSQL_Click(object sender, EventArgs e)
        {
            if (model is CapacityWorkingPlaces)
            {
                var requestSQL = new RequestSQL<CapacityWorkingPlaces>(model as CapacityWorkingPlaces);
                requestSQL.Show(this);
            }
            if (model is DataStreamsModel)
            {
                var requestSQL = new RequestSQL<DataStreamsModel>(model as DataStreamsModel);
                requestSQL.Show(this);
            }
            if (model is DocumentLifeCycleModel)
            {
                var requestSQL = new RequestSQL<DocumentLifeCycleModel>(model as DocumentLifeCycleModel);
                requestSQL.Show(this);
            }
            if (model is ResponsibilityDistributionModel)
            {
                var requestSQL = new RequestSQL<ResponsibilityDistributionModel>(model as ResponsibilityDistributionModel);
                requestSQL.Show(this);
            }
            if (model is UseCaseModel)
            {
                var requestSQL = new RequestSQL<UseCaseModel>(model as UseCaseModel);
                requestSQL.Show(this);
            }
            if (model is WorkProcessModel)
            {
                var requestSQL = new RequestSQL<WorkProcessModel>(model as WorkProcessModel);
                requestSQL.Show(this);
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonMaster_Click(object sender, EventArgs e)
        {
            var requestMaster = new MasterQueryBuilding();
            requestMaster.Show(this);
        }

        private void buttonQBE_Click(object sender, EventArgs e)
        {
            var childForm = new QbeQueryForm();// { MdiParent = this };
            childForm.Show();
        }

    }
}
