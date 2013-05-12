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
    class UseCaseModel : ModelBase
    {
        private List<NameWorker> workerList;

        public UseCaseModel()
        {           
            workerList = new List<NameWorker>();
            var workerRepository = new BaseDocumentRepository<Worker>();

            var workers = workerRepository.ToList().Select(
                x => new LittleMan(x));            
       
            foreach (var item in workers)
            {
                workerList.Add(new NameWorker(item));
            }
        }

        public override void DrawSQL(Graphics g, List<string> mas)
        {
            var x = 50;
            var y = 100;

            var heignt = 100;
            var width = 100;
            foreach (var worker in workerList)
            {
                foreach (var item in mas)
                {
                    if (item == worker.Worker.Name)
                    {
                        worker.Worker.DrawObject(g, x, y);
                        worker.DrawDocuments(g);
                        if (x + 5 * width < g.VisibleClipBounds.Width)
                            x += 3 * width;
                        else
                        {
                            x = 50;
                            y = y + 3 * heignt / 2;
                        }
                    }
                }
            }
        }

        public override void Draw(Graphics g)
        {
            var x = 50;
            var y = 100;

            var heignt = 100;
            var width = 100;
            foreach (var worker in workerList)
            {
                worker.Worker.DrawObject(g, x, y);
                worker.DrawDocuments(g);
                if (x + 4 * width < g.VisibleClipBounds.Width)
                    x += 2 * width;
                else
                {
                    x = 50;
                    y = y + 3 * heignt / 2;
                }
            } 
        }      

        public override BaseObject GetObject(int x, int y)
         {
            BaseObject obj = null;
            foreach (var name in workerList)
            {
                obj = name.GetObject(x, y);
                if(obj != null)
                    break;
            }

            return obj;
        }

        public override void DrawQbe(Graphics graphics, QbeQueryConteiner query)
        {
            //throw new NotImplementedException();
        }
    }

    class NameWorker
    {
        public LittleMan Worker { get; set; }
        public TaskForWorker Task { get; set; }
        public List<TaskForWorker> taskList { get; set; }  
        public List<DocumentForWorker> Documents { get; set; }

        public NameWorker(LittleMan worker)
        {
            Worker = worker;
            taskList = new List<TaskForWorker>();        
            Documents = new List<DocumentForWorker>();
            var taskDocumentRepository = new BaseDocumentRepository<Task>();
            var tasks = taskDocumentRepository.Query(x => x.FK_PostId == Worker.PostId).ToList();
            taskList = tasks.Select(x => new TaskForWorker(x)).ToList();
            var documentRepository = new BaseDocumentRepository<Document>();
            var documents = documentRepository.ToList();
            for (int i = 0; i < tasks.Count; i++)
            {
                foreach (var doc in documents)
                {
                    if (tasks[i].TaskId == doc.FK_TaskId)
                    {
                        Documents.Add(new DocumentForWorker(doc));
                    }
                }
            }        
        }

        public void DrawDocuments(Graphics g)
        {
            var increaseLengthTask = Worker.GetIncreaseLength(taskList.Count);
            var y = 100;
            taskList[0].CoordY = Worker.CoordY - 200;
            for (int i = 0; i < taskList.Count; i++)
            {
                taskList[i].CoordY = taskList[i].CoordY + y;
                taskList[i].DrawObject(g, Worker.CoordX + 200, taskList[i].CoordY + increaseLengthTask * (i + 1));
                var pen = new Pen(Color.Black);
                g.DrawLine(pen, Worker.CoordX + 50, Worker.CoordY + 20, taskList[i].CoordX-10, taskList[i].CoordY + 30);
                for (int j = 0; j < Documents.Count; j++)
                {
                    if (taskList[i].Id == Documents[j].TaskId)
                    {
                        y = taskList[i].CoordY + 3*Documents.Count * (j * 10) / Documents.Count;
                        Documents[j].DrawObject(g, taskList[i].CoordX, y);
                        g.DrawLine(pen, taskList[i].CoordX + 100, taskList[i].CoordY + 50, taskList[i].CoordX + 220, y);
                    }
                }
                taskList[i].CoordY = taskList[i].CoordY + y; 
                
            }          
        }

        public BaseObject GetObject(int x, int y)
        {
            BaseObject curObj = null;
            if (Worker.IsCurrentObject(x, y))
                curObj = Worker;
            else
            {
                var newList = new List<TaskForWorker>();
                newList.AddRange(taskList);
             
                foreach (var item in newList)
                {
                    if (item.IsCurrentObject(x, y))
                    {
                        curObj = item;
                        break;
                    }
                    else
                    {
                        var newList1 = new List<DocumentForWorker>();
                        newList1.AddRange(Documents);
                        foreach (var item1 in newList1)
                        {
                            if (item.IsCurrentObject(x, y))
                            {
                                curObj = item1;
                                break;
                            }
                        }
                    }

                }
            }
            return curObj;
        }        
    }
}

