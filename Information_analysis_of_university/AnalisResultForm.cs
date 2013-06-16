using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DatabaseLevel;

namespace Information_analysis_of_university
{
    //форма отображения результатов анализа
    public partial class AnalisResultForm : Form
    {
        //контейнер результатов
        public AnalisResultConteiner ResultConteiner;
        //объект класса-анализатора
        public Analisator Analisator;

        public AnalisResultForm()
        {
            InitializeComponent();

            //связываем компонент-навигатор с компонентом DataGridView
            ResultConteiner = new AnalisResultConteiner();
            var bSource = new BindingSource();
            bSource.DataSource = ResultConteiner;
            bindingNavigator1.BindingSource = bSource;
            dataGridView1.DataSource = bSource;

            //запуск анализатора
            Analisator = new Analisator();
            
            //отображение ошибок
            FillCloneInfo();
        }

        //функция отображения ошибок
        private void FillCloneInfo()
        {
            //получение ошибок
            var resultList = Analisator.IsCloneInformation();
            foreach (var item in resultList)
            {
                if(item != null && item.Count != 0)
                {
                    var DocList = new List<DocumentName>();
                    var str_palce = "Документы: ";
                    foreach (var docInfo in item)
                    {
                        str_palce += docInfo.DocumentName.Name;
                        if(item.Last() != docInfo)
                            str_palce += ", ";
                        DocList.Add(docInfo.DocumentName);
                    }

                    var str_description = " вручную заполняется поле " + item[0].Field.Name;
                    ResultConteiner.Add(new AnalisResultItem()
                                            {
                                                Error = ErrorType.CloneInformation,
                                                LocalisationPlace = str_palce,
                                                Description = str_description,
                                                Decision = "Ввести единый справочник для данного поля",
                                                Documents = DocList
                                            });
                }
            }
        }

        public List<DocumentName> GetDocuments()
        {
            var docs = new List<DocumentName>();
            foreach (var item in ResultConteiner)
            {
                docs.AddRange(item.Documents);
            }
            return docs;
        }
    }
}
