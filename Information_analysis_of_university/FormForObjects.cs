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
    public partial class FormForObjects<T> : Form where T : ModelBase
    {
        private T model;

        public FormForObjects(T mod)
        {
            model = mod;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> elem = new List<string>();
            foreach (Control che in this.Controls)
            {                
               //определение выбраных элементов
                if (che.GetType().ToString().IndexOf("CheckBox") > -1)
                {
                    CheckBox che1 = (CheckBox)che;
                    if (che1.Checked == true)
                    {
                        elem.Add(che1.Text);    
                    }
                }
            }
            MainForm form = new MainForm();
            //отрисовка модели
            form.Show();
            form.DrowModelSQL(model, elem);
            
        }

        private void FormForObjects_FormClosing(object sender, FormClosingEventArgs e)
        {
            //закрытие формы
            var result = MessageBox.Show(
                "После закрытия формы информация будет утеряна. Вы уверены, что хотите закрыть данную форму?",
                "Закрытие формы", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
                e.Cancel = true;
        }

        private void FormForObjects_Load(object sender, EventArgs e)
        {        }

        private void button2_Click(object sender, EventArgs e)
        {
           //закрытие формы
            this.Close();
        }
    }
}
