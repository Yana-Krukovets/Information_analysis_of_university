using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Drawing;
using DatabaseLevel;
using Information_analysis_of_university.Objects;


namespace Information_analysis_of_university.Models
{
    public class WorkProcessModel : ModelBase
    {
        private List<TaskDocument> taskList;

        public WorkProcessModel()
        {
            taskList = new List<TaskDocument>();
            var taskDocumentRepository = new BaseDocumentRepository<Task>();

            var tasks = taskDocumentRepository.ToList().Select(
                x => new TaskObject(x));

            foreach (var item in tasks)
            {
                taskList.Add(new TaskDocument(item));
            }
        }

        public override void DrawSQL(Graphics g, List<string> mas)
        {
            var x = 150;
            var y = 50;

            var heignt = 150;
            var width = 150;

            foreach (var task in taskList)
            {
                foreach (var item in mas)
                {
                    if (item == task.Task.Name)
                    {
                        task.Task.DrawObject(g, x, y);

                        task.DrawDocuments(g);

                        //расчет координат нового квадрата
                        if (x + 5 * width < g.VisibleClipBounds.Width)
                            x += 3 * width;
                        else
                        {
                            x = 150;
                            y = y + 3 * heignt / 2;
                        }
                    }
                }
            }
        }

        public override void Draw(Graphics g)
        {
            var x = 150;
            var y = 50;

            var heignt = 150;
            var width = 150;

            foreach (var task in taskList)
            {
                task.Task.DrawObject(g, x, y);

                task.DrawDocuments(g);

                //расчет координат нового квадрата
                if (x + 5 * width < g.VisibleClipBounds.Width)
                    x += 3 * width;
                else
                {
                    x = 150;
                    y = y + 3 * heignt / 2;
                }
            }

            //foreach (var task in taskList)
            //{
            //    var documentRepository = new BaseDocumentRepository<Document>();
            //    foreach (var doc in task.ExternalDocuments)
            //    {
            //        if (doc.IsInner)
            //        {
            //            var nextDepartment = doc.Workplace.DepartmentId;

            //            var nextDocuments =
            //                documentRepository.Query(
            //                    d => d.Name == doc.Name && d.FK_DepartmentIdSource == nextDepartment).ToList();

            //            var nextTaskList = new List<TaskDocument>();
            //            foreach (var item in taskList)
            //            {
            //                foreach (var document in item.InernalDocuments.Where(document => nextDocuments.Any(d => d.DocumentId == document.Id) && nextTaskList.All(t => t != item)))
            //                {
            //                    nextTaskList.Add(item);
            //                }
            //            }

            //        }

            //    }

            //}


        }

        public override BaseObject GetObject(int x, int y)
        {
            BaseObject obj = null;
            foreach (var task in taskList)
            {
                obj = task.GetObject(x, y);
                if (obj != null)
                    break;
            }

            return obj;
        }

        public override void DrawQbe(Graphics graphics, QbeQueryConteiner query)
        {
            //отбираем задачи
            var taskQuery = query.Where(x => x.TaskId != 0 || x.TaskName != null).ToList();
            var resultList = taskList;
            if (taskQuery.Count != 0)
            {
                foreach (var queryItem in taskQuery)
                {
                    resultList = taskList.Where(x => (queryItem.Id != 0 && x.Task.Id == queryItem.Id) || (x.Task.Name == queryItem.TaskName)).ToList();
                }
            }
            taskList = resultList;

            //отбираем документы
            var documentQuery = query.Where(x => x.Id != 0 || x.DocumentName != null || x.DocumentType != null || x.Frequency != null).ToList();
            if (documentQuery.Count != 0)
            {
                foreach (var task in taskList)
                {
                    task.ExternalDocuments = SelectDocuments(task.ExternalDocuments, documentQuery);
                    task.InernalDocuments = SelectDocuments(task.InernalDocuments, documentQuery);
                }
            }
            Draw(graphics);
        }

