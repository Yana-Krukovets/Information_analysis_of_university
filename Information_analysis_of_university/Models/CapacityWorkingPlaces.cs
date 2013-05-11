using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using DatabaseLevel;
using Information_analysis_of_university.Objects;

namespace Information_analysis_of_university.Models
{
    class CapacityWorkingPlaces : ModelBase
    {
        private List<Departments> departmentList;

        public CapacityWorkingPlaces()
        {

            departmentList = new List<Departments>();
            var departmentRepository = new BaseDocumentRepository<Department>();
  
            var departments = departmentRepository.ToList().Select(
                x => new WorkingPlace(x));

            foreach (var item in departments)
            {
                departmentList.Add(new Departments(item));
            }
        }

        public override void Draw(Graphics g)
        {
            var x = 50;
            var y = 50;

            var heignt = 100;
            var width = 150;
            foreach (var worker in departmentList)
            {
                worker.WorkPlace.DrawObject(g, x, y);
                worker.DrawCount(g, x+10,y+10);
                // worker.DrawDocuments(g);
                if (x + 5 * width < g.VisibleClipBounds.Width)
                    x += 3 * width;
                else
                {
                    x = 50;
                    y = y + 3 * heignt / 2;
                }
            }
        }

        public override void DrawSQL(Graphics g, string[] mas)
        {
        }

        public override BaseObject GetObject(int x, int y)
        {
            BaseObject obj = null;
            foreach (var name in departmentList)
            {
                obj = name.GetObject(x, y);
                if (obj != null)
                    break;
            }

            return obj;
        }
    }

    class Departments
    {
        public WorkingPlace WorkPlace { get; set; }
        public CountTaks documentCount { get; set; }
        public DocumentForWorker doc { get; set; }
        
        public Departments(WorkingPlace workPlace)
        {
            WorkPlace = workPlace;
            var taskDocumentRepository = new BaseDocumentRepository<Task>();
            var documentRepository = new BaseDocumentRepository<Document>();
            var documents = documentRepository.Query(x => x.FK_DepartmentIdDestination == WorkPlace.Id).ToList();
            int col = documents.Count();
            documentCount = new CountTaks(col);

        }     
      
        public void DrawCount(Graphics g, int x, int y)
        {
            documentCount.DrawObject(g, x, y);
        }

        public BaseObject GetObject(int x, int y)
        {
            BaseObject curObj = null;
            if (WorkPlace.IsCurrentObject(x, y))
                curObj = WorkPlace;
            return curObj;
        }

    }
}
