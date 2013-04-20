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
        private List<TaskDocumentWorking> taskList;
        private List<NameWorker> workerList;

        public UseCaseModel()
        {
            taskList = new List<TaskDocumentWorking>();
            var taskDocumentRepository = new BaseDocumentRepository<Task>();
            workerList = new List<NameWorker>();

            var workerRepository = new BaseDocumentRepository<Worker>();


            var workers = workerRepository.ToList().Select(
                x => new LittleMan(x));
            var tasks = taskDocumentRepository.ToList().Select(
                x => new TaskForWorker(x));

            foreach (var item in tasks)
            {
                taskList.Add(new TaskDocumentWorking(item));
            }
            foreach (var item in workers)
            {
                workerList.Add(new NameWorker(item));
            }
        }

        public override void Draw(Graphics g)
        {
            var x = 100;
            var y = 50;

            var heignt = 100;
            var width = 100;
            foreach (var worker in workerList)
            {
                worker.Worker.DrawObject(g, x, y);

                if (x + 4 * width < g.VisibleClipBounds.Width)
                    x += 2 * width;
                else
                {
                    x = 50;
                    y = y + 3 * heignt / 2;
                }
            }
            y = 50;
            foreach (var task in taskList)
            {
                task.Task.DrawObject(g, x, y);

                task.DrawDocuments(g);

                //расчет координат нового квадрата
                if (x + 5 * width < g.VisibleClipBounds.Width)
                    x += 3 * width;
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
            foreach (var task in taskList)
            {
                obj = task.GetObject(x, y);
                if(obj != null)
                    break;
            }

            return obj;
        }
    }


    class NameWorker
    {
        public LittleMan Worker { get; set; }



        public NameWorker(LittleMan worker)
        {
            Worker = worker;


            // var documentRepository = new BaseDocumentRepository<Document>();
            // var documents = documentRepository.Query(x => x.Task.TaskId == Task.Id).ToList();

            // IsExternal = 1 (входящие) ?
            // IsExternal = 2 (исходящие) ?
            // InernalDocuments = documents.Where(x => x.IsExternal != 1).Select(x => new DocumentObject(x)).ToList();
            // ExternalDocuments = documents.Where(x => x.IsExternal != 2).Select(x => new DocumentObject(x)).ToList();
        }


    }

    class TaskDocumentWorking
    {
        public TaskForWorker Task { get; set; }
        
        public List<DocumentForWorker> InernalDocuments { get; set; }
        public List<DocumentForWorker> ExternalDocuments { get; set; }

        public TaskDocumentWorking(TaskForWorker task)
        {
            Task = task;

            var documentRepository = new BaseDocumentRepository<Document>();
            var documents = documentRepository.Query(x => x.Task.TaskId == Task.Id).ToList();

            // IsExternal = 1 (входящие) ?
            // IsExternal = 2 (исходящие) ?
            InernalDocuments = documents.Where(x => x.IsExternal != 1).Select(x => new DocumentForWorker(x, false)).ToList();
            ExternalDocuments = documents.Where(x => x.IsExternal != 2).Select(x => new DocumentForWorker(x, false)).ToList();
        }

        public void DrawDocuments(Graphics g)
        {
            for (int i = 0; i < 2; i++)
            {
                var docList = i == 0 ? InernalDocuments : ExternalDocuments;

                //расстояние между стрелочками(документами)
                var increaseLength = Task.GetIncreaseLength(docList.Count);

                for (int j = 0; j < docList.Count; j++)
                {
                    docList[j].DrawObject(g, Task.CoordX, Task.CoordY + increaseLength * (j + 1));
                }


                ////????может это и не нужно????
                //if (i == 0)
                //    InernalDocuments = docList;
                //else
                //    ExternalDocuments = docList;
            }

        }

        public BaseObject GetObject(int x, int y)
        {
            BaseObject curObj = null;
            if (Task.IsCurrentObject(x, y))
                curObj = Task;
            else
            {
                var newList = new List<DocumentForWorker>();
                newList.AddRange(InernalDocuments);
                newList.AddRange(ExternalDocuments);
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
        
        
        
        
        
        
        
        
     /*   private List<NameWorker> workerList;
        private List<NameTask> workerTaskList;

        public UseCaseModel()
        {
            workerList = new List<NameWorker>();
           
            var workerRepository = new BaseDocumentRepository<Worker>();
            

            var workers = workerRepository.ToList().Select(
                x => new LittleMan(x));

            var workersTask = workerTaskRepository.ToList().Select(
                x => new TaskForWorker(x));

            foreach (var item in workers)
            {
                workerList.Add(new NameWorker(item));
            }

            
                foreach (var item in workersTask)
                {
                    
                        workerTaskList.Add(new NameTask(item));

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

                if (x + 4 * width < g.VisibleClipBounds.Width)
                    x += 2 * width;
                else
                {
                    x = 50;
                    y = y + 3 * heignt / 2;
                }
            }
            y = 50;
            foreach (var task in workerTaskList)
            {
                task.TaskWorker.DrawObject(g, x, y);

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
            
            return obj;
        }


    }

    class NameTask
    {
        public TaskForWorker TaskWorker { get; set; }

        public TaskObject Task { get; set; }
        public List<DocumentObject> InernalDocuments { get; set; }
        public List<DocumentObject> ExternalDocuments { get; set; }

        public NameTask(TaskForWorker taskWorker)
        {
            TaskWorker = taskWorker;

            var documentRepository = new BaseDocumentRepository<Document>();
            var documents = documentRepository.Query(x => x.Task.TaskId == Task.Id).ToList();


            InernalDocuments = documents.Where(x => x.IsExternal != 1).Select(x => new DocumentObject(x, true)).ToList();
            ExternalDocuments = documents.Where(x => x.IsExternal != 2).Select(x => new DocumentObject(x, false)).ToList();
        }

        public void DrawDocuments(Graphics g)
        {
            for (int i = 0; i < 2; i++)
            {
                var docList = i == 0 ? InernalDocuments : ExternalDocuments;

                //расстояние между стрелочками(документами)
                var increaseLength = Task.GetIncreaseLength(docList.Count);

                for (int j = 0; j < docList.Count; j++)
                {
                    docList[j].DrawObject(g, Task.CoordX, Task.CoordY + increaseLength * (j + 1));
                }


                ////????может это и не нужно????
                //if (i == 0)
                //    InernalDocuments = docList;
                //else
                //    ExternalDocuments = docList;
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


        class NameWorker
        {
            public LittleMan Worker { get; set; }



            public NameWorker(LittleMan worker)
            {
                Worker = worker;


                // var documentRepository = new BaseDocumentRepository<Document>();
                // var documents = documentRepository.Query(x => x.Task.TaskId == Task.Id).ToList();

                // IsExternal = 1 (входящие) ?
                // IsExternal = 2 (исходящие) ?
                // InernalDocuments = documents.Where(x => x.IsExternal != 1).Select(x => new DocumentObject(x)).ToList();
                // ExternalDocuments = documents.Where(x => x.IsExternal != 2).Select(x => new DocumentObject(x)).ToList();
            }


        }*/

        
    }
}

