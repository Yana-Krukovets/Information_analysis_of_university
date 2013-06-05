using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Information_analysis_of_university
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show(
                "Вы уверены, что хотите закрыть данную форму?",
                "Закрытие формы", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
                e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
               "Вы уверены, что хотите закрыть данную форму?",
               "Закрытие формы", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
                this.Close();

        }
    }
}
