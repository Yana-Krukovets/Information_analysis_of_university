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
    public partial class RequestSQL<T> : Form where T : ModelBase 
    {
        private T model;

        public RequestSQL(T mod)
        {
            model = mod;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var t = SQL.Text;
            var mas = t.Split('\n');
            var select = mas[0].Split(',');
            var from = mas[1].Split(',');
            var where = mas[2].Split(',');
        }
    }
}
