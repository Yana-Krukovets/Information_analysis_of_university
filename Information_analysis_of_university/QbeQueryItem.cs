using System.ComponentModel;
using Information_analysis_of_university.Objects;

namespace Information_analysis_of_university
{
    //класс элемента QBE-запроса
    public class QbeQueryItem
    {
        //наименование документа
        public string DocumentName { get; set; }
        //частота заполнения
        public string Frequency { get; set; }
        //элктронный (true) или бумажный (false)
        public bool IsElectronic { get; set; }
        //внешний (true) или внутренний (false)
        public bool IsExternal { get; set; }
        //организация-внешний источник
        public string ExternalSource { get; set; }
        //организация-внешний приемник документа
        public string ExternalDistination { get; set; }
        //тип документа
        public string DocumentType { get; set; }
        //назначение документа
        public string DocumentFunction { get; set; }
        //ответственный исполнитель
        public string ResponsibleWorker { get; set; }
        //наименование подразделения
        public string DepartmentName { get; set; }
        //наименование должности-исполнителя
        public string PostName { get; set; }
        //наименование задачи, в уоторую входит документ
        public string TaskName { get; set; }
        //запоняется программой (true)
        public bool IsProgram { get; set; }
        //наименованние программы
        public string ProgramName { get; set; }
        //количество задач
        public int TaskCount { get; set; }
        //количество документов
        public int DocunentCount { get; set; }
    }
}
