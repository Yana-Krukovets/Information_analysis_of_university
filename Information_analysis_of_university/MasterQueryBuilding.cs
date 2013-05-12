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
using DatabaseLevel;

namespace Information_analysis_of_university
{
    public partial class MasterQueryBuilding : Form
    {
        public MasterQueryBuilding()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (capacityWorkingPlaces.Checked == true)
            {
            }
            if (dataStreamsModel.Checked == true)
            {
            }
            if (lifeCycleModel.Checked == true)
            {
            }
            if (responsibilityModel.Checked == true)
            {
            }
            if (useCaseModel.Checked == true)
            {
            }
            if (WorkProcassModel.Checked == true)
            {
            }
        }
    }
}
