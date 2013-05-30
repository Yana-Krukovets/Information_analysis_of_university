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
        private QbeQueryForm qbeForm;

        public MainForm()
        {
            InitializeComponent();
            qbeForm = new QbeQueryForm(this);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        { }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        { }

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
                var docPropertyForm = new PropertyForm<WorkplaceLifeElement>(obj as WorkplaceLifeElement);
                docPropertyForm.Show(this);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateNewTab(new UseCaseModel());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreateNewTab(new CapacityWorkingPlaces());
        }

        public void CreateNewTab(ModelBase m)
        {
            var number = tcModelsFrame.TabPages.Count + 1;
            tcModelsFrame.TabPages.Add(new TabPage() { Name = "newTabPage" + number, Text = "Модель" + number });
            tcModelsFrame.TabPages[number - 1].Location = new System.Drawing.Point(4, 22);
            //this.newTabPage1.Name = "newTabPage1";
            tcModelsFrame.TabPages[number - 1].Padding = new System.Windows.Forms.Padding(3);
            tcModelsFrame.TabPages[number - 1].Size = tcModelsFrame.Size;
            tcModelsFrame.TabPages[number - 1].TabIndex = 0;
            //this.newTabPage1.Text = "new1";
            tcModelsFrame.TabPages[number - 1].UseVisualStyleBackColor = true;
            var newTab = new NewTabControl(m, qbeForm);
            tcModelsFrame.TabPages[number - 1].Controls.Add(newTab);
            newTab.Size = new Size(tcModelsFrame.Size.Width - 8, tcModelsFrame.Size.Height - 26);
            newTab.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right;
            //panel1 = new System.Windows.Forms.Panel();
            //pictureBox1 = new System.Windows.Forms.PictureBox();
        }

       
        private void pictureBox1_Click(object sender, EventArgs e)
        {        }

        private void button5_Click(object sender, EventArgs e)
        {
            CreateNewTab(new ResponsibilityDistributionModel());           
        }

        private void label1_Click(object sender, EventArgs e)
        {     }

        private void button4_Click(object sender, EventArgs e)
        {
            CreateNewTab(new DataStreamsModel());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CreateNewTab(new DocumentLifeCycleModel());
        }

        private void buttonSQL_Click(object sender, EventArgs e)
        {
            var requestSQL = new RequestSQL<CapacityWorkingPlaces>(model as CapacityWorkingPlaces);
            requestSQL.Show(this);
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {        }

        private void buttonMaster_Click(object sender, EventArgs e)
        {
            var requestMaster = new MasterQueryBuilding();
            requestMaster.Show(this);
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show(
                "После закрытия формы информация будет утеряна. Вы уверены, что хотите закрыть данную форму?",
                "Закрытие формы", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
                e.Cancel = true;
        }

        private void buttonQBE_Click(object sender, EventArgs e)
        {
            // {/*MdiParent = this, */Location = new Point(232, groupBox1.Size.Height + groupBox1.Location.Y), StartPosition = FormStartPosition.CenterParent};

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

        public void ExecuteQbeQuery(QbeQueryConteiner query)
        {
            //pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            //var graphics = Graphics.FromImage(pictureBox2.Image);
            var currentTab = tcModelsFrame.SelectedTab;

            var control = currentTab.Controls[0] as NewTabControl;//Find("NewTabControl", true);
            if (control != null)
            {
                //не правильно, т.к. изменения происходят и основной можели
                //нужно сделать глубокое копирование control.model
                CreateNewTab(control.model);
                control = tcModelsFrame.TabPages[tcModelsFrame.TabPages.Count - 1].Controls[0] as NewTabControl;
                tcModelsFrame.TabPages[tcModelsFrame.TabPages.Count - 1].Text = "qbeResult";
                //control.model.DrawQbe();
                if (control != null) control.model.DrawQbe(control.GetGraphics(), query);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void tcModelsFrame_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point location = new Point(0,0);

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
        //Нужно переписать, чтобы закрывалась та, по которой кликали
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentPage = tcModelsFrame.SelectedTab;

            if (MessageBox.Show("Вы действительно хотите закрыть активную вкладку?", "Звкрытие вкладки", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                tcModelsFrame.TabPages.Remove(currentPage);
        }

        private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newNameForm = new ChangeNameForm();
            newNameForm.ShowDialog(this);
            tcModelsFrame.SelectedTab.Text = newNameForm.NewName ?? tcModelsFrame.SelectedTab.Text;
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Title = "Сохранить картинку как ...";
            savedialog.OverwritePrompt = true;
            savedialog.CheckPathExists = true;
            savedialog.Filter =
                "Bitmap File(*.bmp)|*.bmp|" +
                "GIF File(*.gif)|*.gif|" +
                "JPEG File(*.jpg)|*.jpg|" +
                "TIF File(*.tif)|*.tif|" +
                "PNG File(*.png)|*.png";
            savedialog.ShowHelp = true;
            var bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            // If selected, save
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                // Get the user-selected file name
                string fileName = savedialog.FileName;
                // Get the extension
                string strFilExtn =
                    fileName.Remove(0, fileName.Length - 3);
                // Save file
                switch (strFilExtn)
                {
                    case "bmp":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case "jpg":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case "gif":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case "tif":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                    case "png":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
                        break;
                }
            }
        }

        private void analisButton_Click(object sender, EventArgs e)
        {
            var AnalisForm = new AnalisResultForm();
            AnalisForm.Show(this);
        }

    }
}
