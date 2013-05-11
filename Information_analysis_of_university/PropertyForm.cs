using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Information_analysis_of_university.Objects;

namespace Information_analysis_of_university
{
    public partial class PropertyForm<T> : Form where T: BaseObject 
    {
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
