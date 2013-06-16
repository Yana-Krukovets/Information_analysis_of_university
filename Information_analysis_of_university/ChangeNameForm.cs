using System;
using System.Windows.Forms;

namespace Information_analysis_of_university
{
    //форма диалога изменения имения/ввода имени вкладки
    public partial class ChangeNameForm : Form
    {
        //имя вкладки
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

        //событие нажатия кнопки "Ок"
        //принятие введенного имени
        private void brOk_Click(object sender, EventArgs e)
        {
            newName = tbNewName.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //событие нажатия кнопки "Отмена"
        //Отмена ввода/переименования
        private void btCancel_Click(object sender, EventArgs e)
        {
            newName = null;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //событие закрытия диалогового окна
        private void ChangeNameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Cancel)
                newName = null;
        }
    }
}
