using System;
using System.Windows.Forms;
using Information_analysis_of_university.Objects;

namespace Information_analysis_of_university
{
    //форма отображения свойств объекта модели
    public partial class PropertyForm<T> : Form where T: BaseObject 
    {
        //объект, чьи свойства выводятся
        private T document;

        public PropertyForm(T doc)
        {
            document = doc;
            InitializeComponent();

            documentPropertyGrid.SelectedObject = document;
        }

        private void documentPropertyGrid_Click(object sender, EventArgs e)
        {

        }


    }
}
