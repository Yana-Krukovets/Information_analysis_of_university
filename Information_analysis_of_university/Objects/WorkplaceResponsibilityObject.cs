using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using DatabaseLevel;
using Information_analysis_of_university.Utilites;

namespace Information_analysis_of_university.Objects
{
    //класс объекта подразделения университета (отобрадение в виде прямоугольника с закругленными краями)
    class WorkplaceResponsibilityObject : BaseWorkplaceObject
    {
        public WorkplaceResponsibilityObject(Post post) : base(post) { }

        public override void DrawObject(Graphics g, int? x, int? y)
        {
            X = x ?? X;
            Y = y ?? Y;

            var pen = new Pen(Color.Black);
            g.DrawRoundedRectangle(pen, X, Y, Size, (float)(Size * 2.0 / 3.0), 10);
            DrawText(g, X, Y, Name);
        }

        public override void DrawText(Graphics g, int x, int y, string text)
        {
            g.DrawString(text, new Font("Calibri", 13, FontStyle.Bold), new SolidBrush(Color.Brown), new RectangleF(x, y - 20, x + Size, y + Size + 2 / 3));
        }

        public override void Drag(Point pt, System.Windows.Forms.Form wnd)
        {
            wnd.Invalidate(false);

            X = pt.X - X;
            Y = pt.Y - Y;

            wnd.Invalidate(false);
        }

    }
}
