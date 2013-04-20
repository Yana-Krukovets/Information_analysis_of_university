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
            var taskDocumentRepository = new BaseDocumentRepository<Task>();
            var tasks = taskDocumentRepository.Query(x => x.FK_PostId == Worker.PostId).ToList();
            taskList = tasks.Select(x => new TaskForWorker(x)).ToList();
            var documentRepository = new BaseDocumentRepository<Document>();
         /*   var documents = documentRepository.ToList().Select(
                x => new DocumentForWorker(x));
         //   var documents = documentRepository.Query(y => y.FK_TaskId== Task.Id).ToList();
           //Documents = documents.
            foreach (var task in taskList)
            {
                foreach (var item in documents)
                {
                    if (item.TaskId == task.Id)
                        Documents.Add(item);
                }
            }*/
        }

        public void DrawDocuments(Graphics g)
        {
            var increaseLengthTask = Worker.GetIncreaseLength(taskList.Count);
            for (int i = 0; i < taskList.Count; i++)
            {
                taskList[i].DrawObject(g, Worker.CoordX+200, Worker.CoordY-100 + increaseLengthTask * (i + 1));
                Worker.CoordY = Worker.CoordY + 100;
             /*    var increaseLength = Task.GetIncreaseLength(Documents.Count);

               for (int j = 0; j < Documents.Count; j++)
                {
                    Documents[j].DrawObject(g, Task.CoordX, Task.CoordY + increaseLength * (j + 1));
                }*/
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
                    if(item.IsCurrentObject(x, y))
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

