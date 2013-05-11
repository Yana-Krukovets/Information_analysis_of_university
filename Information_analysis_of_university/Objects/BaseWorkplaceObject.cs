﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using DatabaseLevel;

namespace Information_analysis_of_university.Objects
{
    public class BaseWorkplaceObject : BaseObject
    {
        protected bool dragging = false;
        
        [ReadOnly(true)]
        public int Id { get; set; }

        [ReadOnly(true)]
        [DisplayName("Должность")]
        public string Name { get; set; }
        
        [ReadOnly(true)]
        [DisplayName("Подразделение")]
        public string DepartmentName { get; set; }

        [ReadOnly(true)]
        [DisplayName("Ответственный за выполнение")]
        public string ResponsibleWorker { get; set; }

        [ReadOnly(true)]
        [DisplayName("Дата")]
        public DateTime Date { get; set; }

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

        [Browsable(false)]
        public int _Size
        {
            get { return Size; }
            set { Size = value; }
        }

        public BaseWorkplaceObject(Post post)
        {
            Id = post.PostId;
            Name = post.Name;
            DepartmentName = post.Department.Name;
            Date = post.Date;

            Size = 150;
        }

        protected BaseWorkplaceObject()
        {
            Size = 150;
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
            return Size*2/(3*(count + 1));
        }

        public virtual bool IsCurrentObject(int x, int y)
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


    }
}
