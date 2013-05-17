using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Information_analysis_of_university
{
    public class QbeQueryConteiner : BindingList<QbeQueryItem>
    {
        public Dictionary<int, string> CurrentItemNumbers { get; set; }

        public QbeQueryConteiner()
        {
            AllowNew = true;
            AllowEdit = true;
            RaiseListChangedEvents = true;
        }

        public bool IsConteinsTaskMetric()
        {
            return CurrentItemNumbers.Values.Any(x => x == "taskName");
        }

        public bool IsContainsDocumentMetric()
        {
            return
                CurrentItemNumbers.Values.Any(
                    x =>
                    x.ToLower().StartsWith("document") || x == "responsible" || x.Contains("External") ||
                    x == "isElectronic" || x.Contains("Program"));
        }

        public bool IsContainsWorkplaceMetric()
        {
            return IsConteinsPostName() || IsConteinsDepartmentName() || IsConteinsResponsibleWorker();
        }

        public bool IsContainsCapacityItems()
        {
            return IsConteinsTaskCount() || IsConteinsDocumentCount();
        }

        public bool IsContainsLittleManMetric()
        {
            return IsConteinsResponsibleWorker() || IsConteinsPostName();
        }

        public bool IsConteinsDocumentName()
        {
            return CurrentItemNumbers.Values.Any(x => x == "DocumentName");
        }

        public bool IsConteinsDocumentType()
        {
            return CurrentItemNumbers.Values.Any(x => x == "documentType");
        }

        public bool IsConteinsFrequency()
        {
            return CurrentItemNumbers.Values.Any(x => x == "documentFrequency");
        }

        public bool IsConteinsIsElectronic()
        {
            return CurrentItemNumbers.Values.Any(x => x == "isElectronic");
        }

        public bool IsConteinsIsExternal()
        {
            return CurrentItemNumbers.Values.Any(x => x == "isExternal");
        }

        public bool IsConteinsExternalSource()
        {
            return CurrentItemNumbers.Values.Any(x => x == "ExternalSource");
        }

        public bool IsConteinsExternalDistination()
        {
            return CurrentItemNumbers.Values.Any(x => x == "ExternalDistination");
        }

        public bool IsConteinsDocumentFunction()
        {
            return CurrentItemNumbers.Values.Any(x => x == "DocumentFunction");
        }

        public bool IsConteinsResponsibleWorker()
        {
            return CurrentItemNumbers.Values.Any(x => x == "responsibleWorker");
        }

        public bool IsConteinsDepartmentName()
        {
            return CurrentItemNumbers.Values.Any(x => x == "department");
        }

        public bool IsConteinsPostName()
        {
            return CurrentItemNumbers.Values.Any(x => x == "post");
        }

        public bool IsConteinsTaskName()
        {
            return CurrentItemNumbers.Values.Any(x => x == "taskName");
        }

        public bool IsConteinsIsProgram()
        {
            return CurrentItemNumbers.Values.Any(x => x == "isProgram");
        }

        public bool IsConteinsProgramName()
        {
            return CurrentItemNumbers.Values.Any(x => x == "programName");
        }

        public bool IsConteinsTaskCount()
        {
            return CurrentItemNumbers.Values.Any(x => x == "TaskCount");
        }

        public bool IsConteinsDocumentCount()
        {
            return CurrentItemNumbers.Values.Any(x => x == "DocumentCount");
        }
    }
}
