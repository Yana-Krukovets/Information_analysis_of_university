using System;
using System.ComponentModel;
using System.Drawing;
using DatabaseLevel;

namespace Information_analysis_of_university.Objects
{
    //класс элемента жизненного цикла документа
    public class WorkplaceLifeElement : BaseWorkplaceObject
    {
        [ReadOnly(true)]
        [DisplayName("Внешняя организация")]
        public bool IsExternalOrganization { get; set; }

        [Browsable(false)]
        public bool? IsFirstItem { get; set; }

        public WorkplaceLifeElement(Post post)
            : base(post)
        {
            IsExternalOrganization = false;
        }

        public WorkplaceLifeElement()
            : base()
        {
            Id = 0;
            IsExternalOrganization = false;
        }

        public override void DrawObject(Graphics g, int? x, int? y)
        {
            X = x ?? X;
            Y = y ?? Y;

            var pen = new Pen(Color.Black, 2);

            if (IsExternalOrganization)
            {
                //внешняя организация
                g.DrawRectangle(pen, new Rectangle(X, Y, Size / 2, Size));
                DrawTextExternal(g, X, Y, GetTitle());
            }
            else
            {
                //внутреннее подразделение
                DrawModelElement(g, X, Y, pen);
                DrawText(g, X, Y, GetTitle());
            }
        }

        //наименование этапа ЖЦ
        private string GetTitle()
        {
            return String.Format("{0}\n{1} {2}", DepartmentName, Name, ResponsibleWorker);
        }

        //тект для внешних организаций
        public void DrawTextExternal(Graphics g, int x, int y, string text)
        {
            g.DrawString(text, new Font("Calibri", 12), new SolidBrush(Color.Black), new Rectangle(x + 10, y + 10, Size / 2 - 20, Size - 20), new StringFormat(StringFormatFlags.DirectionVertical));
        }

        public override void DrawText(Graphics g, int x, int y, string text)
        {
            g.DrawString(text, new Font("Calibri", 10), new SolidBrush(Color.Black), new Rectangle(x, y, Size, Size / 3));
        }

        //отображение элемента ЖЦ
        private void DrawModelElement(Graphics g, int x, int y, Pen pen)
        {
            PointF[] polygon;
            switch (IsFirstItem)
            {
                case true:
                    polygon = new PointF[]
                              {
                                  new PointF(x - Size/3, y), 
                                  new PointF(x + Size, y),
                                  new PointF(x + Size + Size/3, y + Size/6), 
                                  new PointF(x + Size, y + Size/3),
                                  new PointF(x - Size/3, y + Size/3), 
                                  new PointF(x - Size/3, y)
                              };
                    break;
                case false:
                    polygon = new PointF[]
                              {
                                  new PointF(x - Size/3, y), 
                                  new PointF(x + Size, y),
                                  new PointF(x + Size, y + Size/3),
                                  new PointF(x - Size/3, y + Size/3), 
                                  new PointF(x, y + Size/6), 
                                  new PointF(x - Size/3, y)
                              };
                    break;
                default:
                    polygon = new PointF[]
                              {
                                  new PointF(x - Size/3, y), 
                                  new PointF(x + Size, y),
                                  new PointF(x + Size + Size/3, y + Size/6), 
                                  new PointF(x + Size, y + Size/3),
                                  new PointF(x - Size/3, y + Size/3), 
                                  new PointF(x, y + Size/6), 
                                  new PointF(x - Size/3, y)
                              };
                    break;
            }

            g.DrawPolygon(pen,polygon);

        }

        public override bool IsCurrentObject(int x, int y)
        {
            bool result = false;
            if(IsExternalOrganization)
                result = x > X && x < X + Size / 2 && y > Y && y < Y + Size;
            else
                result = x > X && x < X + Size && y > Y && y < Y + Size / 3;
            return result;
        }
    }
}
