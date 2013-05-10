using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using DatabaseLevel;

namespace Information_analysis_of_university.Objects
{
    public class WorkplaceLifeElement : BaseWorkplaceObject
    {
        [Browsable(false)]
        public bool IsExternalOrganization { get; set; }



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
                DrawTextExternal(g, X, Y, DepartmentName);
            }
            else
            {
                DrawModelElement(g, X, Y, pen);
                DrawText(g, X, Y, Name);
            }
        }

        public void DrawTextExternal(Graphics g, int x, int y, string text)
        {
            g.DrawString(text, new Font("Calibri", 12, FontStyle.Bold), new SolidBrush(Color.Black), new Rectangle(x + 10, y + 10, Size / 2 - 20, Size - 20), new StringFormat(StringFormatFlags.DirectionVertical));
        }

        public override void DrawText(Graphics g, int x, int y, string text)
        {
            g.DrawString(text, new Font("Calibri", 10, FontStyle.Bold), new SolidBrush(Color.Black), new Rectangle(x, y, Size, Size / 3));
        }

        private void DrawModelElement(Graphics g, int x, int y, Pen pen)
        {
            g.DrawPolygon(pen,
                          new PointF[]
                              {
                                  new PointF(x - Size/3, y), 
                                  new PointF(x + Size, y),
                                  new PointF(x + Size + Size/3, y + Size/6), 
                                  new PointF(x + Size, y + Size/3),
                                  new PointF(x - Size/3, y + Size/3), 
                                  new PointF(x, y + Size/6), 
                                  new PointF(x - Size/3, y)
                              });

        }
    }
}
