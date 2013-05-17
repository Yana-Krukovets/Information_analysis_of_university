using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Information_analysis_of_university.Objects;

namespace Information_analysis_of_university
{
    public class QbeQueryItem
    {
        //поля Id не будут учавствовать в выборке
       // public int Id { get; set; }
        public BaseDocumentObject Document { get; set; }
        public string DocumentName { get; set; }
        public string Frequency { get; set; }
        public bool IsElectronic { get; set; }
        public bool IsExternal { get; set; }
        public string ExternalSource { get; set; }
        public string ExternalDistination { get; set; }
        public string DocumentType { get; set; }
        public string DocumentFunction { get; set; }
        public string ResponsibleWorker { get; set; }
       // public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
       // public int PostId { get; set; }
        public string PostName { get; set; }
       // public int TaskId { get; set; }
        public string TaskName { get; set; }
        public bool IsProgram { get; set; }
        public string ProgramName { get; set; }

        //для CapacityWorkingPlaces
        public int TaskCount { get; set; }
        public int DocunentCount { get; set; }
    }
}
