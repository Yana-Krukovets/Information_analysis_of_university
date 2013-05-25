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
    public partial class ChangeNameForm : Form
    {
        private string newName;

        public string NewName
        {
            get { return newName; }
        }

        public ChangeNameForm()
        {
            this.DialogResult = DialogResult.Cancel;
            InitializeComponent();
        }

        private void brOk_Click(object sender, EventArgs e)
        {
            newName = tbNewName.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            newName = null;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ChangeNameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Cancel)
                newName = null;
        }

    }
}
