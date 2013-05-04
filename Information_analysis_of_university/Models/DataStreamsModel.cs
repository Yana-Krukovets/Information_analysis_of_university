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
            var x = 700;
            var y = 100;
            foreach (var worker in departmentList)
            {
                worker.WorkPlace.DrawObject(g, x, y);
                worker.DrawDocument(g, x, y);
                y += 300;              
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
        public List<DocFuction> docFunction1 { get; set; }
        public List<DocFuction> docFunction2 { get; set; }
        public List<DocumentForStreams> documentStreams { get; set; }
        public List<DocumentForStreams> documentStreams1 { get; set; }
        public List<DocumentForStreams> documentStreams2 { get; set; }
        
        public Departments1(WorkingPlace workPlace)
        {
            WorkPlace = workPlace;
            var documentRepository = new BaseDocumentRepository<Document>();
            var documents = documentRepository.Query(x => x.FK_DepartmentIdDestination == WorkPlace.Id).ToList();
            var documents1 = documentRepository.Query(x => x.FK_DepartmentIdSource == WorkPlace.Id).ToList();
            documentStreams = new List<DocumentForStreams>();
            documentStreams1 = new List<DocumentForStreams>();
            documentStreams2 = new List<DocumentForStreams>();
            docFunction = new List<DocFuction>();
            docFunction1 = new List<DocFuction>();
            docFunction2 = new List<DocFuction>();
            foreach (var item in documents1)
            {
                if (item.FK_DepartmentIdSource == WorkPlace.Id)
                    documentStreams2.Add(new DocumentForStreams(item));                   
            }
            foreach (var item in documents)
            {
                if (item.FK_DepartmentIdDestination == WorkPlace.Id)
                    documentStreams.Add(new DocumentForStreams(item));
                
            }
            foreach (var item in documents)
            {
                docFunction.Add(new DocFuction(item));
            }
           
            for (int j = 0; j < documentStreams.Count; j++)
            {
                if (documentStreams[j].IsExternal == 2)
                {
                    documentStreams2.Add(documentStreams[j]);
                    docFunction2.Add(docFunction[j]);
                }
                if (documentStreams[j].IsExternal == 1)
                {
                    documentStreams1.Add(documentStreams[j]);
                    docFunction1.Add(docFunction[j]);
                }
                
            }
        }

        public void DrawDocument(Graphics g, int x, int y)
        {
            if (documentStreams != null || documentStreams2 != null)
            {
                x = WorkPlace.CoordX;
                var pen = new Pen(Color.Black);
                y = WorkPlace.CoordY;
                int y2 = WorkPlace.CoordY; 
                int Y = WorkPlace.CoordY + 50;
                int X = WorkPlace.CoordX;
                for (int j = 0; j < documentStreams1.Count; j++)
                {
                    y = WorkPlace.CoordY + 3 * documentStreams1.Count * (j * 10) / documentStreams1.Count;
                    documentStreams1[j].DrawObject(g, WorkPlace.CoordX, y);
                    g.DrawLine(pen, X + 100, Y, X + 220, y);                 
                    y2 = documentStreams1[j].CoordY - 30 + 6 * docFunction1.Count * (j * 10) / docFunction1.Count;
                    docFunction1[j].DrawObject(g, documentStreams1[j].CoordX + 500, y2 - 30);
                    g.DrawLine(pen, documentStreams1[j].CoordX + 440, y, documentStreams1[j].CoordX + 500, y2);
                }
                for (int j = 0; j < documentStreams2.Count; j++)
                {
                    y = WorkPlace.CoordY + 3 * documentStreams2.Count * (j * 10) / documentStreams2.Count;
                    documentStreams2[j].DrawObject(g, WorkPlace.CoordX - 540, y);
                    g.DrawLine(pen, WorkPlace.CoordX, Y, WorkPlace.CoordX - 100, y);
                    if (docFunction2.Count != 0)
                    {
                        y2 = documentStreams2[j].CoordY - 30 + 6 * docFunction2.Count * (j * 10) / docFunction2.Count;
                        docFunction2[j].DrawObject(g, documentStreams2[j].CoordX, y2 - 30);
                        g.DrawLine(pen, documentStreams2[j].CoordX + 100, y2, documentStreams2[j].CoordX + 220, y);
                    }         
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
