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

        public override void Draw(Graphics g)
        {
            var x = 100;
            var y = 50;

            var heignt = 100;
            var width = 100;

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

    class TaskDocument
    {
        public TaskObject Task { get; set; }
        public List<DocumentObject> InernalDocuments { get; set; }
        public List<DocumentObject> ExternalDocuments { get; set; }

        public TaskDocument(TaskObject task)
        {
            Task = task;

            var documentRepository = new BaseDocumentRepository<Document>();
            var documents = documentRepository.Query(x => x.Task.TaskId == Task.Id).ToList();

            // IsExternal = 1 (входящие) ?
            // IsExternal = 2 (исходящие) ?
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
