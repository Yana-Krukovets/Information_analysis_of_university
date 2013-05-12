using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseLevel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Information_analysis_of_university.Objects
{
    class CountTaks : BaseObject
    {
        private bool dragging = false;

        [ReadOnly(true)]
        public int Count { get; set; }

        [ReadOnly(true)]
        public int CountTasks { get; set; }

        public CountTaks(int count, int countTasks)
        {
            Count = count;
            CountTasks = countTasks;            
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
            x1 = X + Size;

           // g.DrawLine(pen, x1, Y, x1 + Size, Y);
            DrawText(g, x1, Y, "Количество обрабатываемых документов - " + Count.ToString());
            DrawText(g, x1, Y + 50, "Количество выполняемых задач - " + CountTasks.ToString());
        }

        public override void DrawText(Graphics g, int x, int y, string text)
        {
            g.DrawString(text, new Font("Calibri", 10), new SolidBrush(Color.Black), new RectangleF(x+10, y-10, Size+10, 70));
        }

        private Point GetNewPoint(int angle, int x, int y)
        {
            return new Point((int)Math.Round(x+ 10*Math.Cos(angle * 3.14 / 180), 0), (int)Math.Round(y + 10* Math.Sin(angle * 3.14 / 180), 0));
        }

        public bool IsCurrentObject(int x, int y)
        {
            var x1 = X;
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
