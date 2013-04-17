using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using DatabaseLevel;

namespace Information_analysis_of_university.Objects
{
    class TaskObject : BaseObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PostName { get; set; }

        public TaskObject(Task task)
        {
            Id = task.TaskId;
            Name = task.Name;
            PostName = task.Post.Name;

            Size = 100;
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
