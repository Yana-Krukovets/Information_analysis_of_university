using System.ComponentModel;

namespace Information_analysis_of_university
{
    //класс-контейнер результатов анализа
    public class AnalisResultConteiner : BindingList<AnalisResultItem>
    {
        public AnalisResultConteiner()
        {
            AllowNew = true;
            AllowEdit = true;
            RaiseListChangedEvents = true;
        }
    }
}
