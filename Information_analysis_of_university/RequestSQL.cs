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
        ModelBase m;
        public RequestSQL(T mod)
        {
            model = mod;
           // m = new ModelBase();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var t = SQL.Text;
            var mas = t.Split('\n');
            var select = mas[0].Split(',', ' ');
            var from = mas[1].Split(',', ' ');
          //  var where = mas[2].Split(',', ' ');
            drawSQLModel(select, from);
        }

        public void drawSQLModel(string[] select, string[] from)
        {
            foreach (var item in from)
            {
                if (item == "Модель_вариантов_использования")
                {
                    m = new UseCaseModel();
                }
                if (item == "Модель_нагружености_рабочих_мест")
                {
                    m = new CapacityWorkingPlaces();
                    MainForm form = new MainForm();
                    form.DrowModelSQL(m, select);
                }
                if (item == "Модель_потоков_данных")
                {
                }
                if (item == "Модель_рабочих_процессов")
                {
                }
                if (item == "Модель_распредиления_обязательств")
                {
                }
                if (item == "Модель_жизненного_цикла")
                {
                }
            }
        }
    }
}
