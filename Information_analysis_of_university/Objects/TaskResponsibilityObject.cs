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
    class TaskResponsibilityObject : TaskObject
    {
        //private bool dragging = false;

        //[ReadOnly(true)]
        //public int Id { get; set; }

        //[ReadOnly(true)]
        //[DisplayName("Наименование")]
        //public string Name { get; set; }

        //[ReadOnly(true)]
        //[DisplayName("Должность исполнителя")]
        //public string PostName { get; set; }

        //[Browsable(false)]
        //public int CoordX
        //{
        //    get { return X; }
        //    set { X = value; }
        //}

        //[Browsable(false)]
        //public int CoordY
        //{
        //    get { return Y; }
        //    set { Y = value; }
        //}

        //public TaskObject(Task task)
        //{
        //    Id = task.TaskId;
        //    Name = task.Name;
        //    PostName = task.Post.Name;

        //    Size = 150;
        //}

        public override void DrawObject(Graphics g, int? x, int? y)
        {
            X = x ?? X;
            Y = y ?? Y;

            var pen = new Pen(Color.Black);

            var x1 = X;
            //if (IsWayTo)
                x1 = X - Size;
            //else
            //    x1 = X + Size;

            g.DrawLine(pen, x1, Y, x1 + Size, Y);
            g.FillPolygon(new SolidBrush(Color.Black), new Point[] { new Point(x1 + Size, Y), GetNewPoint(155, x1 + Size, Y), GetNewPoint(205, x1 + Size, Y) });
            //g.DrawLine(pen, new Point(x1 + Size, Y), GetNewPoint(150, x1 + Size, Y));
            //g.DrawLine(pen, new Point(x1 + Size, Y), GetNewPoint(150, x1 + Size, Y));
            DrawText(g, x1, Y, Name);
        }

        private Point GetNewPoint(int angle, int x, int y)
        {
            return new Point((int)Math.Round(x + 10 * Math.Cos(angle * 3.14 / 180), 0), (int)Math.Round(y + 10 * Math.Sin(angle * 3.14 / 180), 0));
        }

        //public int GetIncreaseLength(int count)
        //{
        //    return Size/(count + 1);
        //}

        //public bool IsCurrentObject(int x, int y)
        //{
        //    return x > X && x < X + Size && y > Y && y < Y + Size;
        //}

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
            // dragging = true;
        }

        public override void EndDrag()
        {
            //dragging = false;
        }

        //public override bool IsDragging()
        //{
        //    return dragging;
        //}


       
    }
}
