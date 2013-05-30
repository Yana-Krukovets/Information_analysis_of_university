using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Information_analysis_of_university.Objects;

namespace Information_analysis_of_university
{
    public class AnalisResultItem
    {
        public string ErrorText
        {
            get { return Objects.Description.GetDescription(Error); }
        }
        public string LocalisationPlace { get; set; }
        public string Description { get; set; }
        public string Decision { get; set; }

        public ErrorType Error { get; set; }
        public List<Models.ModelBase> ModelList { get; set; }
    }

    public enum ErrorType
    {
        [Description("Дублирование информации")]
        CloneInformation,
        
        [Description("Разное толкование")]
        DifferentInterpretation,
        
        [Description("Нагруженность рабочих мест")]
        WorkplaceWorkload
    }
}
