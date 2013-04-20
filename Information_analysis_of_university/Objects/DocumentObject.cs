using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using DatabaseLevel;

namespace Information_analysis_of_university.Objects
{
    public class DocumentObject : BaseObject
    {
        private bool dragging = false;
        
        //поля из бд
        [ReadOnly(true)]
        public int Id { get; set; }

        [ReadOnly(true)]
        [DisplayName("Название")]
        public string Name { get; set; }

        [ReadOnly(true)]
        [DisplayName("Назначение")]
        public string Function { get; set; }

        [ReadOnly(true)]
        [DisplayName("Периодичность")]
        public string Frequence { get; set; }
        
        [ReadOnly(true)]
        [DisplayName("Количество полей")]
        public int CountFilds { get; set; }

        //направление стрелочки
        [Browsable(false)]
        public bool IsWayTo { get; set; }   //true - стрелка входит

        public DocumentObject(Document document, bool isWayTo)
        {
            Id = document.DocumentId;
            Name = document.Name;
            Function = document.DocFunction;
            Frequence = document.Frequence;
            //CountFilds = 

            IsWayTo = isWayTo;
        }

        //задаем значение координат
        [Browsable(false)]
        public int CoordX
        {
            get { return X; }
            set { X = value; }
        }

        [Browsable(false)]
        public int CoordY
        {
            get { return Y; }
            set { Y = value; }
        }


        public override void DrawObject(Graphics g, int? x, int? y)
        {
            X = x ?? X;
            Y = y ?? Y;

            var pen = new Pen(Color.Black);

            var x1 = X;
            if (IsWayTo)
                x1 = X - Size;
            else
                x1 = X + Size;

            g.DrawLine(pen, x1, Y, x1 + Size, Y);
            g.FillPolygon(new SolidBrush(Color.Black), new Point[] { new Point(x1 + Size, Y), GetNewPoint(155, x1 + Size, Y), GetNewPoint(205, x1 + Size, Y) });
            //g.DrawLine(pen, new Point(x1 + Size, Y), GetNewPoint(150, x1 + Size, Y));
            //g.DrawLine(pen, new Point(x1 + Size, Y), GetNewPoint(150, x1 + Size, Y));
            DrawText(g, x1, Y, Name);
        }

        public override void DrawText(Graphics g, int x, int y, string text)
        {
            g.DrawString(text, new Font("Times New Roman", 8), new SolidBrush(Color.Gray), new RectangleF(x, y - 12, Size, 40));
        }

        private Point GetNewPoint(int angle, int x, int y)
        {
            return new Point((int)Math.Round(x+ 10*Math.Cos(angle * 3.14 / 180), 0), (int)Math.Round(y + 10* Math.Sin(angle * 3.14 / 180), 0));
        }

        public bool IsCurrentObject(int x, int y)
        {
            var x1 = X;
            if (IsWayTo)
                x1 = X - Size;
            else
                x1 = X + Size;
            return x > x1 && x < x1 + Size && y > Y - 12 && y < Y + 28;
        }
        public override void Drag(Point pt, System.Windows.Forms.Form wnd)
        {
            wnd.Invalidate(false);

            X = pt.X - X;
            Y = pt.Y - Y;

            wnd.Invalidate(false);
        }

        public override void BeginDrag(Point pt)
        {
            X = pt.X - X;
            Y = pt.Y - Y;
            dragging = true;
        }

        public override void EndDrag()
        {
            dragging = false;
        }
        public override bool IsDragging()
        {
            return dragging;
        }
    }

}
