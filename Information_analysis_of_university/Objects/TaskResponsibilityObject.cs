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
    class TaskResponsibilityObject : BaseTaskObject
    {
        //направление стрелочки
        [Browsable(false)]
        public bool IsWayTo { get; set; }   //true - стрелка входит

        public TaskResponsibilityObject(Task task, bool wayTo) : base(task)
        {
            IsWayTo = wayTo;
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

        


       
    }
}
