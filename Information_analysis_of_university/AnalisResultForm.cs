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
    public partial class AnalisResultForm : Form
    {
        public AnalisResultConteiner ResultConteiner;
        public Analisator Analisator;

        public AnalisResultForm()
        {
            InitializeComponent();

            ResultConteiner = new AnalisResultConteiner();
            var bSource = new BindingSource();
            bSource.DataSource = ResultConteiner;
            bindingNavigator1.BindingSource = bSource;
            dataGridView1.DataSource = bSource;

            Analisator = new Analisator();
            
            FillCloneInfo();
        }

        private void FillCloneInfo()
        {
            var resultList = Analisator.IsCloneInformation();
            foreach (var item in resultList)
            {
                if(item != null && item.Count != 0)
                {
                    var str = "В документах ";
                    foreach (var docInfo in item)
                    {
                        str += docInfo.DocumentName.Name;
                        if(item.Last() != docInfo)
                            str += ", ";
                    }
                    str += " вручную заполняется поле " + item[0].Field.Name;
                    ResultConteiner.Add(new AnalisResultItem()
                                            {
                                                Error = ErrorType.CloneInformation,
                                                Description = str,
                                                Decision = "Ввести единый справочник для данного поля"
                                            });
                }
            }
        }
    }
}
