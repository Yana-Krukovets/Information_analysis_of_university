using System.Collections.Generic;
using DatabaseLevel;
using Information_analysis_of_university.Objects;

namespace Information_analysis_of_university
{
    //класс, содержащий информацию о недостаке систмы документооборота
    public class AnalisResultItem
    {
        //текст недостатка
        public string ErrorText
        {
            get { return Objects.Description.GetDescription(Error); }
        }
        //место, где был обнаружен
        public string LocalisationPlace { get; set; }
        //описание
        public string Description { get; set; }
        //решение
        public string Decision { get; set; }
        //тип недостатка
        public ErrorType Error { get; set; }
        //список моделей
        public List<Models.ModelBase> ModelList { get; set; }
        //список документов, в которых обнаружен недостаток
        public List<DocumentName> Documents { get; set; }
    }

    //перечисление типов недостатков
    public enum ErrorType
    {
        [Description("Дублирование информации")]
        CloneInformation,
        
        [Description("Разное толкование")]
        DifferentInterpretation
    }
}
