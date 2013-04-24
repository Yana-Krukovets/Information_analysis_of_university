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
    class TaskObject : BaseTaskObject
    {
        public TaskObject(Task task) : base(task)
        {
            Size = 150;
        }

        protected TaskObject()
        {
            //throw new NotImplementedException();
        }

        public override void DrawObject(Graphics g, int? x, int? y)
        {
            X = x ?? X;
            Y = y ?? Y;

            var pen = new Pen(Color.Black);

            g.DrawRectangle(pen, new Rectangle(X, Y, Size, Size));
            DrawText(g, X, Y, Name);
        }

     


    }
}
