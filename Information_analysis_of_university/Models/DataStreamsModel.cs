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
    class DataStreamsModel : ModelBase
    {
        private List<Departments1> departmentList;

        public DataStreamsModel()
        {

            departmentList = new List<Departments1>();
            var departmentRepository = new BaseDocumentRepository<Department>();

            var departments = departmentRepository.ToList().Select(
                x => new WorkingPlace(x));

            foreach (var item in departments)
            {
                departmentList.Add(new Departments1(item));
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
                worker.DrawDocument(g, x, y);
                worker.DrawDocumentFunction(g, x, y);
                if (x + 5 * width < g.VisibleClipBounds.Width)
                    x += 5 * width;
                else
                {
                    x = 50;
                    y = y + 3 * heignt/2;
                }
            }
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

    class Departments1
    {
        public WorkingPlace WorkPlace { get; set; }
        public List<DocFuction> docFunction { get; set; }
        public List<DocumentForStreams> documentStreams { get; set; }
        
        public Departments1(WorkingPlace workPlace)
        {
            WorkPlace = workPlace;
            var documentRepository = new BaseDocumentRepository<Document>();
            var documents = documentRepository.Query(x => x.FK_DepartmentIdDestination == WorkPlace.Id).ToList();
            documentStreams = new List<DocumentForStreams>();
            docFunction = new List<DocFuction>();
            foreach (var item in documents)
            {
                documentStreams.Add(new DocumentForStreams(item));
            }
            foreach (var item in documents)
            {
                docFunction.Add(new DocFuction(item));
            }
        }

        public void DrawDocument(Graphics g, int x, int y)
        {
            if (documentStreams != null)
            {
                x -= 300;
                for (int j = 0; j < documentStreams.Count; j++)
                {
                    documentStreams[j].DrawObject(g, x, y); 
                    y += 30;
                }
              
            }
        }

        public void DrawDocumentFunction(Graphics g, int x, int y)
        {
            if (docFunction != null)
            {
                x -= 400;
                for (int j = 0; j < docFunction.Count; j++)
                {
                    docFunction[j].DrawObject(g, x, y);
                    y += 70;
                }

            }
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
