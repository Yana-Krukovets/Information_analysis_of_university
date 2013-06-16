using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Information_analysis_of_university
{
    //класс-контейней QBE-запросов
    public class QbeQueryConteiner : BindingList<QbeQueryItem>
    {
        //список используемых метрик при выборке
        public Dictionary<int, string> CurrentItemNumbers { get; set; }

        public QbeQueryConteiner()
        {
            AllowNew = true;
            AllowEdit = true;
            RaiseListChangedEvents = true;
        }

        //проверяет включены ли метрики для объектов "Задача"
        public bool IsConteinsTaskMetric()
        {
            return CurrentItemNumbers.Values.Any(x => x == "taskName");
        }

        //проверяет включены ли метрики для объектов "Документ"
        public bool IsContainsDocumentMetric()
        {
            return
                CurrentItemNumbers.Values.Any(
                    x =>
                    x.ToLower().StartsWith("document") || x == "responsible" || x.Contains("External") ||
                    x == "isElectronic" || x.Contains("Program"));
        }

        //проверяет включены ли метрики для объектов "Рабочее место"
        public bool IsContainsWorkplaceMetric()
        {
            return IsConteinsPostName() || IsConteinsDepartmentName() || IsConteinsResponsibleWorker();
        }

        //проверяет включены ли метрики для модели нагруженности
        public bool IsContainsCapacityItems()
        {
            return IsConteinsTaskCount() || IsConteinsDocumentCount();
        }

        //проверяет включены ли метрики для объектов "LittleMan"
        public bool IsContainsLittleManMetric()
        {
            return IsConteinsResponsibleWorker() || IsConteinsPostName();
        }

        //проверяет включены ли метрика "DocumentName"
        public bool IsConteinsDocumentName()
        {
            return CurrentItemNumbers.Values.Any(x => x == "DocumentName");
        }

        //проверяет включены ли метрика "documentType"
        public bool IsConteinsDocumentType()
        {
            return CurrentItemNumbers.Values.Any(x => x == "documentType");
        }

        //проверяет включены ли метрика "documentFrequency"
        public bool IsConteinsFrequency()
        {
            return CurrentItemNumbers.Values.Any(x => x == "documentFrequency");
        }

        //проверяет включены ли метрика "isElectronic"
        public bool IsConteinsIsElectronic()
        {
            return CurrentItemNumbers.Values.Any(x => x == "isElectronic");
        }

        //проверяет включены ли метрика "isExternal"
        public bool IsConteinsIsExternal()
        {
            return CurrentItemNumbers.Values.Any(x => x == "isExternal");
        }

        //проверяет включены ли метрика "ExternalSource"
        public bool IsConteinsExternalSource()
        {
            return CurrentItemNumbers.Values.Any(x => x == "ExternalSource");
        }

        //проверяет включены ли метрика "ExternalDistination"
        public bool IsConteinsExternalDistination()
        {
            return CurrentItemNumbers.Values.Any(x => x == "ExternalDistination");
        }

        //проверяет включены ли метрика "DocumentFunction"
        public bool IsConteinsDocumentFunction()
        {
            return CurrentItemNumbers.Values.Any(x => x == "DocumentFunction");
        }

        //проверяет включены ли метрика "responsibleWorker"
        public bool IsConteinsResponsibleWorker()
        {
            return CurrentItemNumbers.Values.Any(x => x == "responsibleWorker");
        }

        //проверяет включены ли метрика "department"
        public bool IsConteinsDepartmentName()
        {
            return CurrentItemNumbers.Values.Any(x => x == "department");
        }

        //проверяет включены ли метрика "post"
        public bool IsConteinsPostName()
        {
            return CurrentItemNumbers.Values.Any(x => x == "post");
        }

        //проверяет включены ли метрика "taskName"
        public bool IsConteinsTaskName()
        {
            return CurrentItemNumbers.Values.Any(x => x == "taskName");
        }

        //проверяет включены ли метрика "isProgram"
        public bool IsConteinsIsProgram()
        {
            return CurrentItemNumbers.Values.Any(x => x == "isProgram");
        }

        //проверяет включены ли метрика "programName"
        public bool IsConteinsProgramName()
        {
            return CurrentItemNumbers.Values.Any(x => x == "programName");
        }

        //проверяет включены ли метрика "TaskCount"
        public bool IsConteinsTaskCount()
        {
            return CurrentItemNumbers.Values.Any(x => x == "TaskCount");
        }

        //проверяет включены ли метрика "DocumentCount"
        public bool IsConteinsDocumentCount()
        {
            return CurrentItemNumbers.Values.Any(x => x == "DocumentCount");
        }
    }
}
