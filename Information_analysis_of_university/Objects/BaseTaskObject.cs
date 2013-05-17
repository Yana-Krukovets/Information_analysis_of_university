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
    class BaseTaskObject : BaseObject
    {
        protected bool dragging = false;
        
        [ReadOnly(true)]
        public int Id { get; set; }

        [ReadOnly(true)]
        [DisplayName("Наименование")]
        public string Name { get; set; }
        
        [ReadOnly(true)]
        [DisplayName("Должность исполнителя")]
        public string PostName { get; set; }

        [ReadOnly(true)]
        [DisplayName("Подразделение исполнителя")]
        public string DepartmentName { get; set; }

        [Browsable(false)]
        public int DepartmentId { get; set; }

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

        public BaseTaskObject(Task task)
        {
            Id = task.TaskId;
            Name = task.Name;
            PostName = task.Post.Name;
            if (task.Post.FK_DepartmentId != null)
            {
                DepartmentId = (int) task.Post.FK_DepartmentId;
                DepartmentName = task.Post.Department.Name;
            }

        }

        protected BaseTaskObject()
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

        public int GetIncreaseLength(int count)
        {
            return Size/(count + 1);
        }

        public bool IsCurrentObject(int x, int y)
        {
            return x > X && x < X + Size && y > Y && y < Y + Size;
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



        public override bool QbeSelect(QbeQueryConteiner query)
        {
            var isCorrectTask = true;
            var isConteinsTaskMetric = query.IsConteinsTaskMetric();
            if (isConteinsTaskMetric && query.Count(x => x.TaskName != null) != 0)
            {
                isCorrectTask = query.Any(x => x.TaskName == Name);
            }
            return isCorrectTask;
        }
    }
}
