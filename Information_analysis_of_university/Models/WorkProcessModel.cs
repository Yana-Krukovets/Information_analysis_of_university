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
            var x = 50;
            var y = 50;

            var heignt = 100;
            var width = 100;

            foreach (var task in taskList)
            {
                task.Task.DrawObject(g, x, y);

                if (x + 4 * width < g.VisibleClipBounds.Width)
                    x += 2 * width;
                else
                {
                    x = 50;
                    y = y + 3 * heignt / 2;
                }
            }
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
            InernalDocuments = documents.Where(x => x.IsExternal != 1).Select(x => new DocumentObject(x)).ToList();
            ExternalDocuments = documents.Where(x => x.IsExternal != 2).Select(x => new DocumentObject(x)).ToList();
        }

        
    }
}
