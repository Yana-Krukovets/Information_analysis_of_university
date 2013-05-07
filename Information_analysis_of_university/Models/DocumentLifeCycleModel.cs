using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using DatabaseLevel;
using Information_analysis_of_university.Objects;

namespace Information_analysis_of_university.Models
{
    class DocumentLifeCycleModel : ModelBase
    {
        public List<LifeCycle> LifeCycles { get; set; }

        public DocumentLifeCycleModel()
        {
            var documentRepository = new BaseDocumentRepository<Document>();

            var documentsList = documentRepository.ToList().Where(
                x =>
                ((x.Type == (byte)DocumentType.Input || x.Type == (byte)DocumentType.InputOutput) && x.IsExternal == 2) ||
                x.Type == (byte)DocumentType.Output);

            LifeCycles = new List<LifeCycle>();
            foreach (var document in documentsList)
            {
                LifeCycles.Add(new LifeCycle(document));
            }
        }

        public override void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }

        public override BaseObject GetObject(int x, int y)
        {
            throw new NotImplementedException();
        }
    }

    public class LifeCycle
    {
        public DocumentObject Document { get; set; }
        public List<WorkplaceLifeElement> Workplaces { get; set; }

        public LifeCycle(Document document)
        {
            Document = new DocumentObject(document);

            var taskRepository = new BaseDocumentRepository<Task>();
            var task = taskRepository.FirstOrDefault(x => x.TaskId == document.FK_TaskId);
            //начальный элемент
            Workplaces = new List<WorkplaceLifeElement> {new WorkplaceLifeElement(task.Post)};


        }
    }
}
