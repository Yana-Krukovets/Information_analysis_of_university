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

            //ишем все документы:
            //1) внешние, которые либо входяшие, либо входящие-исходяшие
            //2) внутренные исходящие
            //для того, чтобы найти их начало жизненного цикла
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
            var x = 50;
            var y = 50;

            foreach (var item in LifeCycles)
            {
                item.Draw(g, x, y);
                x = 50;
                y += 200;
            }
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

            //var taskRepository = new BaseDocumentRepository<Task>();
            //var task = taskRepository.FirstOrDefault(x => x.TaskId == document.FK_TaskId);
            Workplaces = new List<WorkplaceLifeElement>();
            //находим стадии жизненного цикла
            var usingDocuments = new List<Document> { document };
            NextPost(document, usingDocuments);
        }

        private void NextPost(Document document, List<Document> documentList)
        {
            var taskRepository = new BaseDocumentRepository<Task>();
            var task = taskRepository.FirstOrDefault(x => x.TaskId == document.FK_TaskId);
            var resposibleWorker =
                new BaseDocumentRepository<Worker>().FirstOrDefault(x => x.WorkerId == document.FK_ResponsibleId);

            if (document.Type != null)
            {
                if ((DocumentType)document.Type == DocumentType.InputOutput ||
                    (DocumentType)document.Type == DocumentType.Input)
                {
                    //это конечная стадия ЖЦ

                    //если есть ид департамента-источника и еще не было занесено в список никаких элементов
                    if (document.FK_DepartmentIdSource != null && Workplaces.Count == 0)
                        Workplaces.Add(new WorkplaceLifeElement { DepartmentName = document.Department1.Name });

                    //для внешних документов нужно запомнить имя поставщика
                    if (document.IsExternal == 2)
                        Workplaces.Add(new WorkplaceLifeElement { DepartmentName = document.Source, IsExternalOrganization = true });
                }

                Workplaces.Add(new WorkplaceLifeElement(task.Post) { ResponsibleWorker = resposibleWorker != null ? resposibleWorker.Name : null });

                if ((DocumentType)document.Type == DocumentType.InputOutput ||
                    (DocumentType)document.Type == DocumentType.Output)
                {
                    //для внешних документов запоминаем 
                    if (document.IsExternal == 2 && document.Destination != null)
                        Workplaces.Add(new WorkplaceLifeElement { DepartmentName = document.Destination, IsExternalOrganization = true });
                    else
                    {
                        //департамент, куда направится документ
                        var nextDepartment = document.Department;

                        var documentRepository = new BaseDocumentRepository<Document>();
                        //выбираем все задачи, которые относятся к данному департаменту
                        var taskList = (from t in taskRepository.ToList()
                                        join p in new BaseDocumentRepository<Post>().ToList() on t.FK_PostId equals p.PostId
                                        where p.FK_DepartmentId == nextDepartment.DepartmentId
                                        select t).ToList();

                        //выбираем вход или вход/выход документы
                        //которые относятся к задачам из taskList
                        //и этого док-та нет в списке выбранных ранее (documentList)
                        var nextDocuments = documentRepository.Query(
                            x =>
                            (x.Type == (int)DocumentType.Input || x.Type == (int)DocumentType.InputOutput) &&
                            x.Name == document.Name).ToList();

                        var tempList = nextDocuments;
                        nextDocuments.Clear();
                        nextDocuments.AddRange(tempList.Where(doc => taskList.Any(x => x == doc.Task) && documentList.All(x => x != doc)));

                        //                        nextDocuments = (from d in nextDocuments
                        //                                        join t in taskList on d.FK_TaskId equals t.TaskId
                        //                                        select d).ToList();

                        //documentList.All(z => z != x) && x.Name == document.Name).
                        //                            ToList();

                        foreach (var doc in nextDocuments)
                        {
                            documentList.Add(doc);
                            NextPost(doc, documentList);
                        }
                    }
                }
            }
        }

        public void Draw(Graphics g, int x, int y)
        {
            g.DrawString(Document.Name, new Font("Calibri", 18, FontStyle.Bold), new SolidBrush(Color.Brown), x, y);

            y += 25;
            foreach (var workplace in Workplaces)
            {
                var y1 = y;
                if (!workplace.IsExternalOrganization)
                    y1 += workplace._Size / 3;

                workplace.DrawObject(g, x, y1);

                if (!workplace.IsExternalOrganization)
                    x += 4 * workplace._Size / 3;
                else
                    x += workplace._Size/2 + 70; 
            }
        }
    }
}
