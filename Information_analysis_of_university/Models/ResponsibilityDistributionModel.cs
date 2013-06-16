using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using DatabaseLevel;
using Information_analysis_of_university.Objects;

namespace Information_analysis_of_university.Models
{
    //модель распределения обязательств
    public class ResponsibilityDistributionModel : ModelBase
    {
        //список элемнтов модели
        private List<TaskWorkplace> workplaceList;

        public ResponsibilityDistributionModel()
        {
            //заполнение списка должностей
            workplaceList = new List<TaskWorkplace>();
            var postDocumentRepository = new BaseDocumentRepository<Post>();

            var posts = postDocumentRepository.ToList().Select(
                x => new WorkplaceResponsibilityObject(x));

            foreach (var item in posts)
            {
                workplaceList.Add(new TaskWorkplace(item));
            }
        }

        public override void DrawSQL(Graphics g, List<string> mas)
        {
            var x = 150;
            var y = 50;

            var heignt = 100;
            var width = 200;

            foreach (var wp in workplaceList)
            {
                foreach (var item in mas)
                {
                    if (item == wp.Workplace.Name)
                    {
                        wp.Workplace.DrawObject(g, x, y);

                        wp.DrawTasks(g);

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
            }
        }

        public override void Draw(Graphics g)
        {
            var x = 150;
            var y = 50;

            var heignt = 100;
            var width = 200;

            foreach (var wp in workplaceList)
            {
                wp.Workplace.DrawObject(g, x, y);

                wp.DrawTasks(g);

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
            foreach (var workplace in workplaceList)
            {
                obj = workplace.GetObject(x, y);
                if (obj != null)
                    break;
            }

            return obj;
        }

        public override void DrawQbe(Graphics graphics, QbeQueryConteiner query)
        {
            workplaceList = workplaceList.Where(task => task.QbeSelect(query)).ToList();

            Draw(graphics);
        }

        public override void ViewErrors(Graphics g, AnalisResultConteiner documents)
        {
            foreach (var workplace in workplaceList)
            {
                workplace.SetErrors(documents);
            }
            Draw(g);
        }
    }

    //класс элементов модели распределения обязательств
    class TaskWorkplace
    {
        //рабочее место
        public WorkplaceResponsibilityObject Workplace { get; set; }
        //задача + документы
        public List<TaskDocument> TaskDocuments { get; set; }
       
        public TaskWorkplace(WorkplaceResponsibilityObject wp)
        {
            Workplace = wp;

            //достаем из бд задачи
            var tasksRepository = new BaseDocumentRepository<Task>();
            var tasks = tasksRepository.Query(x => x.FK_PostId == Workplace.Id).ToList();

            TaskDocuments = new List<TaskDocument>();
            foreach (var task in tasks)
            {
                TaskDocuments.Add(new TaskDocument(new TaskObject(task)));
            }
        }

        //отрисовка задач
        public void DrawTasks(Graphics g)
        {
            if (TaskDocuments.Count > 0)
            {
                var increaseLength = Workplace.GetIncreaseLength(TaskDocuments.Count - 1);

                for (int i = 0; i < TaskDocuments.Count; i++)
                {
                    if (i < TaskDocuments.Count - 1)
                    {
                        TaskDocuments[i].Task.CoordX = Workplace.CoordX;
                        TaskDocuments[i].Task.CoordY = Workplace.CoordY + increaseLength*i;
                        g.DrawLine(new Pen(Color.Black), Workplace.CoordX, Workplace.CoordY + increaseLength*(i + 1),
                                   Workplace.CoordX + Workplace._Size, Workplace.CoordY + increaseLength*(i + 1));
                    }


                    g.DrawString(TaskDocuments[i].Task.Name, new Font("Calibri", 10), new SolidBrush(Color.Black),
                                 new RectangleF(Workplace.CoordX, Workplace.CoordY + increaseLength*i, Workplace._Size,
                                                increaseLength));
                }
            }
            DrawDocuments(g);
        }

        //отрисовка документов
        public void DrawDocuments(Graphics g)
        {
            for (int i = 0; i < 2; i++)
            {
                var docList = new List<DocumentObject>();
                foreach (var task in TaskDocuments)
                {
                    docList.AddRange(i == 0 ? task.InernalDocuments : task.ExternalDocuments);
                }

                //расстояние между стрелочками(документами)
                var increaseLength = Workplace.GetIncreaseLength(docList.Count);

                for (int j = 0; j < docList.Count; j++)
                {
                    var curType = docList[j].IsWayTo;
                    docList[j].IsWayTo = (DocumentType)(i + 2);
                    docList[j].DrawObject(g, Workplace.CoordX, Workplace.CoordY + increaseLength * (j + 1));
                    docList[j].IsWayTo = curType;
                }
            }
        }

        public BaseObject GetObject(int x, int y)
        {
            BaseObject curObj = null;
            //1) рабочее место
            if (Workplace.IsCurrentObject(x, y))
            {
                if (y <= Workplace.CoordY && y >= Workplace.CoordY - 20)
                    curObj = Workplace;
                else
                {
                    //2) задача
                    var increaseLength = Workplace.GetIncreaseLength(TaskDocuments.Count - 1);
                    for (int i = 0; i < TaskDocuments.Count; i++)
                    {
                        if (x >= Workplace.CoordX && x <= Workplace.CoordX + Workplace._Size && y >= Workplace.CoordY + increaseLength * i && y <= Workplace.CoordY + increaseLength * (i + 1))
                        {
                            curObj = TaskDocuments[i].Task;
                            break;
                        }
                    }
                }
            }
            else
            {
                //документ
                var newList = TaskDocuments;

                foreach (var item in newList)
                {
                    curObj = item.GetObject(x, y);
                    if(curObj != null)
                        break;
                }
            }

            return curObj;
        }

        public bool QbeSelect(QbeQueryConteiner query)
        {
            //для того, чтобы знать удалять ли данную задачу
            bool isCorrectWorkplace = Workplace.QbeSelect(query);

            if (isCorrectWorkplace && query.IsContainsDocumentMetric())
            {
                TaskDocuments = TaskDocuments.Where(document => document.QbeSelect(query)).ToList();

                if (TaskDocuments.Count == 0)
                    isCorrectWorkplace = false;
            }

            return isCorrectWorkplace;
        }

        public void SetErrors(AnalisResultConteiner documents)
        {
            foreach (var task in TaskDocuments)
            {
                task.SetErrors(documents);
            }
        }

    }
}
