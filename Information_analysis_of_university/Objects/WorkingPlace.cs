﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using DatabaseLevel;

namespace Information_analysis_of_university.Objects
{
    class WorkingPlace : BaseObject
    {
        private bool dragging = false;

        [ReadOnly(true)]
        public int Id { get; set; }

        [ReadOnly(true)]
        [DisplayName("Название отдела")]
        public string Name { get; set; }
        
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

        public WorkingPlace(Department department)
        {
            Id = department.DepartmentId;
            Name = department.Name;
           // PostName = task.Post.Name;

           // Size = 100;
        }

        public override void DrawObject(Graphics g, int? x, int? y)
        {
            X = x ?? X;
            Y = y ?? Y;

            var pen = new Pen(Color.Black);

            g.DrawRectangle(pen, new Rectangle(X, Y, Size, Size));
            DrawText(g, X-20, Y, Name);
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
            var isConteinsWorkplaceMetric = query.IsContainsWorkplaceMetric();
            bool result = true;

            if (isConteinsWorkplaceMetric)
            {
                foreach (var queryRow in query)
                {
                    //result.Clear();
                    if (query.IsConteinsPostName() && queryRow.PostName != null)
                    {
                        result = queryRow.PostName == Name;
                        if(result)
                            break;
                    }

                    //if (result.Count == 0 || result.All(x => x))
                    //    break;
                }
            }
            return result && isConteinsWorkplaceMetric;
        }
    }
}

