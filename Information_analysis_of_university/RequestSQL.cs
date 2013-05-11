using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Information_analysis_of_university.Models;
using System.Text.RegularExpressions;

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
            var select = mas[0].Split(' ');
            var from = mas[1].Split(' ');
            Regex pattern = new Regex(@"\[([^\]]+)\]");
            Regex pattern1 = new Regex(@"(?<=\[)(.*)(?=\])");
            var select1 = pattern.Matches(mas[0]);
            var from1 = pattern.Matches(mas[1]);
            List<string> sel = new List<string>();
            List<string> fr = new List<string>();
            for (int i = 0; i < select1.Count; i++)
            {
                string p = select1[i].Value;
                sel.Add(pattern1.Match(p).Value);
            }
            for (int i = 0; i < from1.Count; i++)
            {
                string p = from1[i].Value;
                fr.Add(pattern1.Match(p).Value);
            }

            drawSQLModel(sel, fr);
        }

        public void drawSQLModel(List<string> select, List<string> from)
        {
            foreach (var item in from)
            {
                if (item == "Модель вариантов использования")
                {
                    m = new UseCaseModel();
                    MainForm form = new MainForm();
                    form.Show();
                    form.DrowModelSQL(m, select);
                }
                if (item == "Модель нагружености рабочих мест")
                {
                    m = new CapacityWorkingPlaces();
                    MainForm form = new MainForm();
                    form.Show();
                    form.DrowModelSQL(m, select);
                }
                if (item == "Модель потоков данных")
                {
                    m = new DataStreamsModel();
                    MainForm form = new MainForm();
                    form.Show();
                    form.DrowModelSQL(m, select);
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
