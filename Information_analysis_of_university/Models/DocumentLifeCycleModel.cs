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
                (((x.Type == (byte)DocumentType.Input || x.Type == (byte)DocumentType.InputOutput) /*&& x.IsExternal == 2*/) ||
                x.Type == (byte)DocumentType.Output) && x.DocumentId > 1000);

            LifeCycles = new List<LifeCycle>();
            var usingDocuments = new List<Document>();
            foreach (var document in documentsList)
            {
                if (usingDocuments.All(x => x.DocumentId != document.DocumentId))
                {
                    usingDocuments.Add(document);
                    LifeCycles.Add(new LifeCycle(document, ref usingDocuments));
                }
            }
        }

        public override void DrawSQL(Graphics g, List<string> mas)
        {
            var x = 50;
            var y = 50;

            foreach (var item in LifeCycles)
            {
                foreach (var item1 in mas)
                {
                    if (item1 == item.Document.Name)
                    {
                        item.Draw(g, x, y);
                        x = 50;
                        y += 200;
                    }
                }
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
            BaseObject obj = null;
            foreach (var cycle in LifeCycles)
            {
                obj = cycle.GetObject(x, y);
                if (obj != null)
                    break;
            }

            return obj;
        }

        public override void DrawQbe(Graphics graphics, QbeQueryConteiner query)
        {
            LifeCycles = LifeCycles.Where(document => document.QbeSelect(query)).ToList();

            Draw(graphics);
        }
    }

    public class LifeCycle
    {
        public DocumentObject Document { get; set; }
        public List<WorkplaceLifeElement> Workplaces { get; set; }

        public LifeCycle(Document document, ref List<Document> usingDocuments)
        {

            Document = new DocumentObject(document);

            //var taskRepository = new BaseDocumentRepository<Task>();
            //var task = taskRepository.FirstOrDefault(x => x.TaskId == document.FK_TaskId);
            Workplaces = new List<WorkplaceLifeElement>();
            //находим стадии жизненного цикла
            NextPost(document, ref usingDocuments);
        }

        private void NextPost(Document document, ref List<Document> documentList)
        {
            var taskRepository = new BaseDocumentRepository<Task>();
            var task = taskRepository.FirstOrDefault(x => x.TaskId == document.FK_TaskId);

            var workerRepository = new BaseDocumentRepository<Worker>();
            var resposibleWorker =
                workerRepository.FirstOrDefault(x => x.WorkerId == document.FK_ResponsibleId);

            var documentRepository = new BaseDocumentRepository<Document>();

            if (document.Type != null)
            {
                if ((DocumentType)document.Type == DocumentType.InputOutput ||
                    (DocumentType)document.Type == DocumentType.Input)
                {
                    //это конечная стадия ЖЦ

                    //если есть ид департамента-источника и еще не было занесено в список никаких элементов
                    if (document.FK_DepartmentIdSource != null && Workplaces.Count == 0)
                    {
                        var firstDocument = documentRepository.FirstOrDefault(
                            x => x.Name == document.Name && x.Type == (int)DocumentType.Output &&
                                 x.FK_DepartmentIdDestination == document.FK_DepartmentIdSource);
                        if (firstDocument != null)
                        {
                            documentList.Remove(document);
                            documentList.Add(firstDocument);
                            NextPost(firstDocument, ref documentList);
                        }
                        else
                            Workplaces.Add(new WorkplaceLifeElement { DepartmentName = document.Department1.Name });
                    }


                    //для внешних документов нужно запомнить имя поставщика
                    if (document.IsExternal == 2)
                        Workplaces.Add(new WorkplaceLifeElement { DepartmentName = document.Source, IsExternalOrganization = true });
                }

                if (documentList.LastOrDefault() == document)
                    Workplaces.Add(new WorkplaceLifeElement(document.Post) { ResponsibleWorker = resposibleWorker != null ? resposibleWorker.Name : null });

                if ((DocumentType)document.Type == DocumentType.InputOutput ||
                    (DocumentType)document.Type == DocumentType.Output)
                {


                    ////если сначала найден док вх-вых, а не выходящий
                    //if ((DocumentType)document.Type == DocumentType.InputOutput && Workplaces.Count == 0)
                    //{
                    //    var firstDocument = documentRepository.FirstOrDefault(
                    //        x => x.Name == document.Name && x.Type == (int)DocumentType.Output);
                    //    if (firstDocument != null)
                    //    {
                    //        documentList.Remove(document);
                    //        documentList.Add(firstDocument);
                    //        NextPost(firstDocument, ref documentList);
                    //    }
                    //}
                    //else
                    {
                        //для внешних документов запоминаем 
                        if (document.IsExternal == 2 && document.Destination != "")
                            Workplaces.Add(new WorkplaceLifeElement { DepartmentName = document.Destination, IsExternalOrganization = true });
                        else
                        {
                            //департамент, куда направится документ
                            var nextDepartment = document.Department;

                            //выбираем документ с таким же именени и DepartmentSource = nextDepartment

                            ////выбираем все задачи, которые относятся к данному департаменту
                            //var taskList = (from t in taskRepository.ToList()
                            //                join p in new BaseDocumentRepository<Post>().ToList() on t.FK_PostId equals p.PostId
                            //                where p.FK_DepartmentId == nextDepartment.DepartmentId
                            //                select t).ToList();

                            //выбираем вход или вход/выход документы
                            //которые относятся к задачам из taskList
                            //и этого док-та нет в списке выбранных ранее (documentList)
                            var nextDocuments = documentRepository.Query(
                                x =>
                                (x.Type == (int)DocumentType.Input || x.Type == (int)DocumentType.InputOutput) &&
                                x.Name == document.Name && x.FK_DepartmentIdSource == nextDepartment.DepartmentId).ToList();

                            var tempList = new List<Document>();
                            //nextDocuments.Clear();
                            var list = documentList;
                            tempList.AddRange(nextDocuments.Where(doc => /*taskList.Any(x => x.TaskId == doc.FK_TaskId) && */list.All(x => x.DocumentId != doc.DocumentId)));

                            //нужно отсортировать: сначала вх-вых, а потом входящие
                            foreach (var doc in tempList)
                            {
                                if (documentList.All(x => x.DocumentId != doc.DocumentId))
                                {
                                    documentList.Add(doc);
                                    NextPost(doc, ref documentList);
                                }
                            }
                        }
                    }

                }
            }
        }

        public void Draw(Graphics g, int x, int y)
        {
            Document.CoordX = x;
            Document.CoordY = y;
            g.DrawString(Document.Name, new Font("Calibri", 18, FontStyle.Bold), new SolidBrush(Color.Brown), x, y);

            y += 25;

            Workplaces[0].IsFirstItem = true;
            Workplaces[Workplaces.Count - 1].IsFirstItem = false;
            foreach (var workplace in Workplaces)
            {
                var y1 = y;
                if (!workplace.IsExternalOrganization)
                    y1 += workplace._Size / 3;

                workplace.DrawObject(g, x, y1);

                if (!workplace.IsExternalOrganization)
                    x += 4 * workplace._Size / 3;
                else
                    x += workplace._Size / 2 + 70;
            }
        }

        public BaseObject GetObject(int x, int y)
        {
            BaseObject curObj = null;
            if (x >= Document.CoordX && x <= Document.CoordX + 100 && y >= Document.CoordY && y <= Document.CoordY + 25)
                curObj = Document;
            else
            {
                foreach (var item in Workplaces)
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

        public bool QbeSelect(QbeQueryConteiner query)
        {
            //для того, чтобы знать удалять ли данную задачу
            bool isCorrectDocument = Document.QbeSelect(query);
            //var isConteinsTaskMetric = query.IsConteinsTaskMetric();

            if (isCorrectDocument && query.IsContainsDocumentMetric())
            {
                if (Workplaces.Count(document => document.QbeSelect(query)) == 0)
                    Workplaces.Clear();
                //ExternalDocuments = ExternalDocuments.Where(document => document.QbeSelect(query)).ToList();

                if (Workplaces.Count == 0)
                    isCorrectDocument = false;
            }

            return isCorrectDocument;
        }
    }
}