        private List<DocumentObject> SelectDocuments(List<DocumentObject> fromList, List<QbeQueryItem> documentQuery)
        {
            var result = new List<DocumentObject>();
            var list = fromList;
            
            foreach (var queryItem in documentQuery)
            {
                var tempList = fromList;
                if (queryItem.Id != 0)
                {
                    list = tempList.Where(x => x.Id == queryItem.Id).ToList();
                    tempList = list;
                }
                if (queryItem.DocumentName != "")
                {
                    list = tempList.Where(x => x.Name == queryItem.DocumentName).ToList();
                    tempList = list;
                }
                if (queryItem.DocumentType != null)
                {
                    list = tempList.Where(x => x.DocTypeTitle == queryItem.DocumentType).ToList();
                    tempList = list;
                }
                if (queryItem.Frequency != null)
                {
                    list = tempList.Where(x => x.Frequence == queryItem.Frequency).ToList();
                    //tempList = list;
                }

                result.AddRange(list);
            }

            return result;
        }
    }

    class TaskDocument
    {
        public TaskObject Task { get; set; }
        //public List<DocumentObject> Documents { get; set; }
        public List<DocumentObject> InernalDocuments { get; set; }
        public List<DocumentObject> ExternalDocuments { get; set; }

        public TaskDocument(TaskObject task)
        {
            Task = task;

            var documentRepository = new BaseDocumentRepository<Document>();
            var documents = documentRepository.Query(x => x.Task.TaskId == Task.Id).ToList();
            // Documents = documents.Select(x => new DocumentObject(x)).ToList();

            InernalDocuments = documents.Where(x => x.Type == (int)DocumentType.Input || x.Type == (int)DocumentType.InputOutput).Select(x => new DocumentObject(x)).ToList();
            ExternalDocuments = documents.Where(x => x.Type == (int)DocumentType.Output || x.Type == (int)DocumentType.InputOutput).Select(x => new DocumentObject(x)).ToList();
        }

        //снимаем отметку об отрисовке
        public void UnmarkingAlreadiDrawing()
        {
            for (int i = 0; i < 2; i++)
            {
                var docList = i == 0 ? InernalDocuments : ExternalDocuments;
                foreach (var item in docList)
                {
                    item.IsAlreadyDrawing = false;
                }
            }
        }

        public void DrawDocuments(Graphics g)
        {



            //var documentRepository = new BaseDocumentRepository<Document>();
            //foreach (var doc in ExternalDocuments)
            //{
            //    if (doc.IsInner)
            //    {
            //        var nextDepartment = doc.Workplace.DepartmentId;

            //        var nextDocuments = documentRepository.Query(
            //            x => x.Name == doc.Name && x.FK_DepartmentIdSource == nextDepartment).ToList();


            //    }

            //}

            for (int i = 0; i < 2; i++)
            {
                var docList = i == 0 ? InernalDocuments : ExternalDocuments;
                //var docList =
                //    Documents.Where(x => x.IsWayTo == DocumentType.InputOutput || x.IsWayTo == (DocumentType) (i + 2)).
                //        ToList();


                //расстояние между стрелочками(документами)
                var increaseLength = Task.GetIncreaseLength(docList.Count);

                for (int j = 0; j < docList.Count; j++)
                {
                    var curType = docList[j].IsWayTo;
                    docList[j].IsWayTo = (DocumentType)(i + 2);
                    docList[j].DrawObject(g, Task.CoordX, Task.CoordY + increaseLength * (j + 1));
                    docList[j].IsWayTo = curType;
                }
            }

        }

        public BaseObject GetObject(int x, int y)
        {
            BaseObject curObj = null;
            if (Task.IsCurrentObject(x, y))
                curObj = Task;
            else
            {
                var newList = new List<DocumentObject>();
                //var newList = Documents;
                newList.AddRange(InernalDocuments);
                newList.AddRange(ExternalDocuments);
                foreach (var item in newList)
                {
                    if (item.IsCurrentObject(x, y))
                    {
                        curObj = item;
                        break;
                    }
                }
            }

            return curObj;
        }

    }
}
